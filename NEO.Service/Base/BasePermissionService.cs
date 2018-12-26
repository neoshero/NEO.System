using System;
using System.Collections.Generic;
using System.Text;
using NEO.Common;
using NEO.Core;

namespace NEO.Service
{
    public class BasePermissionService:BaseService<BasePermission>
    {
		public BaseResponse Create(BasePermission entity)
		{
			BaseResponse response = new BaseResponse();

			return response;
		}

		public BaseResponse Modify(BasePermission entity)
		{
			BaseResponse response = new BaseResponse();

			return response;
		}

		public Pager<BasePermission> GetPage()
		{
            return null;
        }
    }
}
