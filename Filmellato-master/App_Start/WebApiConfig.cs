using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

//JSON camelNotation
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Filmellato
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Using camelNotation not PascalNotation in JSON
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

            //Defaults
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
