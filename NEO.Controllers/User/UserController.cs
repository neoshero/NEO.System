using System;
using System.Web.Mvc;
using NEO.Core;
using NEO.Service;


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
