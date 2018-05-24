using System;
using System.Web.Mvc;
using NEO.Service;


namespace NEO.Controllers.User
{
    public class UserController:BaseController
    {
        public ActionResult Index()
        {
            new ScoreService().CreateInstance();
            return View();
        }
    }
}
