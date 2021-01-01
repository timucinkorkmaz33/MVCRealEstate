using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartAdminMvc.Entity;
using SmartAdminMvc.Identity;
using SmartAdminMvc.ModelView;

namespace SmartAdminMvc.Controllers
{
    [Authorize]
    public class Portfolio_CustomerRequestController : Controller
    {
        private MiaRealEstateDb db = new MiaRealEstateDb();

        // GET: Portfolio_CustomerRequest
        public ActionResult Index()
        {
            var liste = from pcr in db.Portfilio_CustomerRequest
                        join pc in db.Portfolio_Customer on pcr.C_Id equals pc.Id into j1
                        from pc in j1.DefaultIfEmpty()
                        where (pcr.Status == "0")
                        select new CustomerModelView()
                        {
                             CustomerName= pc.Name+" "+pc.Surname,
                            cr_City = pcr.City,
                            cr_Country = pcr.Country,
                            cr_FinishDate = pcr.FinishDate,
                            cr_MaxPrice = pcr.MaxPrice,
                            cr_MinArea = pcr.MinArea
                         
                       
                        };
            return View(liste);
        }

        // GET: Portfolio_CustomerRequest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_CustomerRequest portfolio_CustomerRequest = db.Portfilio_CustomerRequest.Find(id);
            if (portfolio_CustomerRequest == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_CustomerRequest);
        }

        // GET: Portfolio_CustomerRequest/Create
        public ActionResult CustomerProcess(int? id)
        {
            AddItemDropDownList();
            if (id == null)
            {
             
                return View(); 
            }
            else
            {
                var sorgu = db.Portfilio_CustomerRequest.Where(x => x.Id == id).FirstOrDefault();
                CustomerModelView cusw=new CustomerModelView();
                cusw.cr_Land = sorgu.Land;
                cusw.cr_Office = sorgu.Office;
                cusw.cr_Status = sorgu.Status;
                cusw.cr_Transformation = sorgu.Transformation;
                cusw.cr_City = sorgu.City;
                cusw.cr_Country = sorgu.Country;
                cusw.cr_FinishDate = sorgu.FinishDate;
                cusw.cr_FloorChange = sorgu.FloorChange;
                cusw.cr_Housing = sorgu.Housing;
                cusw.cr_MaxArea = sorgu.MaxArea;
                cusw.cr_MaxPrice = sorgu.MaxPrice;
                cusw.cr_MinArea = sorgu.MinArea;
                cusw.cr_MinPrice = sorgu.MinPrice;
                cusw.cr_Note = sorgu.Note;
                cusw.c_Id = sorgu.C_Id;

                return View(cusw);
            }
            return View(); 
        }

        // POST: Portfolio_CustomerRequest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerProcess(CustomerModelView customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.Id == null)
                {
                    if (customer.c_Name == null && customer.c_Surname == null)
                    {
                        Portfolio_CustomerRequest pcus = new Portfolio_CustomerRequest();
                        pcus.City = customer.cr_City;
                        pcus.Country = customer.cr_Country;
                        pcus.FinishDate = customer.cr_FinishDate;
                        pcus.C_Id = customer.c_Id;
                        pcus.FloorChange = customer.cr_FloorChange;
                        pcus.Housing = customer.cr_Housing;
                        pcus.Land = customer.cr_Land;
                        pcus.MaxArea = customer.cr_MaxArea;
                        pcus.MinArea = customer.cr_MinArea;
                        pcus.MaxPrice = customer.cr_MaxPrice;
                        pcus.MinPrice = customer.cr_MinPrice;
                        pcus.Note = customer.cr_Note;
                        pcus.Status = customer.cr_Status;
                        pcus.Office = customer.cr_Office;
                        pcus.Transformation = customer.cr_Transformation;
                        db.Portfilio_CustomerRequest.Add(pcus);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Portfolio_Customer cus = new Portfolio_Customer();
                        cus.Name = customer.c_Name;
                        cus.Surname = customer.c_Surname;
                        cus.EMail = customer.c_EMail;
                        cus.Phone2 = customer.c_Phone2;
                        cus.Phone1 = customer.c_Phone1;
                        db.Portfolio_Customer.Add(cus);
                        db.SaveChanges();
                        var customerId =
                            db.Portfolio_Customer.Where(x => x.EMail == customer.c_EMail && x.Name == customer.c_Name
                                                             && x.Surname == customer.c_Surname)
                                .Select(x => x.Id)
                                .FirstOrDefault();

                        Portfolio_CustomerRequest pcus = new Portfolio_CustomerRequest();
                        pcus.City = customer.cr_City;
                        pcus.Country = customer.cr_Country;
                        pcus.FinishDate = customer.cr_FinishDate;
                        pcus.C_Id = customerId;
                        pcus.FloorChange = customer.cr_FloorChange;
                        pcus.Housing = customer.cr_Housing;
                        pcus.Land = customer.cr_Land;
                        pcus.MaxArea = customer.cr_MaxArea;
                        pcus.MinArea = customer.cr_MinArea;
                        pcus.MaxPrice = customer.cr_MaxPrice;
                        pcus.MinPrice = customer.cr_MinPrice;
                        pcus.Note = customer.cr_Note;
                        pcus.Status = customer.cr_Status;
                        pcus.Office = customer.cr_Office;
                        pcus.Transformation = customer.cr_Transformation;
                        db.Portfilio_CustomerRequest.Add(pcus);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    Portfolio_CustomerRequest pcus =
                        db.Portfilio_CustomerRequest.Where(x => x.Id == customer.Id).FirstOrDefault();
                    pcus.City = customer.cr_City;
                    pcus.Country = customer.cr_Country;
                    pcus.FinishDate = customer.cr_FinishDate;
                    pcus.C_Id = customer.c_Id;
                    pcus.FloorChange = customer.cr_FloorChange;
                    pcus.Housing = customer.cr_Housing;
                    pcus.Land = customer.cr_Land;
                    pcus.MaxArea = customer.cr_MaxArea;
                    pcus.MinArea = customer.cr_MinArea;
                    pcus.MaxPrice = customer.cr_MaxPrice;
                    pcus.MinPrice = customer.cr_MinPrice;
                    pcus.Note = customer.cr_Note;
                    pcus.Status= customer.cr_Status;
                    pcus.Office = customer.cr_Office;
                    pcus.Transformation = customer.cr_Transformation;
                    
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            AddItemDropDownList();
            return View(customer);
        }

        // GET: Portfolio_CustomerRequest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_CustomerRequest portfolio_CustomerRequest = db.Portfilio_CustomerRequest.Find(id);
            if (portfolio_CustomerRequest == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_CustomerRequest);
        }

        // POST: Portfolio_CustomerRequest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,C_Id,Type,FinishDate,Land,Housing,Office,Country,City,MinPrice,MaxPrice,MinArea,MaxArea,FloorChange,Transformation,Note")] Portfolio_CustomerRequest portfolio_CustomerRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portfolio_CustomerRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portfolio_CustomerRequest);
        }

        // GET: Portfolio_CustomerRequest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_CustomerRequest portfolio_CustomerRequest = db.Portfilio_CustomerRequest.Find(id);
            if (portfolio_CustomerRequest == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_CustomerRequest);
        }

        // POST: Portfolio_CustomerRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Portfolio_CustomerRequest portfolio_CustomerRequest = db.Portfilio_CustomerRequest.FirstOrDefault(x=>x.Id==id);
         portfolio_CustomerRequest.Status = "1";
            //  db.Portfilio_CustomerRequest.Remove(portfolio_CustomerRequest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        private void AddItemDropDownList()
        {
            var customer = db.Portfolio_Customer.ToList();
           
            List<SelectListItem> listcustomer = new List<SelectListItem>();

            if (customer != null)
            {
                foreach (Portfolio_Customer cus in customer)
                {

                    listcustomer.Add(new SelectListView
                    {
                        _Text = cus.Name + " " + cus.Surname,
                        _Value = cus.Id
                    });
                }

            }
            ViewBag.Customer = listcustomer;
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
