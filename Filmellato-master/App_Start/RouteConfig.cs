using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Filmellato
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Engedelyezzuk az attribute routingot
            routes.MapMvcAttributeRoutes();

            /*  CONVENTION-BASED ROUTING >> regi, rossz >> helyette ATTRIBUTE ROUTING
            routes.MapRoute(
                name: "MoviesByReleaseDate",
                url: "movies/released/{year}/{month}",
                defaults: new { controller = "Movies", action = "ByReleaseDate" },
                          new { year = @"\d{4}", month = @"\d{2}"}          //d >> digits
                        //new { year = @"2015|2016", month = @"\d{2}"}      //>> az ev 2015 vagy 2016 kell legyen
            );*/

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
