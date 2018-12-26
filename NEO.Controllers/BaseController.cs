using System.Web.Mvc;

namespace NEO.Controllers
{
    public class BaseController:System.Web.Mvc.Controller
    {
        public int PageSize = 10;
        public JsonResult JsonAllowGet(object obj)
        {
            return Json(obj,JsonRequestBehavior.AllowGet);
        }
    }
}
