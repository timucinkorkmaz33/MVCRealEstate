#region Using

using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using SmartAdminMvc.Entity;
using SmartAdminMvc.Identity;
using SmartAdminMvc.Models;
using SmartAdminMvc.ModelView;

#endregion

namespace SmartAdminMvc.Controllers
{
     [Authorize(Roles = "AppAdmin,Admin")]
    public class AccountController : Controller
    {
         MiaRealEstateDb db = new MiaRealEstateDb();
        private UserManager<ApplicationUser> userManager;

        private RoleManager<ApplicationRole> roleManager;
        public AccountController()
        {
            MiaRealEstateDb db = new MiaRealEstateDb();
            UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(db);
            userManager = new UserManager<ApplicationUser>(userStore);
            RoleStore<ApplicationRole> roleStore = new RoleStore<ApplicationRole>(db);
            roleManager = new RoleManager<ApplicationRole>(roleStore);
           // IQueryable<Account> xx = db.Account.Select(x => x);
        }

        public ActionResult Index()
        {
            //var sorgu = from c in db.Account
            //    select new Register()
            //    {
            //        Username = c.UserName,
            //        Name = c.NameSurname,
            //        Surname = c.NameSurname,
            //        Email = c.EMail,
            //        Password = c.Password,
            //        Id=c.Id

            //    };
            var userName = User.Identity.GetUserName();
            //var userId = User.Identity.GetUserId();
            //var role = roleManager.Roles.Select(u => u.).ToList();
                
            // List<ApplicationUser> iresult = userManager.Users.Where(x => x.UserName!="mia").ToList();
            if (userName == "mia")
            {
                List<ApplicationUser> iresult = userManager.Users.Select(x => x).ToList();
                   return View(iresult.ToList());
            }
        else
        {
                List<ApplicationUser> iresult = userManager.Users.Where(x => x.UserName!="mia").ToList();
                 return View(iresult.ToList());
            }
          //IQueryable<ApplicationRole> vv = roleManager.Roles.Select(x => x);
         
          //  AccountRegistrationModel_Custom ac=new AccountRegistrationModel_Custom();
          
            

          //  string currentUserId = User.Identity.GetUserId();
          //  ApplicationUser currentUser = userManager.FindById(currentUserId);

            return View();
        }
       
        public ActionResult Register()
        {
            AddItemDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //Account acc=new Account();
                //acc.EMail = model.Email;
                //acc.NameSurname = model.Name + model.Surname;
                //acc.Password = model.Password;
                //acc.UserName = model.Username;
                //acc.Task = "Admin";
                //db.Account.Add(acc);
                //db.SaveChanges();
                //return RedirectToAction("Login", "Account");
                ApplicationUser user = new ApplicationUser();
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;
                user.UserName = model.Username;
              

                IdentityResult iResult = userManager.Create(user, model.Password);
                if (iResult.Succeeded)
                {
                    
                    userManager.AddToRole(user.Id, model.Roles);
                    return RedirectToAction("Logout", "Account");

                }
                else
                {
                    ModelState.AddModelError("RegisterUser", "Kullanıcı ekleme işleminde hata!");
                }

            }

            return View(model);

        }

      
        public ActionResult EditUsers(string id)
        {

            Register user = new Register();
            var sonuc = userManager.FindById(id);
           
            user.Username = sonuc.UserName;
            user.Name = sonuc.Name;
            user.Email = sonuc.Email;
            user.Surname = sonuc.Surname;
            user.Password = sonuc.PasswordHash;
            user.Id = id;
            //user.Roles=sonuc.Roles.Where(u=>u)
          //  user.ConfirmPassword = sonuc.Password;
            //ApplicationUser user = userManager.Users.Where(x => x.Id==id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
      
        [ValidateAntiForgeryToken]
        public ActionResult EditUsers(Register model)
        { 
            if (ModelState.IsValid)
            {
                ApplicationUser user = userManager.FindByEmail(model.Email);
                user.Email = model.Email;
                user.UserName = model.Username;
                 userManager.Update(user);
                 if (!model.Password.Equals(user.PasswordHash))
                 {
                     //var sonuc=userManager.Users.Where(i=>i.UserName==model.Username).Select(x=>x.PasswordHash);

                         var removeresult =  userManager.RemovePassword(model.Id);
                         if (removeresult.Succeeded)
                         {
                             var sonuc1 = userManager.AddPassword(model.Id, model.Password);

                             if (sonuc1.Succeeded)
                             {

                                 return RedirectToAction("index", "Account");
                             }
                             else
                             {
                                 return View(model);
                             }
                         }

                     }
               
                //ApplicationUser user = userManager.Users.Where(x => x.Id == model.Id).FirstOrDefault();
                //user.Name = model.Name;
                //user.Surname = model.Surname;
                //user.PasswordHash = model.Password;
                //user.Email = model.Email;
                //user.UserName = model.Username;

                //userManager.Users.a

                return RedirectToAction("index", "Account");              

            }

            return View(model);

        }

        
        public async Task<ActionResult> DeleteUser(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Register user = new Register();
            var sonuc = userManager.FindById(id);
            user.Username = sonuc.UserName;
            user.Name = sonuc.Name;
            user.Email = sonuc.Email;
            user.Surname = sonuc.Surname;
            user.Password = sonuc.PasswordHash;
            user.Id = id;
           


            if (user != null)
            {
                return View(user);

            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


        }


        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
      
        public async Task<ActionResult> DeleteConfirmed(Register model)
        {


            ApplicationUser user = userManager.FindById(model.Id);


            if (user != null)
            {
                
                var result =  userManager.Delete(user);
             

                if (result.Succeeded)
                {

                    return RedirectToAction("Logout");
                }
                else
                {
                    return View(model);
                }

            }
            return RedirectToAction("Logout");
        }

            [AllowAnonymous]
        public ActionResult Login()
        {
            //string currentUserId = User.Identity.GetUserId();
            //ApplicationUser currentUser = userManager.FindById(currentUserId);

            return View();

        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = userManager.Find(model.Username, model.Password);
                if (user != null)
                {
                    IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
                    ClaimsIdentity identity = userManager.CreateIdentity(user, "ApplicationCookie");
                    AuthenticationProperties authProps = new AuthenticationProperties();
                    authProps.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProps, identity);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUser", "Böyle bir kullanıcı bulunamadı");
                }
            }
            return View(model);
        }
        private void AddItemDropDownList()
        {
            var kullanici = roleManager.Roles.Select(x=>x).ToList();

            List<SelectListItem> roles = new List<SelectListItem>();

            if (kullanici != null)
            {
                foreach (ApplicationRole person in kullanici)
                {
                    roles.Add(new SelectListView
                    {
                        _Text = person.Name ,
                        _strValue = person.Name
                    });
                }

            }
            ViewBag.Roles = roles;
        }
       
        public ActionResult Logout()
        {
            IAuthenticationManager authManager = HttpContext.GetOwinContext().Authentication;
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            authManager.SignOut();
            return RedirectToAction("login", "Account");

        }


    }
}