using System.Web.Mvc;
using NEO.Service;

namespace NEO.Controllers.Role
{
    public class RoleController:BaseController
    {
        #region CRUD
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Query(int pageIndex,string code,string name)
        {
            var pager = new RoleService().GetPageList(pageIndex, PageSize, code, name);
            
            return JsonAllowGet(new
            {
                PageIndex = pager.PageIndex,
                TotalPage = pager.TotalPage,
                Total = pager.Total,
                Data = RoleListVM.ConvertToList(pager.Data)
            });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(RoleVM vModel)
        {
            return JsonAllowGet(new RoleService().Create(vModel.Code,vModel.Name,vModel.IsPublish,vModel.Enabled));
        }

        public ActionResult Modify()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Modify(RoleVM vModel)
        {
            return JsonAllowGet(new RoleService().Modify(vModel.Id, vModel.Name, vModel.IsPublish, vModel.Enabled));
        }

        public JsonResult Delete(int id)
        {
            return JsonAllowGet(new RoleService().Delete(id));
        }

        #endregion

    }
}
