using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TaskManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();


            RouteTable.Routes.MapRoute(
        "DefaultTask", // Route name
        "{controller}/{action}/{id}", // URL with parameters*
        new
        {
            controller = "Task",
            action = "Index",
            id = UrlParameter.Optional
        }
);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
