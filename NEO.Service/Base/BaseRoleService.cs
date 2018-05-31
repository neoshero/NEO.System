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
