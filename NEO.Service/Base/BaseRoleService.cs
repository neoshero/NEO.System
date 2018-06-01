using System;
using System.Collections.Generic;
using System.Text;
using NEO.Common.Data;
using NEO.Core;

namespace NEO.Service
{
    public class BaseRoleService:BaseService<BaseRole>
    {
		public BaseResponse Create(BaseRole entity)
		{
			BaseResponse response = new BaseResponse();
		    entity.Code = "Administrator";
		    entity.Name = "π‹¿Ì‘±";
		    entity.Enabled = true;
            entity.CreatedDate = DateTime.Now;
            entity.ModifyDate = DateTime.Now;

		    UnitOfWork.BaseRoleRepository.Insert(entity);
		    UnitOfWork.SaveChanges();
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
