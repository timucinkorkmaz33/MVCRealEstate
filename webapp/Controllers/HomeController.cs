#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using SmartAdminMvc.Entity;
using SmartAdminMvc.ModelView;

#endregion

namespace SmartAdminMvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private MiaRealEstateDb db = new MiaRealEstateDb();

        // GET: home/index
        public ActionResult Index()
        {
            Process();
            AddBanksDropDownList();
            return View(db.Portfolio_Banks.ToList());
           
            return View();
        }
        [HttpPost]
        public JsonResult Process()//Kodu alanındaki değerin kullanıp kullanılmadığı kontrolu
        {
            var konut = db.Portfolio_General.Count(u => u.Type==1);
            var arsa = db.Portfolio_General.Count(u => u.Type == 2);
            var ofis = db.Portfolio_General.Count(u => u.Type == 3);
            var satilik = db.Portfolio_General.Count(u => u.Type_State == 1);
            var kiralik = db.Portfolio_General.Count(u => u.Type_State == 2);
            List<int> sorguCount = new List<int>();
            sorguCount.Add(konut);
            sorguCount.Add(arsa);
            sorguCount.Add(ofis);
            sorguCount.Add(satilik);
            sorguCount.Add(kiralik);

            string islem = JsonConvert.SerializeObject(sorguCount);
            return new JsonResult { Data = islem };
        }
        [HttpPost]
        public JsonResult Find(int id, int deger )//Kodu alanındaki değerin kullanıp kullanılmadığı kontrolu
        {
            IQueryable<float?> sorgu ;
            string islem = "";
            if (deger == 1)
            {
                sorgu = db.Portfolio_Banks.Where(u => u.Id == id).Select(u => u.FiveYear);
                islem = JsonConvert.SerializeObject(sorgu);
            }
            else if (deger == 2)
            {
                sorgu = db.Portfolio_Banks.Where(u => u.Id == id).Select(u => u.TenYear);
                islem = JsonConvert.SerializeObject(sorgu);
            }
            else if (deger == 3)
            {
                sorgu = db.Portfolio_Banks.Where(u => u.Id == id).Select(u => u.FifteenYear);
                 islem = JsonConvert.SerializeObject(sorgu);
            }

            
            return new JsonResult { Data = islem };
        }
        public ActionResult Social()
        {
            return View();
        }

        // GET: home/inbox
        public ActionResult Inbox()
        {
            return View();
        }

        // GET: home/widgets
        public ActionResult Widgets()
        {
            return View();
        }

        // GET: home/chat
        public ActionResult Chat()
        {
            return View();
        }

        private void AddBanksDropDownList()
        {
            var company = db.Portfolio_Banks.ToList();

            List<SelectListItem> listbanks = new List<SelectListItem>();

            if (company != null)
            {
                foreach (Portfolio_Banks bank in company)
                {

                    listbanks.Add(new SelectListView
                    {
                        _Text = bank.BankName,
                        _Value = bank.Id
                    });
                }

            }
            ViewBag.Banks = listbanks;
        }
    }
}