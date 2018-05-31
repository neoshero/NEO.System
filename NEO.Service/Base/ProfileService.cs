using System;
using System.Collections.Generic;
using System.Text;
using NEO.Common.Data;
using NEO.Core;

namespace NEO.Service
{
    public class ProfileService:BaseService<Profile>
    {
		public BaseResponse Create(Profile entity)
		{
			BaseResponse response = new BaseResponse();

			return response;
		}

		public BaseResponse Modify(Profile entity)
		{
			BaseResponse response = new BaseResponse();

			return response;
		}

		public Pager<Profile> GetPage()
		{
            return null;
        }
    }
}
