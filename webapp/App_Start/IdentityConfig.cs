﻿using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SmartAdminMvc.Entity;
using SmartAdminMvc.Identity;

namespace SmartAdminMvc
{
    public static class IdentityConfig
    {
        public static void RegisterIdentities()
        {
            // Ensures the default demo user is available to login with
            UserManager.Seed();
        }
        public class ApplicationUserManager : UserManager<ApplicationUser>
        {
            public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
            {
            }

            public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
            {
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<MiaRealEstateDb>()));
                // Configure validation logic for usernames
                manager.UserValidator = new UserValidator<ApplicationUser>(manager)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };

                // Configure validation logic for passwords
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 1,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                };

                // Configure user lockout defaults
                manager.UserLockoutEnabledByDefault = true;
                manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
                manager.MaxFailedAccessAttemptsBeforeLockout = 5;

                // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
                // You can write your own provider and plug it in here.
                manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
                {
                    MessageFormat = "Your security code is {0}"
                });
                manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
                {
                    Subject = "Security Code",
                    BodyFormat = "Your security code is {0}"
                });
                //manager.EmailService = new EmailService();
                //manager.SmsService = new SmsService();
                var dataProtectionProvider = options.DataProtectionProvider;
                if (dataProtectionProvider != null)
                {
                    manager.UserTokenProvider =
                        new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
                }
                return manager;
            }
        }
       
    }
}