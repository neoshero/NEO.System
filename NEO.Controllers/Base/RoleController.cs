using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NEO.Core;
using NEO.Service;

namespace NEO.Controllers.Base
{
    public class RoleController:BaseController
    {
        public JsonResult Create()
        {
            return JsonGet(new BaseRoleService().Create(new BaseRole()));
        }
    }
}
