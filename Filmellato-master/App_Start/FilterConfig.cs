using System.Web;
using System.Web.Mvc;

namespace Filmellato
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //Minden csak bejelentkezes utan valik elerhetove
            //filters.Add(new AuthorizeAttribute());

            //Csak HTTPS-en keresztul erik el a weboldalt
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
