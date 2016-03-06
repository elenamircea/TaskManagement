﻿using DataLayer;
using DomainClasses;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TaskManagement
{
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store)
            : base(store)
        {
        }

        // this method is called by Owin therefore best place to configure your User Manager
        public static AppUserManager Create(
            IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var manager = new AppUserManager(
                new UserStore<AppUser>(context.Get<EntityFrameworkContext>()));

            // optionally configure your manager
            // ...

            return manager;
        }
    }

    public class IdentityConfig
    {
            public void Configuration(IAppBuilder app)
            {
                app.CreatePerOwinContext(() => new EntityFrameworkContext());
                app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);
                app.CreatePerOwinContext<RoleManager<AppRole>>((options, context) =>
                    new RoleManager<AppRole>(
                        new RoleStore<AppRole>(context.Get<EntityFrameworkContext>())));

                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Home/Login"),
                });
            }
    }
}