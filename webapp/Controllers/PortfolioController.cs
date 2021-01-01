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
    [Authorize]
    public class PortfolioController : Controller
    {
        private MiaRealEstateDb db = new MiaRealEstateDb();
        private UserManager<ApplicationUser> userManager;

        private RoleManager<ApplicationRole> roleManager;
        public PortfolioController()
        {
            MiaRealEstateDb db = new MiaRealEstateDb();
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            userManager = new UserManager<ApplicationUser>(userStore);
            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(db);
            roleManager = new RoleManager<ApplicationRole>(roleStore);
            // IQueryable<Account> xx = db.Account.Select(x => x);
        }
        // GET: Portfolio
        public ActionResult Index()
        {
            //List<Portfolio_General> liste=new List<Portfolio_General>();
            var liste = from pg in db.Portfolio_General
                        join pp in db.Portfolio_Personal on pg.Personal_Id equals pp.UserId into j1
                        from pp in j1.DefaultIfEmpty()
                        join pa in db.Portfolio_Address on pg.Id equals pa.Pg_Id into j2
                        from pa in j2.DefaultIfEmpty()
                        join pcus in db.Portfolio_Customer on pg.Customer_Id equals pcus.Id into j3
                        from pcus in j3.DefaultIfEmpty()
                        join pd in db.Portfolio_Detail on pg.Id equals pd.Pg_Id into j4
                        from pd in j4.DefaultIfEmpty()
                        join pc in db.Portfolio_Contract on pg.Contract_Id equals pc.Id into j5
                        from pc in j5.DefaultIfEmpty()
                        where (pg.Status == 0)
                        select new PortfolioModelView()
                        {
                            pg_Personal_Id = pp.Name + " " + pp.Surname,
                            pg_Header = pg.Header,
                            Id = pg.Id,
                            pa_District = pa.District,
                            pa_City = pa.City,
                            pcus_Name = pcus.Name + " " + pcus.Surname,
                            pg_Type = pg.Type,
                            pd_Status = pd.Status,
                            pc_MinPrice = pc.MinPrice,
                            pc_MaxPrice = pc.MaxPrice,
                            pg_Type_State = pg.Type_State,
                            Ev_Durumu = pd.Room_Number+"+"+pd.Saloon_Number

                        };


            return View(liste);
        }

        // GET: Portfolio/Create
        public ActionResult PortfolioProcess(int? id)
        {
            AddItemDropDownList();
            if (id != null)
            {
                var sorgugeneral = db.Portfolio_General.FirstOrDefault(x => x.Id == id);
                var sorguaddress = db.Portfolio_Address.FirstOrDefault(x => x.Pg_Id == id);
                var sorgudetail = db.Portfolio_Detail.FirstOrDefault(x => x.Pg_Id == id);
                var sorguextra = db.Portfolio_ExtraDetail.FirstOrDefault(x => x.Pg_Id == id);
                var sorgucustomer = db.Portfolio_Customer.FirstOrDefault(x => x.Id == sorgugeneral.Customer_Id);
                var sorgucontract = db.Portfolio_Contract.FirstOrDefault(x => x.Id == sorgugeneral.Contract_Id);
                PortfolioModelView portfoliomodel = new PortfolioModelView();
                portfoliomodel.Id = id;
                portfoliomodel.pg_Contract_Id = sorgugeneral.Contract_Id;
                portfoliomodel.pg_Date = sorgugeneral.Date;
                portfoliomodel.pg_Comment = sorgugeneral.Comment;
                portfoliomodel.pg_Area_Brut = sorgugeneral.Area_Brut;
                portfoliomodel.pg_Area_Net = sorgugeneral.Area_Net;
                portfoliomodel.pg_Credit = sorgugeneral.Credit;
                portfoliomodel.pg_Description = sorgugeneral.Description;
                portfoliomodel.pg_Customer_Id = sorgugeneral.Customer_Id;
                portfoliomodel.pg_Header = sorgugeneral.Header;
                portfoliomodel.pg_Personal_Id = sorgugeneral.Personal_Id;
                portfoliomodel.pg_Price = sorgugeneral.Price;
                portfoliomodel.pg_Price_Type = sorgugeneral.Price_Type;
                portfoliomodel.pg_Subscription = sorgugeneral.Subscription;
                portfoliomodel.pg_Type = sorgugeneral.Type;
                portfoliomodel.pg_Type_State = sorgugeneral.Type_State;
                portfoliomodel.pg_Contract_Id = sorgugeneral.Contract_Id;

                portfoliomodel.pa_Latitude = sorguaddress.Latitude;
                portfoliomodel.pa_Address = sorguaddress.Address;
                portfoliomodel.pa_City = sorguaddress.City;
                portfoliomodel.pa_Country = sorguaddress.Country;
                portfoliomodel.pa_District = sorguaddress.District;
                portfoliomodel.pa_Id = sorguaddress.Pg_Id;
                portfoliomodel.pa_Longitude = sorguaddress.Longitude;
                portfoliomodel.pa_Site_Name = sorguaddress.Site_Name;

                portfoliomodel.pd_Status = sorgudetail.Status;
                portfoliomodel.pd_Balcony_Number = sorgudetail.Balcony_Number;
                portfoliomodel.pd_Bathroom_Number = sorgudetail.Bathroom_Number;
                portfoliomodel.pd_Building_Age = sorgudetail.Building_Age;
                portfoliomodel.pd_Building_Floor = sorgudetail.Building_Floor;
                portfoliomodel.pd_Floor = sorgudetail.Floor;
                portfoliomodel.pd_Floor_Change = sorgudetail.Floor_Change;
                portfoliomodel.pd_Heating = sorgudetail.Heating;
                portfoliomodel.pd_Id = sorgudetail.Pg_Id;
                portfoliomodel.pd_Image = sorgudetail.Image;
                portfoliomodel.pd_Room_Number = sorgudetail.Room_Number;
                portfoliomodel.pd_Saloon_Number = sorgudetail.Saloon_Number;
                portfoliomodel.pd_Balcony_Number = sorgudetail.Room_Number;
                portfoliomodel.pd_Status = sorgudetail.Status;

                portfoliomodel.pe_Fire_Alarm = sorguextra.Fire_Alarm;
                portfoliomodel.pe_Adsl = sorguextra.Adsl;
                portfoliomodel.pe_Cable_tv = sorguextra.Cable_tv;
                portfoliomodel.pe_Camera = sorguextra.Camera;
                portfoliomodel.pe_Child_Park = sorguextra.Child_Park;
                portfoliomodel.pe_City = sorguextra.City;
                portfoliomodel.pe_East = sorguextra.East;
                portfoliomodel.pe_Elevator = sorguextra.Elevator;
                portfoliomodel.pe_Fax = sorguextra.Fax;
                portfoliomodel.pe_Fiber = sorguextra.Fiber;
                portfoliomodel.pe_Fire_Stairs = sorguextra.Fire_Stairs;
                portfoliomodel.pe_Garage = sorguextra.Garage;
                portfoliomodel.pe_Garden = sorguextra.Garden;
                portfoliomodel.pe_Generator = sorguextra.Generator;
                portfoliomodel.pe_Id = sorguextra.Pg_Id;
                portfoliomodel.pe_Lake = sorguextra.Lake;
                portfoliomodel.pe_Mountain = sorguextra.Mountain;
                portfoliomodel.pe_Nature = sorguextra.Nature;
                portfoliomodel.pe_North = sorguextra.North;
                portfoliomodel.pe_Phone = sorguextra.Phone;
                portfoliomodel.pe_Pool = sorguextra.Pool;
                portfoliomodel.pe_Satellite = sorguextra.Satellite;
                portfoliomodel.pe_Sea = sorguextra.Sea;
                portfoliomodel.pe_Securityman = sorguextra.Securityman;
                portfoliomodel.pe_Sourth = sorguextra.Sourth;
                portfoliomodel.pe_Throat = sorguextra.Throat;
                portfoliomodel.pe_West = sorguextra.West;
                portfoliomodel.pe_WiFi = sorguextra.WiFi;
                portfoliomodel.pe_Thief_Alarm = sorguextra.Thief_Alarm;
                portfoliomodel.pg_Date = sorgugeneral.Date;
                portfoliomodel.pp_Source =
                    db.Portfolio_Personal.Where(x => x.UserId == portfoliomodel.pg_Personal_Id).Select(x => x.Name).FirstOrDefault() + " " +
                    db.Portfolio_Personal.Where(x => x.UserId == portfoliomodel.pg_Personal_Id).Select(x => x.Surname).FirstOrDefault();

                //portfoliomodel.pcus_Name = sorgucustomer.Name;
                //portfoliomodel.pcus_Surname = sorgucustomer.Surname;
                //portfoliomodel.pcus_EMail = sorgucustomer.EMail;
                //portfoliomodel.pcus_Phone1 = sorgucustomer.Phone1;
                //portfoliomodel.pcus_Id = sorgucustomer.Pg_Id;

                portfoliomodel.pc_StartDate = sorgucontract.StartDate;
                portfoliomodel.pc_FinishDate = sorgucontract.FinishDate;
                portfoliomodel.pc_Buyer_Rate = sorgucontract.Buyer_Rate;
                portfoliomodel.pc_Seller_Rate = sorgucontract.Seller_Rate;
                portfoliomodel.pc_MinPrice = sorgucontract.MinPrice;
                portfoliomodel.pc_MaxPrice = sorgucontract.MaxPrice;
                portfoliomodel.pc_Buyer_ServicePrice = sorgucontract.Buyer_ServicePrice;
                portfoliomodel.pc_Seller_ServicePrice = sorgucontract.Seller_ServicePrice;
                portfoliomodel.pc_ContractNumber = sorgucontract.ContractNumber;

                return View(portfoliomodel);
            }
            else
            {
                PortfolioModelView portfoliomodel = new PortfolioModelView();
                portfoliomodel.pg_Date = DateTime.Now;
                portfoliomodel.pg_Personal_Id = User.Identity.GetUserId();
                string userid = User.Identity.GetUserId();
                var sorgu = db.Portfolio_Personal.Where(x => x.UserId == userid).FirstOrDefault();
                if (sorgu == null)
                {
                    return RedirectToAction("Index", "Portfolio_Personal");
                }
                portfoliomodel.pc_StartDate=DateTime.Now;
                portfoliomodel.pc_FinishDate =DateTime.Now.AddDays(1);
                portfoliomodel.pp_Source =
                    db.Portfolio_Personal.Where(x => x.UserId == portfoliomodel.pg_Personal_Id).Select(x => x.Name).FirstOrDefault() + " " +
                    db.Portfolio_Personal.Where(x => x.UserId == portfoliomodel.pg_Personal_Id).Select(x => x.Surname).FirstOrDefault();
                return View(portfoliomodel);
            }
            return View();

        }


        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public ActionResult PortfolioProcess(PortfolioModelView portfoliomodel, IEnumerable<HttpPostedFileBase> pd_Image, IEnumerable<HttpPostedFileBase> pc_AuthorityDocument)//Veriler list şeklinde gonderilecek alınırken bölüm bölüm alınıp ilgili tabloya kayıt yapılacak
        {
            if (ModelState.IsValid)
            {
                if (portfoliomodel.Id == null)
                {
                    //var personal_id =
                    //    db.Portfolio_Personal.Where(
                    //            x => x.Name == portfoliomodel.pp_Source)
                    //        .Select(x => x.Id)
                    //        .FirstOrDefault();
                    //Yeni portföy kayıdı

                    if (portfoliomodel.pcus_Surname != null && portfoliomodel.pcus_Name != null)
                    {

                        Portfolio_Customer pcus = new Portfolio_Customer();
                        pcus.EMail = portfoliomodel.pcus_EMail;
                        pcus.Name = portfoliomodel.pcus_Name;
                        pcus.Surname = portfoliomodel.pcus_Surname;
                        pcus.Phone1 = portfoliomodel.pcus_Phone1;
                        pcus.Seller = true;
                        db.Portfolio_Customer.Add(pcus);
                        db.SaveChanges();
                        var sorgu =
                            db.Portfolio_Customer.FirstOrDefault(
                                x => x.Name == portfoliomodel.pcus_Name && x.EMail == portfoliomodel.pcus_EMail).Id;

                        portfoliomodel.pg_Customer_Id = sorgu;
                    }
                    Portfolio_Contract pc = new Portfolio_Contract();
                    //pc.Pg_Id = pg_Id;
                    pc.StartDate = portfoliomodel.pc_StartDate;
                    pc.FinishDate = portfoliomodel.pc_FinishDate;
                    pc.Buyer_Rate = portfoliomodel.pc_Buyer_Rate;
                    pc.Seller_Rate = portfoliomodel.pc_Seller_Rate;
                    pc.MinPrice = portfoliomodel.pc_MinPrice;
                    pc.MaxPrice = portfoliomodel.pc_MaxPrice;
                    pc.Buyer_ServicePrice = portfoliomodel.pc_Buyer_ServicePrice;
                    pc.Seller_ServicePrice = portfoliomodel.pc_Seller_ServicePrice;
                    pc.ContractNumber = portfoliomodel.pc_ContractNumber;
                    string path = Server.MapPath("~/UploadImage/" + portfoliomodel.pg_Header);
                    Directory.CreateDirectory(path);
                    if (portfoliomodel.pc_AuthorityDocument != null)
                    {
                        foreach (var file in pc_AuthorityDocument)
                        {
                            if (file.ContentLength > 0)
                            {

                                var filename = Path.GetFileName(file.FileName);
                                var kayityeri = Path.Combine(path, filename);
                                pc.AuthorityDocument += "/UploadImage/" + portfoliomodel.pg_Header + " " + filename + ", ";
                                file.SaveAs(kayityeri);
                            }
                        }
                    }
                    
                    db.Portfolio_Contract.Add(pc);
                    db.SaveChanges();
                    var contractId = db.Portfolio_Contract.Where(
                            x => x.ContractNumber == pc.ContractNumber && x.Buyer_ServicePrice == pc.Buyer_ServicePrice &&
                                x.FinishDate == pc.FinishDate).Select(x => x.Id).FirstOrDefault();
                    portfoliomodel.pg_Contract_Id = contractId;

                    Portfolio_General pg = new Portfolio_General();
                    pg.Type_State = portfoliomodel.pg_Type_State;
                    pg.Area_Brut = portfoliomodel.pg_Area_Brut;
                    pg.Status = 0;
                    pg.Contract_Id = portfoliomodel.pg_Contract_Id;
                    pg.Area_Net = portfoliomodel.pg_Area_Net;
                    pg.Comment = portfoliomodel.pg_Comment;
                    pg.Credit = portfoliomodel.pg_Credit;
                    pg.Description = portfoliomodel.pg_Description;
                    pg.Header = portfoliomodel.pg_Header;
                    pg.Personal_Id = User.Identity.GetUserId();
                    pg.Price = portfoliomodel.pg_Price;
                    pg.Date = portfoliomodel.pg_Date;
                    pg.Type = portfoliomodel.pg_Type;
                    pg.Subscription = portfoliomodel.pg_Subscription;
                    pg.Price_Type = portfoliomodel.pg_Price_Type;
                    pg.Customer_Id = portfoliomodel.pg_Customer_Id;
                    db.Portfolio_General.Add(pg);
                    db.SaveChanges();
                    var pg_Id =
                        db.Portfolio_General.Where(
                                x => x.Comment == portfoliomodel.pg_Comment && x.Header == portfoliomodel.pg_Header)
                            .Select(x => x.Id).FirstOrDefault();

                    Portfolio_Detail pd = new Portfolio_Detail();
                    pd.Balcony_Number = portfoliomodel.pd_Balcony_Number;
                    pd.Bathroom_Number = portfoliomodel.pd_Bathroom_Number;
                    pd.Building_Age = portfoliomodel.pd_Building_Age;
                    pd.Building_Floor = portfoliomodel.pd_Building_Floor;
                    pd.Floor = portfoliomodel.pd_Floor;
                    pd.Floor_Change = portfoliomodel.pd_Floor_Change;

                    pd.Heating = portfoliomodel.pd_Heating;

                    pd.Room_Number = portfoliomodel.pd_Room_Number;
                    pd.Saloon_Number = portfoliomodel.pd_Saloon_Number;
                    pd.Status = portfoliomodel.pd_Status;
                    pd.Pg_Id = pg_Id;
                     path = Server.MapPath("~/UploadImage/" + portfoliomodel.pg_Header);
                    Directory.CreateDirectory(path);
                    if (portfoliomodel.pd_Image != null)
                    {
                        foreach (var file in pd_Image)
                        {
                            if (file.ContentLength > 0)
                            {

                                var filename = Path.GetFileName(file.FileName);
                                var kayityeri = Path.Combine(path, filename);
                                pd.Image += "/UploadImage/" + portfoliomodel.pg_Header + " " + filename + ", ";
                                file.SaveAs(kayityeri);
                            }
                        }
                    }
                    db.Portfolio_Detail.Add(pd);
                    db.SaveChanges();

                    Portfolio_Address pa = new Portfolio_Address();
                    pa.Address = portfoliomodel.pa_Address;
                    pa.City = portfoliomodel.pa_City;
                    pa.Country = portfoliomodel.pa_Country;
                    pa.District = portfoliomodel.pa_District;
                    pa.Latitude = portfoliomodel.pa_Latitude;
                    pa.Longitude = portfoliomodel.pa_Longitude;
                    pa.Pg_Id = pg_Id;
                    pa.Site_Name = portfoliomodel.pa_Site_Name;
                    db.Portfolio_Address.Add(pa);
                    db.SaveChanges();

                    Portfolio_ExtraDetail pe = new Portfolio_ExtraDetail();
                    pe.Pg_Id = pg_Id;
                    pe.North = portfoliomodel.pe_North;
                    pe.Sourth = portfoliomodel.pe_Sourth;
                    pe.East = portfoliomodel.pe_East;
                    pe.West = portfoliomodel.pe_West;
                    pe.Fiber = portfoliomodel.pe_Fiber;
                    pe.Satellite = portfoliomodel.pe_Satellite;
                    pe.Cable_tv = portfoliomodel.pe_Cable_tv;
                    pe.Adsl = portfoliomodel.pe_Adsl;
                    pe.Fax = portfoliomodel.pe_Fax;
                    pe.Phone = portfoliomodel.pe_Phone;
                    pe.WiFi = portfoliomodel.pe_WiFi;
                    pe.Elevator = portfoliomodel.pe_Elevator;
                    pe.Pool = portfoliomodel.pe_Pool;
                    pe.Child_Park = portfoliomodel.pe_Child_Park;
                    pe.Garage = portfoliomodel.pe_Garage;
                    pe.Garden = portfoliomodel.pe_Garden;
                    pe.Fire_Stairs = portfoliomodel.pe_Fire_Stairs;
                    pe.Securityman = portfoliomodel.pe_Securityman;
                    pe.Generator = portfoliomodel.pe_Generator;
                    pe.Camera = portfoliomodel.pe_Camera;
                    pe.Fire_Alarm = portfoliomodel.pe_Fire_Alarm;
                    pe.Thief_Alarm = portfoliomodel.pe_Thief_Alarm;
                    pe.Sea = portfoliomodel.pe_Sea;
                    pe.Throat = portfoliomodel.pe_Throat;
                    pe.Mountain = portfoliomodel.pe_Mountain;
                    pe.City = portfoliomodel.pe_City;
                    pe.Nature = portfoliomodel.pe_Nature;
                    pe.Lake = portfoliomodel.pe_Lake;

                    db.Portfolio_ExtraDetail.Add(pe);
                    db.SaveChanges();



                    return RedirectToAction("Index", "Portfolio");


                }
                else
                {
                    //Bu kısım güncelleme kısmı olacak 
                    if (portfoliomodel.pcus_Surname != null && portfoliomodel.pcus_Name != null)
                    {

                        Portfolio_Customer pcus = new Portfolio_Customer();
                        pcus.EMail = portfoliomodel.pcus_EMail;
                        pcus.Name = portfoliomodel.pcus_Name;
                        pcus.Surname = portfoliomodel.pcus_Surname;
                        pcus.Phone1 = portfoliomodel.pcus_Phone1;
                        pcus.Seller = true;
                        db.Portfolio_Customer.Add(pcus);
                        db.SaveChanges();
                        var sorgu =
                            db.Portfolio_Customer.Where(
                                x => x.Name == portfoliomodel.pcus_Name && x.EMail == portfoliomodel.pcus_EMail).Select(x => x.Id).FirstOrDefault();

                        portfoliomodel.pg_Customer_Id = sorgu;
                    }

                    Portfolio_General pg = db.Portfolio_General.FirstOrDefault(x => x.Id == portfoliomodel.Id);
                    pg.Type_State = portfoliomodel.pg_Type_State;
                    pg.Area_Brut = portfoliomodel.pg_Area_Brut;
                    pg.Area_Net = portfoliomodel.pg_Area_Net;
                    pg.Comment = portfoliomodel.pg_Comment;
                    pg.Credit = portfoliomodel.pg_Credit;
                    pg.Description = portfoliomodel.pg_Description;
                    pg.Header = portfoliomodel.pg_Header;
                    pg.Personal_Id = portfoliomodel.pg_Personal_Id;
                    pg.Price = portfoliomodel.pg_Price;
                    pg.Type = portfoliomodel.pg_Type;
                    pg.Customer_Id = portfoliomodel.pg_Customer_Id;
                    pg.Subscription = portfoliomodel.pg_Subscription;
                    pg.Price_Type = portfoliomodel.pg_Price_Type;
                    db.SaveChanges();
                    //var pg_Id =
                    //    db.Portfolio_General.Where(
                    //            x => x.Comment == portfoliomodel.pg_Comment && x.Header == portfoliomodel.pg_Header)
                    //        .Select(x => x.Id).FirstOrDefault();

                    Portfolio_Detail pd = db.Portfolio_Detail.Where(x => x.Pg_Id == portfoliomodel.Id).FirstOrDefault();
                    pd.Balcony_Number = portfoliomodel.pd_Balcony_Number;
                    pd.Bathroom_Number = portfoliomodel.pd_Bathroom_Number;
                    pd.Building_Age = portfoliomodel.pd_Building_Age;
                    pd.Building_Floor = portfoliomodel.pd_Building_Floor;
                    pd.Floor = portfoliomodel.pd_Floor;
                    pd.Floor_Change = portfoliomodel.pd_Floor_Change;

                    pd.Heating = portfoliomodel.pd_Heating;
                    pd.Room_Number = portfoliomodel.pd_Room_Number;
                    pd.Saloon_Number = portfoliomodel.pd_Saloon_Number;
                    pd.Status = portfoliomodel.pd_Status;
                    string path = Server.MapPath("~/UploadImage/" + portfoliomodel.pg_Header);
                    Directory.CreateDirectory(path);
                    if (portfoliomodel.pd_Image != null)
                    {
                        foreach (var file in pd_Image)
                        {
                            if (file.ContentLength > 0)
                            {

                                var filename = Path.GetFileName(file.FileName);
                                var kayityeri = Path.Combine(path, filename);
                                pd.Image += "/UploadImage/" + portfoliomodel.pg_Header + "/" + filename + ";";
                                file.SaveAs(kayityeri);
                            }
                        }
                    }


                    //pd.Pg_Id = portfoliomodel.Id;
                    db.SaveChanges();

                    Portfolio_Address pa = db.Portfolio_Address.Where(x => x.Pg_Id == portfoliomodel.Id).FirstOrDefault();
                    pa.Address = portfoliomodel.pa_Address;
                    pa.City = portfoliomodel.pa_City;
                    pa.Country = portfoliomodel.pa_Country;
                    pa.District = portfoliomodel.pa_District;
                    pa.Latitude = portfoliomodel.pa_Latitude;
                    pa.Longitude = portfoliomodel.pa_Longitude;
                    //pa.Pg_Id = portfoliomodel.pa_Id;
                    pa.Site_Name = portfoliomodel.pa_Site_Name;
                    db.SaveChanges();

                    Portfolio_ExtraDetail pe = db.Portfolio_ExtraDetail.Where(x => x.Pg_Id == portfoliomodel.Id).FirstOrDefault();
                    // pe.Pg_Id = portfoliomodel.pe_Id;
                    pe.North = portfoliomodel.pe_North;
                    pe.Sourth = portfoliomodel.pe_Sourth;
                    pe.East = portfoliomodel.pe_East;
                    pe.West = portfoliomodel.pe_West;
                    pe.Fiber = portfoliomodel.pe_Fiber;
                    pe.Satellite = portfoliomodel.pe_Satellite;
                    pe.Cable_tv = portfoliomodel.pe_Cable_tv;
                    pe.Adsl = portfoliomodel.pe_Adsl;
                    pe.Fax = portfoliomodel.pe_Fax;
                    pe.Phone = portfoliomodel.pe_Phone;
                    pe.WiFi = portfoliomodel.pe_WiFi;
                    pe.Elevator = portfoliomodel.pe_Elevator;
                    pe.Pool = portfoliomodel.pe_Pool;
                    pe.Child_Park = portfoliomodel.pe_Child_Park;
                    pe.Garage = portfoliomodel.pe_Garage;
                    pe.Garden = portfoliomodel.pe_Garden;
                    pe.Fire_Stairs = portfoliomodel.pe_Fire_Stairs;
                    pe.Securityman = portfoliomodel.pe_Securityman;
                    pe.Generator = portfoliomodel.pe_Generator;
                    pe.Camera = portfoliomodel.pe_Camera;
                    pe.Fire_Alarm = portfoliomodel.pe_Fire_Alarm;
                    pe.Thief_Alarm = portfoliomodel.pe_Thief_Alarm;
                    pe.Sea = portfoliomodel.pe_Sea;
                    pe.Throat = portfoliomodel.pe_Throat;
                    pe.Mountain = portfoliomodel.pe_Mountain;
                    pe.City = portfoliomodel.pe_City;
                    pe.Nature = portfoliomodel.pe_Nature;
                    pe.Lake = portfoliomodel.pe_Lake;

                    db.SaveChanges();

                    Portfolio_Contract pc = db.Portfolio_Contract.FirstOrDefault(x => x.Id == portfoliomodel.pg_Contract_Id);
                    pc.StartDate = portfoliomodel.pc_StartDate;
                    pc.FinishDate = portfoliomodel.pc_FinishDate;
                    pc.Buyer_Rate = portfoliomodel.pc_Buyer_Rate;
                    pc.Seller_Rate = portfoliomodel.pc_Seller_Rate;
                    pc.MinPrice = portfoliomodel.pc_MinPrice;
                    pc.MaxPrice = portfoliomodel.pc_MaxPrice;
                    pc.Buyer_ServicePrice = portfoliomodel.pc_Buyer_ServicePrice;
                    pc.Seller_ServicePrice = portfoliomodel.pc_Seller_ServicePrice;
                    pc.ContractNumber = portfoliomodel.pc_ContractNumber;
                     path = Server.MapPath("~/UploadImage/" + portfoliomodel.pg_Header);
                    Directory.CreateDirectory(path);
                    if (portfoliomodel.pc_AuthorityDocument != null)
                    {
                        foreach (var file in pc_AuthorityDocument)
                        {
                            if (file.ContentLength > 0)
                            {

                                var filename = Path.GetFileName(file.FileName);
                                var kayityeri = Path.Combine(path, filename);
                                pc.AuthorityDocument += "/UploadImage/" + portfoliomodel.pg_Header + " " + filename + ", ";
                                file.SaveAs(kayityeri);
                            }
                        }
                    }
                    db.SaveChanges();

                    return RedirectToAction("Index", "Portfolio");
                }
            }

            return View(portfoliomodel);
        }

        // GET: Portfolio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_General portfolio_General = db.Portfolio_General.Find(id);
            if (portfolio_General == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_General);
        }

        // POST: Portfolio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Portfolio_General portfolio_General)
        {
            if (ModelState.IsValid)
            {
                db.Entry(portfolio_General).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(portfolio_General);
        }

        // GET: Portfolio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_General portfolio_General = db.Portfolio_General.Find(id);
            if (portfolio_General == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_General);
        }

        // POST: Portfolio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Portfolio_General portfolio_General = db.Portfolio_General.FirstOrDefault(x => x.Id == id);
            portfolio_General.Status = 1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void AddItemDropDownList()
        {
            var customer = db.Portfolio_Customer.ToList();

            List<SelectListItem> listcustomer = new List<SelectListItem>();

            if (customer != null)
            {
                foreach (Portfolio_Customer pcus in customer)
                {

                    listcustomer.Add(new SelectListView
                    {
                        _Text = pcus.Name + " " + pcus.Surname,
                        _Value = pcus.Id
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
