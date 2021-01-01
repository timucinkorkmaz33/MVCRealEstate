using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartAdminMvc.Entity;
using SmartAdminMvc.ModelView;

namespace SmartAdminMvc.Controllers
{
    [Authorize]
    public class Portfolio_ProjectController : Controller
    {
        private MiaRealEstateDb db = new MiaRealEstateDb();

        // GET: Portfolio_Project
        public ActionResult Index()
        {
            var liste = from s in db.Portfolio_Project
                        join c in db.Portfolio_Company on s.Company_Id equals c.Id into j1
                        from c in j1.DefaultIfEmpty()
                       // where (s.Status == 0)
                        select new ProjectModelView()
                        {
                          p_Header = s.Header,
                          p_ProjectStatus = s.ProjectStatus,
                          c_Company_Name = c.Company_Name,
                          p_Rate = s.Rate,
                          p_FinishDate = s.FinishDate,
                          Id = s.Id
                          
                        };
            

            return View(liste);
        }

        // GET: Portfolio_Project/Details/5
       
       
        public ActionResult ProjectProcess(int? id)
        {
            AddItemDropDownList();
            if (id == null) { return View(); }
            else
            {
                var sorgu = db.Portfolio_Project.Where(x => x.Id == id).FirstOrDefault();
                ProjectModelView prj=new ProjectModelView();
                prj.p_ProjectStatus = sorgu.ProjectStatus;
                prj.p_Company_Id = sorgu.Company_Id;
                prj.p_Special_Header = sorgu.Special_Header;
                prj.p_Type = sorgu.Type;
                prj.p_FinishDate = sorgu.FinishDate;
                prj.p_Project_Description = sorgu.Project_Description;
                prj.p_Header = sorgu.Header;
                prj.p_Rate = sorgu.Rate;
                return View(prj);
            }

            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectProcess(ProjectModelView projectmodelview)
        {
            if (ModelState.IsValid)
            {
                if (projectmodelview.Id == null)
                {
                    if (projectmodelview.c_Company_Name == null && projectmodelview.c_Owner_NameSurname == null)
                    {
                        Portfolio_Project prj = new Portfolio_Project();
                        prj.Company_Id = projectmodelview.p_Company_Id;
                        prj.FinishDate = projectmodelview.p_FinishDate;
                        prj.Header = projectmodelview.p_Header;
                        prj.ProjectStatus = projectmodelview.p_ProjectStatus;
                        prj.Rate = projectmodelview.p_Rate;
                        prj.Project_Description = projectmodelview.p_Project_Description;
                        prj.Special_Header = projectmodelview.p_Special_Header;
                        prj.Type = projectmodelview.p_Type;
                        db.Portfolio_Project.Add(prj);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Portfolio_Company pcom = new Portfolio_Company();
                        pcom.Owner_EMail = projectmodelview.c_Owner_EMail;
                        pcom.Company_Name = projectmodelview.c_Company_Name;
                        pcom.Owner_Phone = projectmodelview.c_Owner_Phone;
                        pcom.Owner_Title = projectmodelview.c_Owner_Title;
                        pcom.Owner_NameSurname = projectmodelview.c_Owner_NameSurname;
                        db.Portfolio_Company.Add(pcom);
                        db.SaveChanges();

                        var com_Id =
                            db.Portfolio_Company.Where(
                                    x =>
                                        x.Owner_NameSurname == projectmodelview.c_Owner_NameSurname &&
                                        x.Company_Name == projectmodelview.c_Company_Name)
                                .Select(x => x.Id)
                                .FirstOrDefault();

                        Portfolio_Project prj = new Portfolio_Project();
                        prj.Company_Id = com_Id;
                        prj.FinishDate = projectmodelview.p_FinishDate;
                        prj.Header = projectmodelview.p_Header;
                        prj.ProjectStatus = projectmodelview.p_ProjectStatus;
                        prj.Rate = projectmodelview.p_Rate;
                        prj.Project_Description = projectmodelview.p_Project_Description;
                        prj.Special_Header = projectmodelview.p_Special_Header;
                        prj.Type = projectmodelview.p_Type;
                        db.Portfolio_Project.Add(prj);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                }
                else
                {
                    Portfolio_Project prj = db.Portfolio_Project.FirstOrDefault(x => x.Id == projectmodelview.Id);
                    prj.Company_Id = projectmodelview.p_Company_Id;
                    prj.FinishDate = projectmodelview.p_FinishDate;
                    prj.Header = projectmodelview.p_Header;
                    prj.ProjectStatus = projectmodelview.p_ProjectStatus;
                    prj.Rate = projectmodelview.p_Rate;
                    prj.Project_Description = projectmodelview.p_Project_Description;
                    prj.Special_Header = projectmodelview.p_Special_Header;
                    prj.Type = projectmodelview.p_Type;
                    
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            AddItemDropDownList();
            return View(projectmodelview);
        }

        public ActionResult Delete(int? id)
        {
           if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Portfolio_Project portfolio_Project = db.Portfolio_Project.Find(id);
            if (portfolio_Project == null)
            {
                return HttpNotFound();
            }
            return View(portfolio_Project);
        }

        // POST: Portfolio_Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Portfolio_Project portfolio_Project = db.Portfolio_Project.Find(id);
            db.Portfolio_Project.Remove(portfolio_Project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        private void AddItemDropDownList()
        {
            var company = db.Portfolio_Company.ToList();

            List<SelectListItem> listcompany= new List<SelectListItem>();

            if (company != null)
            {
                foreach (Portfolio_Company com in company)
                {

                    listcompany.Add(new SelectListView
                    {
                        _Text = com.Company_Name,
                        _Value = com.Id
                    });
                }

            }
            ViewBag.Company = listcompany;
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
