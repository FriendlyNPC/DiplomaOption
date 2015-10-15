using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiplomaDataModel.Models;

namespace OptionsWebSite.Controllers
{
    public class ChoiceController : Controller
    {
        private DiplomaDataModelContext db = new DiplomaDataModelContext();

        // GET: Choice
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> Index()
        {
            var choices = db.Choices.Include(c => c.Option1).Include(c => c.Option2).Include(c => c.Option3).Include(c => c.Option4).Include(c => c.YearTerm);
            return View(await choices.ToListAsync());
        }

        // GET: Choice/Details/5
        [Authorize(Roles = "Admin, Student")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = await db.Choices.FindAsync(id);

            if (choice == null)
            {
                return HttpNotFound();
            }

            if(User.IsInRole("Student"))
            {
                if (! choice.StudentId.Equals(User.Identity.Name))
                {
                    var exists = db.Choices.Where(c => c.StudentId == User.Identity.Name).FirstOrDefault();
                    if (exists != null)
                    {
                        return RedirectToAction("Details", "Choice", new { id = exists.ChoiceId });
                    }
                    return RedirectToAction("Create", "Choice");
                }
                    
            }

            choice.Option1 = await db.Options.FindAsync(choice.FirstChoiceOptionId);
            choice.Option2 = await db.Options.FindAsync(choice.SecondChoiceOptionId);
            choice.Option3 = await db.Options.FindAsync(choice.ThirdChoiceOptionId);
            choice.Option4 = await db.Options.FindAsync(choice.FourthChoiceOptionId);

            return View(choice);
        }

        // GET: Choice/Create
        [Authorize(Roles = "Admin, Student")]
        public ActionResult Create()
        {

            if (User.IsInRole("Student"))
            {
                var exists = db.Choices.Where(c => c.StudentId == User.Identity.Name).FirstOrDefault();

                if (exists != null)
                {
                    //choice already exists
                    return RedirectToAction("Details", "Choice", new { id = exists.ChoiceId });
                }
            }

            ViewBag.FirstChoiceOptionId = new SelectList(onlyActiveOptions(), "OptionId", "Title");
            ViewBag.SecondChoiceOptionId = new SelectList(onlyActiveOptions(), "OptionId", "Title");
            ViewBag.ThirdChoiceOptionId = new SelectList(onlyActiveOptions(), "OptionId", "Title");
            ViewBag.FourthChoiceOptionId = new SelectList(onlyActiveOptions(), "OptionId", "Title");

            Choice choice = new Choice();
            choice.StudentId = User.Identity.Name;

            return View(choice);
        }

        // POST: Choice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Student")]
        public async Task<ActionResult> Create([Bind(Include = "ChoiceId,YearTermId,StudentId,StudentFirstName,StudentLastName,FirstChoiceOptionId,SecondChoiceOptionId,ThirdChoiceOptionId,FourthChoiceOptionId,SelectionDate")] Choice choice)
        {
            choice.StudentId = choice.StudentId.ToUpper();

            if (User.IsInRole("Student"))
            {
                choice.StudentId = User.Identity.Name;
            }

            choice.SelectionDate = DateTime.Now;
            var defaultYearTerm = db.YearTerms
                                            .Where(y => y.IsDefault == true)
                                            .First();
            choice.YearTermId = defaultYearTerm.YearTermId;
            
            if (ModelState.IsValid)
            {
                db.Choices.Add(choice);
                await db.SaveChangesAsync();
                if(User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index");
                }else
                {
                    return RedirectToAction("Index", "Home");
                }

                
            }

            ViewBag.FirstChoiceOptionId = new SelectList(onlyActiveOptions(), "OptionId", "Title", choice.FirstChoiceOptionId);
            ViewBag.SecondChoiceOptionId = new SelectList(onlyActiveOptions(), "OptionId", "Title", choice.SecondChoiceOptionId);
            ViewBag.ThirdChoiceOptionId = new SelectList(onlyActiveOptions(), "OptionId", "Title", choice.ThirdChoiceOptionId);
            ViewBag.FourthChoiceOptionId = new SelectList(onlyActiveOptions(), "OptionId", "Title", choice.FourthChoiceOptionId);
            
            return View(choice);
        }

        // GET: Choice/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = await db.Choices.FindAsync(id);
            if (choice == null)
            {
                return HttpNotFound();
            }
            ViewBag.FirstChoiceOptionId = new SelectList(onlyActiveOptions(), "OptionId", "Title", choice.FirstChoiceOptionId);
            ViewBag.SecondChoiceOptionId = new SelectList(onlyActiveOptions(), "OptionId", "Title", choice.SecondChoiceOptionId);
            ViewBag.ThirdChoiceOptionId = new SelectList(onlyActiveOptions(), "OptionId", "Title", choice.ThirdChoiceOptionId);
            ViewBag.FourthChoiceOptionId = new SelectList(onlyActiveOptions(), "OptionId", "Title", choice.FourthChoiceOptionId);
            ViewBag.YearTermId = new SelectList(db.YearTerms, "YearTermId", "YearTermId", choice.YearTermId);
            return View(choice);
        }

        // POST: Choice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit([Bind(Include = "ChoiceId,YearTermId,StudentId,StudentFirstName,StudentLastName,FirstChoiceOptionId,SecondChoiceOptionId,ThirdChoiceOptionId,FourthChoiceOptionId,SelectionDate")] Choice choice)
        {
            choice.StudentId = choice.StudentId.ToUpper();
            if (ModelState.IsValid)
            {
                db.Entry(choice).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FirstChoiceOptionId = new SelectList(onlyActiveOptions(), "OptionId", "Title", choice.FirstChoiceOptionId);
            ViewBag.SecondChoiceOptionId = new SelectList(onlyActiveOptions(), "OptionId", "Title", choice.SecondChoiceOptionId);
            ViewBag.ThirdChoiceOptionId = new SelectList(onlyActiveOptions(), "OptionId", "Title", choice.ThirdChoiceOptionId);
            ViewBag.FourthChoiceOptionId = new SelectList(onlyActiveOptions(), "OptionId", "Title", choice.FourthChoiceOptionId);
            ViewBag.YearTermId = new SelectList(db.YearTerms, "YearTermId", "YearTermId", choice.YearTermId);
            return View(choice);
        }

        // GET: Choice/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Choice choice = await db.Choices.FindAsync(id);
            if (choice == null)
            {
                return HttpNotFound();
            }

            choice.Option1 = await db.Options.FindAsync(choice.FirstChoiceOptionId);
            choice.Option2 = await db.Options.FindAsync(choice.SecondChoiceOptionId);
            choice.Option3 = await db.Options.FindAsync(choice.ThirdChoiceOptionId);
            choice.Option4 = await db.Options.FindAsync(choice.FourthChoiceOptionId);

            return View(choice);
        }

        // POST: Choice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Choice choice = await db.Choices.FindAsync(id);
            db.Choices.Remove(choice);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        private List<Option> onlyActiveOptions()
        {
            return db.Options.Where(o => o.IsActive == true).ToList();
        }

    }
}
