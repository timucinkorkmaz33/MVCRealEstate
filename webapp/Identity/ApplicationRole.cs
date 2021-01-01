using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SmartAdminMvc.Identity
{
    public class ApplicationRole:IdentityRole
    {
        public string Description { get; set; }

        public ApplicationRole()
        {
        }

        public ApplicationRole(string roleName, string description) : base(roleName)
        {
            this.Description = description;
        }
    }
}            //if (!context.Roles.Any(r => r.Name == "AppAdmin"))
//{
//    var store = new RoleStore<IdentityRole>(context);
//    var manager = new RoleManager<IdentityRole>(store);
//    var role = new IdentityRole { Name = "AppAdmin" };


//    manager.Create(role);
//}

//if (!context.Users.Any(u => u.UserName == "mia"))
//{
//    var store = new UserStore<ApplicationUser>(context);
//    var manager = new UserManager<ApplicationUser>(store);
//    var user = new ApplicationUser { UserName = "mia",Name = "MiaSoft",Surname ="MiaSoft", Email = "mia@miasoft.com.tr"};

//    manager.Create(user, "mia1907");
//    manager.AddToRole(user.Id, "AppAdmin");
//}