using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Filmellato.Models;

namespace Filmellato.Controllers
{
    [Authorize(Roles = RoleName.CanManageMovies)]
    public class UsersController : Controller
    {
        #region Actions
        public ActionResult Index()
        {
            return View();
        }
        #endregion
    }
}
