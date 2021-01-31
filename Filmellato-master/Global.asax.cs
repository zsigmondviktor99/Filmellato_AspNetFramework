using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Filmellato.Models;

//Enable Web API
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

            //Enable Web API
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Defaults
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //To fix the ApplicationDbStart exception >>
            Database.SetInitializer<ApplicationDbContext>(null);
        }
    }
}
