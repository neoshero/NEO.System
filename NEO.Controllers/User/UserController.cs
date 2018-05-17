using System;
using System.Web.Mvc;


namespace NEO.Controllers.User
{
    public class UserController:BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
