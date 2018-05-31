using System;
using System.Collections.Generic;
using System.Text;
using NEO.Common.Data;
using NEO.Core;

namespace NEO.Service
{
    public class OrganizationService:BaseService<Organization>
    {
		public BaseResponse Create(Organization entity)
		{
			BaseResponse response = new BaseResponse();

			return response;
		}

		public BaseResponse Modify(Organization entity)
		{
			BaseResponse response = new BaseResponse();

			return response;
		}

		public Pager<Organization> GetPage()
		{
            return null;
        }
    }
}
