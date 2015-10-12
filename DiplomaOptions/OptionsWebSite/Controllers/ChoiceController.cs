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
        [Authorize(Roles = "Admin")]
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
            return View(choice);
        }

        // GET: Choice/Create
        [Authorize(Roles = "Admin, Student")]
        public ActionResult Create()
        {
            ViewBag.FirstChoiceOptionId = new SelectList(db.Options, "OptionId", "Title");
            ViewBag.SecondChoiceOptionId = new SelectList(db.Options, "OptionId", "Title");
            ViewBag.ThirdChoiceOptionId = new SelectList(db.Options, "OptionId", "Title");
            ViewBag.FourthChoiceOptionId = new SelectList(db.Options, "OptionId", "Title");
            ViewBag.YearTermId = new SelectList(db.YearTerms, "YearTermId", "YearTermId");
            return View();
        }

        // POST: Choice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Student")]
        public async Task<ActionResult> Create([Bind(Include = "ChoiceId,YearTermId,StudentId,StudentFirstName,StudentLastName,FirstChoiceOptionId,SecondChoiceOptionId,ThirdChoiceOptionId,FourthChoiceOptionId,SelectionDate")] Choice choice)
        {
            if (ModelState.IsValid)
            {
                db.Choices.Add(choice);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FirstChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.FirstChoiceOptionId);
            ViewBag.SecondChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.SecondChoiceOptionId);
            ViewBag.ThirdChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.ThirdChoiceOptionId);
            ViewBag.FourthChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.FourthChoiceOptionId);
            ViewBag.YearTermId = new SelectList(db.YearTerms, "YearTermId", "YearTermId", choice.YearTermId);
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
            ViewBag.FirstChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.FirstChoiceOptionId);
            ViewBag.SecondChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.SecondChoiceOptionId);
            ViewBag.ThirdChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.ThirdChoiceOptionId);
            ViewBag.FourthChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.FourthChoiceOptionId);
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
            if (ModelState.IsValid)
            {
                db.Entry(choice).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FirstChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.FirstChoiceOptionId);
            ViewBag.SecondChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.SecondChoiceOptionId);
            ViewBag.ThirdChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.ThirdChoiceOptionId);
            ViewBag.FourthChoiceOptionId = new SelectList(db.Options, "OptionId", "Title", choice.FourthChoiceOptionId);
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
    }
}
