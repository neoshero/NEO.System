using System;
using System.Web.Mvc;

namespace NEO.Controllers.Home
{
    public class HomeController:BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
