using System;
using System.Collections.Generic;
using System.Text;
using NEO.Common.Data;
using NEO.Core;

namespace NEO.Service
{
    public class BaseModuleService:BaseService<BaseModule>
    {
		public BaseResponse Create(BaseModule entity)
		{
			BaseResponse response = new BaseResponse();

			return response;
		}

		public BaseResponse Modify(BaseModule entity)
		{
			BaseResponse response = new BaseResponse();

			return response;
		}

		public Pager<BaseModule> GetPage()
		{
		    return null;
		}
    }
}
