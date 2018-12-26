using System;
using System.Collections.Generic;
using System.Text;
using NEO.Common;
using NEO.Core;

namespace NEO.Service
{
    public class BaseModuleService:BaseService<BaseModule>
    {
		public BaseResponse Create(int? parentId, string code, string name, bool ispublic, bool expand, bool isleaf, string navigateUrl, int priority, bool deleted, string remark,string memberName,int memberId)
		{
			BaseResponse response = new BaseResponse();
            var entity = BaseModule.CreateInstance(null, "AAA", "BBB", true, true, true, "/Power/Index", 1, false, "Test Data", null);

            UnitOfWork.BaseModuleRepository.Insert(entity);
            UnitOfWork.SaveChanges();
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
