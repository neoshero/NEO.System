using System;
using System.Web.Mvc;

namespace NEO.Controller.Home
{
    public class HomeController:BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
