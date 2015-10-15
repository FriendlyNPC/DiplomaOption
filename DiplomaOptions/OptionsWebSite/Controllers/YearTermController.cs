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
            
            return View(yearTerm);
        }

        // GET: YearTerm/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
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
                    YearTerm defaultTerm = await db.YearTerms.SingleOrDefaultAsync(e => e.IsDefault == true);
                    //ok if there is no default, we're probably going to set it anyway.
                    if (defaultTerm != null)
                    {
                        defaultTerm.IsDefault = false;

                        db.Entry(defaultTerm).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                    }
                }

                db.YearTerms.Add(yearTerm);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

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
                if (yearTerm.IsDefault == true)
                {
                    YearTerm defaultTerm = await db.YearTerms.SingleOrDefaultAsync(e => e.IsDefault == true);


                    if (defaultTerm != null)
                    {
                        defaultTerm.IsDefault = false;
                        db.Entry(defaultTerm).State = EntityState.Modified;
                        await db.SaveChangesAsync();
                    }
                    //ok if there is no default, we're going to set to default anyway.
                }
                

                db.Entry(yearTerm).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

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
            return View(yearTerm);
        }

        // POST: YearTerm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            YearTerm yearTerm = await db.YearTerms.FindAsync(id);
            //if (yearTerm.IsDefault == true)
            //{
            //    YearTerm lastNonDefaultTerm = await db.YearTerms.FirstOrDefaultAsync(e => e.IsDefault == false);

            //    if (lastNonDefaultTerm != null)
            //    {
            //        lastNonDefaultTerm.IsDefault = true;
            //        db.Entry(lastNonDefaultTerm).State = EntityState.Modified;
            //        await db.SaveChangesAsync();
            //    }
            //}

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


    }
}
