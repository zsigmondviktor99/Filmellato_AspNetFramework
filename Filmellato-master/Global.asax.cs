using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Filmellato.Models;

//Web API engedelyezese
using System.Web.Http;
using System.Web.Routing;

//Auto Mapper
using AutoMapper;
using Filmellato.App_Start;

namespace Filmellato
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //MappingProfile start
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());

            //Web API engedelyezese
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Alapertelmezettek
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //ApplicationDbStart exception javitasa
            Database.SetInitializer<ApplicationDbContext>(null);
        }
    }
}
