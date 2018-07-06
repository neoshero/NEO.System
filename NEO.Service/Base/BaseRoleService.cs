using System;
using System.Collections.Generic;
using System.Text;
using NEO.Common.Data;
using NEO.Core;

namespace NEO.Service
{
    public class BaseRoleService:BaseService<BaseRole>
    {
		public BaseResponse Create(BaseRole entitys)
		{
			BaseResponse response = new BaseResponse();
		    var role = UnitOfWork.BaseRoleRepository.Get(t => t.Id == 1);

		    var permission = UnitOfWork.BasePermissionRepository.Get(t => t.Id == 1);
//		    UnitOfWork.SaveChanges();
//            entity.BasePermissions
			return response;
		}

		public BaseResponse Modify(BaseRole entity)
		{
			BaseResponse response = new BaseResponse();

			return response;
		}

		public Pager<BaseRole> GetPage()
		{
            return null;
        }
    }
}
