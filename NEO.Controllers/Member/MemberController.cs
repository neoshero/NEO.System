using System;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using NEO.Service;

namespace NEO.Controllers.Member
{
    public class MemberController:BaseController
    {
        private MemberService _memberService = new MemberService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public JsonResult Authorize(string uid, string pwd)
        {
            var response = _memberService.Login(uid, pwd);

            var user = new {Uid = uid, Pwd = pwd};
            var userData = JsonConvert.SerializeObject(user);

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                2,
                uid,
                DateTime.Now,
                DateTime.Now.AddHours(3),
                true,userData);

            string cookingValue = FormsAuthentication.Encrypt(ticket);

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,cookingValue);
            cookie.HttpOnly = true;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            cookie.Expires = DateTime.Now.AddHours(1);
            Response.Cookies.Remove(cookie.Name);
            Response.Cookies.Add(cookie);

            return JsonAllowGet(response);
        }
    }
}
