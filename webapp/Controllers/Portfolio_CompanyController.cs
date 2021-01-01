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
    public class Portfolio_CompanyController : Controller
    {
        private MiaRealEstateDb db = new MiaRealEstateDb();

        // GET: Portfolio_Company
        public ActionResult Index()
        {
            return View(db.Portfolio_Company.ToList());
        }

        // GET: Portfolio_Company/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_Company portfolio_Company = db.Portfolio_Company.Find(id);
            if (portfolio_Company == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_Company);
        }

        // GET: Portfolio_Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Portfolio_Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Company_Name,Company_Website,Company_Title,Company_Phone1,Company_Phone2,Company_EMail,Company_Address,Owner_NameSurname,Owner_Title,Owner_EMail,Owner_Phone,Owner_Phone2")] Portfolio_Company portfolio_Company)
        {
            if (ModelState.IsValid)
            {
                db.Portfolio_Company.Add(portfolio_Company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portfolio_Company);
        }

        // GET: Portfolio_Company/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_Company portfolio_Company = db.Portfolio_Company.Find(id);
            if (portfolio_Company == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_Company);
        }

        // POST: Portfolio_Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Company_Name,Company_Website,Company_Title,Company_Phone1,Company_Phone2,Company_EMail,Company_Address,Owner_NameSurname,Owner_Title,Owner_EMail,Owner_Phone,Owner_Phone2")] Portfolio_Company portfolio_Company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portfolio_Company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portfolio_Company);
        }

        // GET: Portfolio_Company/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_Company portfolio_Company = db.Portfolio_Company.Find(id);
            if (portfolio_Company == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_Company);
        }

        // POST: Portfolio_Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Portfolio_Company portfolio_Company = db.Portfolio_Company.Find(id);
            db.Portfolio_Company.Remove(portfolio_Company);
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
