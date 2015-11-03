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
    public class YearTermController : Controller
    {
        private DiplomaDataModelContext db = new DiplomaDataModelContext();

        // GET: YearTerm
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult> Index()
        {
            return View(await db.YearTerms.ToListAsync());
        }

        // GET: YearTerm/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearTerm yearTerm = await db.YearTerms.FindAsync(id);
            if (yearTerm == null)
            {
                return HttpNotFound();
            }

            ViewBag.TermFriendlyString = convertToFriendlyName(yearTerm.Term);
            return View(yearTerm);
        }

        // GET: YearTerm/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.FriendlyTerm = generatFriendlyTermList();
            return View();
        }

        // POST: YearTerm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create([Bind(Include = "YearTermId,Year,Term,IsDefault")] YearTerm yearTerm)
        {
            
            if (ModelState.IsValid)
            {

                if (yearTerm.IsDefault == true)
                {
                    List<YearTerm> defaultTerms = await db.YearTerms.Where(e => e.IsDefault == true).ToListAsync();
                    //ok if there is no default, we're probably going to set it anyway.
                    if (defaultTerms.Count != 0)
                    {
                        foreach(YearTerm term in defaultTerms)
                        {
                            term.IsDefault = false;
                        }
                    }
                }

                db.YearTerms.Add(yearTerm);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FriendlyTerm = generatFriendlyTermList();
            return View(yearTerm);
        }

        // GET: YearTerm/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearTerm yearTerm = await db.YearTerms.FindAsync(id);
            if (yearTerm == null)
            {
                return HttpNotFound();
            }
            ViewBag.FriendlyTerm = generatFriendlyTermList();
            return View(yearTerm);
        }

        // POST: YearTerm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit([Bind(Include = "YearTermId,Year,Term,IsDefault")] YearTerm yearTerm)
        {
            if (ModelState.IsValid)
            {
                if (yearTerm.IsDefault)
                {
                    YearTerm defaultTerm = await db.YearTerms.SingleOrDefaultAsync(e => e.IsDefault == true);

                    if (defaultTerm != null && defaultTerm.YearTermId != yearTerm.YearTermId)
                    {
                        defaultTerm.IsDefault = false;
                        db.Entry(yearTerm).State = EntityState.Modified;
                    }
                    //ok if there is no default, we're going to set to default anyway.
                }
                else
                {
                    YearTerm defaultTerm = await db.YearTerms.SingleOrDefaultAsync(e => e.IsDefault == true);

                    if (defaultTerm != null && defaultTerm.YearTermId == yearTerm.YearTermId)
                    {

                        YearTerm nonDefault = await db.YearTerms.Where(e => e.IsDefault == false).FirstOrDefaultAsync();
                        if (nonDefault != null)
                        {
                            db.Entry(defaultTerm).CurrentValues.SetValues(yearTerm);
                            nonDefault.IsDefault = true;
                        }
                    }
                }

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FriendlyTerm = generatFriendlyTermList();
            return View(yearTerm);
        }

        // GET: YearTerm/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearTerm yearTerm = await db.YearTerms.FindAsync(id);
            if (yearTerm == null)
            {
                return HttpNotFound();
            }

            ViewBag.TermFriendlyString = convertToFriendlyName(yearTerm.Term);

            return View(yearTerm);
        }

        // POST: YearTerm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            YearTerm yearTerm = await db.YearTerms.FindAsync(id);
            if (yearTerm.IsDefault)
            {
                YearTerm nonDefault = await db.YearTerms.Where(e => e.IsDefault == false).FirstOrDefaultAsync();
                if (nonDefault != null) {
                    nonDefault.IsDefault = true;
                }
            }
            
            db.YearTerms.Remove(yearTerm);
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

        private string convertToFriendlyName(int termCode)
        {
            string friendlyName;
            switch (termCode)
            {
                case 10:
                    friendlyName = "Winter";
                    break;
                case 20:
                    friendlyName = "Spring/Summer";
                    break;
                case 30:
                    friendlyName = "Fall";
                    break;
                default:
                    friendlyName = "BAD_TERM_CODE";
                    break;
            }
            return friendlyName;
        }

        private SelectList generatFriendlyTermList()
        {
            SelectList termList = new SelectList(
                new[]
                {
                new SelectListItem{ Text="Winter", Value="10", Selected = true },
                new SelectListItem{ Text="Spring/Summer", Value="20"},
                new SelectListItem{ Text="Fall", Value="30"}
                }, "Value", "Text", "2");

            return termList;
        }

    }
}
