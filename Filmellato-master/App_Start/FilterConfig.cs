using System.Web;
using System.Web.Mvc;

namespace Filmellato
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            /*To make required Authorization globally
            filters.Add(new AuthorizeAttribute());*/

            //To make our website accessable only via Https
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
