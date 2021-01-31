using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filmellato.Controllers
{
    [Authorize]
    public class RentalsController : Controller
    {
        #region Actions
        // GET: /rentals
        public ActionResult Index()
        {
            return View();
        }
        
        // GET: /rentals/new
        public ActionResult New()
        {
            return View();
        }
        #endregion
    }
}
