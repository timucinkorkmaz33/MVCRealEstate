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
    [Authorize]
    public class Portfolio_CustomerController : Controller
    {
        private MiaRealEstateDb db = new MiaRealEstateDb();

        // GET: Portfolio_Customer
        public ActionResult Index()
        {
            return View(db.Portfolio_Customer.ToList());
        }

        // GET: Portfolio_Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_Customer portfolio_Customer = db.Portfolio_Customer.Find(id);
            if (portfolio_Customer == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_Customer);
        }

        // GET: Portfolio_Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Portfolio_Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Portfolio_Customer portfolio_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Portfolio_Customer.Add(portfolio_Customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portfolio_Customer);
        }

        // GET: Portfolio_Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_Customer portfolio_Customer = db.Portfolio_Customer.Find(id);
            if (portfolio_Customer == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_Customer);
        }

        // POST: Portfolio_Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Portfolio_Customer portfolio_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portfolio_Customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portfolio_Customer);
        }

        // GET: Portfolio_Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_Customer portfolio_Customer = db.Portfolio_Customer.Find(id);
            if (portfolio_Customer == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_Customer);
        }

        // POST: Portfolio_Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Portfolio_Customer portfolio_Customer = db.Portfolio_Customer.Find(id);
            db.Portfolio_Customer.Remove(portfolio_Customer);
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
