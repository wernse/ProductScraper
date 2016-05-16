using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace angularJS.Controllers
{
    public class HomeController : Controller
    {
        [Route("~/", Name = "default")]
        public ActionResult Index()
        {
            return View();
        }

    }
}