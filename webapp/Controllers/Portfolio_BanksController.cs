using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartAdminMvc.Entity;

namespace SmartAdminMvc.Controllers
{
    [Authorize(Roles = "AppAdmin,Admin")]
    public class Portfolio_BanksController : Controller
    {
        private MiaRealEstateDb db = new MiaRealEstateDb();

        // GET: Portfolio_Banks
        public ActionResult Index()
        {
            return View(db.Portfolio_Banks.ToList());
        }
     
        // GET: Portfolio_Banks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Portfolio_Banks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Portfolio_Banks portfolio_Banks)
        {
            if (ModelState.IsValid)
            {
                portfolio_Banks.UpdateDate=DateTime.Now;
                db.Portfolio_Banks.Add(portfolio_Banks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portfolio_Banks);
        }

        // GET: Portfolio_Banks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_Banks portfolio_Banks = db.Portfolio_Banks.Find(id);
            if (portfolio_Banks == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_Banks);
        }

        // POST: Portfolio_Banks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Portfolio_Banks portfolio_Banks)
        {
            if (ModelState.IsValid)
            {
                portfolio_Banks.UpdateDate = DateTime.Now;
                db.Entry(portfolio_Banks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portfolio_Banks);
        }

        // GET: Portfolio_Banks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_Banks portfolio_Banks = db.Portfolio_Banks.Find(id);
            if (portfolio_Banks == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_Banks);
        }

        // POST: Portfolio_Banks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Portfolio_Banks portfolio_Banks = db.Portfolio_Banks.Find(id);
            db.Portfolio_Banks.Remove(portfolio_Banks);
            db.SaveChanges();
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
