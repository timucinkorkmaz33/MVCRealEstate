using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SmartAdminMvc.Entity;
using SmartAdminMvc.Identity;
using SmartAdminMvc.ModelView;

namespace SmartAdminMvc.Controllers
{
    [Authorize(Roles = "AppAdmin,Admin")]
    public class Portfolio_PersonalController : Controller
    {
       
        MiaRealEstateDb db = new MiaRealEstateDb();
        private UserManager<ApplicationUser> userManager;

        private RoleManager<ApplicationRole> roleManager;
        public Portfolio_PersonalController()
        {
            MiaRealEstateDb db = new MiaRealEstateDb();
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            userManager = new UserManager<ApplicationUser>(userStore);
            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(db);
            roleManager = new RoleManager<ApplicationRole>(roleStore);
           // IQueryable<Account> xx = db.Account.Select(x => x);
        }


        // GET: Portfolio_Personal
        public ActionResult Index()
        {
            return View(db.Portfolio_Personal.ToList());
        }

       
        // GET: Portfolio_Personal/Create
        public ActionResult Create()
        {
            AddItemDropDownList();
            
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Portfolio_Personal portfolio_Personal, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                var path = "";

                if (Image != null)
                {

                    if (Image.ContentLength > 0)
                    {

                        //for checking uploaded file is image or not

                        if (Path.GetExtension(Image.FileName).ToLower() == ".jpg"

                            || Path.GetExtension(Image.FileName).ToLower() == ".png"

                          || Path.GetExtension(Image.FileName).ToLower() == ".gif"

                            || Path.GetExtension(Image.FileName).ToLower() == ".jpeg")
                        {
                            
                            path = Path.Combine(Server.MapPath("~/UploadImage/Personal"), Image.FileName);

                            Image.SaveAs(path);

                            ViewBag.UploadSuccess = true;

                        }

                    }

                }
               
                Portfolio_Personal personal = new Portfolio_Personal();
                personal.Image = "/UploadImage/Personal/" + Image.FileName;
                personal.Name = portfolio_Personal.Name;
                personal.Surname = portfolio_Personal.Surname;
                personal.Phone1 = portfolio_Personal.Phone1;
                personal.Phone2 = portfolio_Personal.Phone2;
                personal.BirthDate = portfolio_Personal.BirthDate;
                personal.BirthPlace = portfolio_Personal.BirthPlace;
                personal.Driving_Licence = portfolio_Personal.Driving_Licence;
                personal.Address = portfolio_Personal.Address;
                personal.TC = portfolio_Personal.TC;
                personal.Department = portfolio_Personal.Department;
                personal.UserId = portfolio_Personal.UserId;

                db.Portfolio_Personal.Add(personal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(portfolio_Personal);
        }

        // GET: Portfolio_Personal/Edit/5
        public ActionResult Edit(int? id)
        {
            AddItemDropDownList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_Personal portfolio_Personal = db.Portfolio_Personal.Find(id);
            if (portfolio_Personal == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_Personal);
        }

        // POST: Portfolio_Personal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Portfolio_Personal portfolio_Personal, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                var path = "";
                Portfolio_Personal personal = db.Portfolio_Personal.Where(u => u.Id == portfolio_Personal.Id).FirstOrDefault();
                if (Image != null)
                {

                    if (Image.ContentLength > 0)
                    {

                        //for checking uploaded file is image or not

                        if (Path.GetExtension(Image.FileName).ToLower() == ".jpg"

                            || Path.GetExtension(Image.FileName).ToLower() == ".png"

                          || Path.GetExtension(Image.FileName).ToLower() == ".gif"

                            || Path.GetExtension(Image.FileName).ToLower() == ".jpeg")
                        {

                            path = Path.Combine(Server.MapPath("~/UploadImage"), Image.FileName);

                            Image.SaveAs(path);

                            ViewBag.UploadSuccess = true;
                            personal.Image = "/UploadImage/Personal/" + Image.FileName;
                        }

                    }

                }
              
               // personal.Id = portfolio_Personal.Id;
               
                personal.Name = portfolio_Personal.Name;
                personal.Surname = portfolio_Personal.Surname;
                personal.Phone1 = portfolio_Personal.Phone1;
                personal.Phone2 = portfolio_Personal.Phone2;
                personal.BirthDate = portfolio_Personal.BirthDate;
                personal.BirthPlace = portfolio_Personal.BirthPlace;
                personal.Driving_Licence = portfolio_Personal.Driving_Licence;
                personal.Address = portfolio_Personal.Address;
                personal.TC = portfolio_Personal.TC;
                personal.Department = portfolio_Personal.Department;

               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portfolio_Personal);
        }

        // GET: Portfolio_Personal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_Personal portfolio_Personal = db.Portfolio_Personal.Find(id);
            if (portfolio_Personal == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_Personal);
        }

        // POST: Portfolio_Personal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Portfolio_Personal portfolio_Personal = db.Portfolio_Personal.Find(id);
            db.Portfolio_Personal.Remove(portfolio_Personal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void AddItemDropDownList()
        {

            var kullanici = userManager.Users.Where(x =>x.UserName!="mia").ToList();
            var deneme =roleManager.Roles.Select(a=>userManager.Users.Where(x => x.Name!="mia")).ToList();


            List<SelectListItem> personel = new List<SelectListItem>();

            if (kullanici != null)
            {
                foreach (ApplicationUser person in kullanici)
                {
                    personel.Add(new SelectListView
                    {
                        _Text = person.Name+" "+person.Surname,
                        _strValue = person.Id
                    });
                }

            }
            ViewBag.Personel = personel;
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
