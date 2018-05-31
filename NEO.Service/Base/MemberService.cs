using System;
using System.Collections.Generic;
using System.Text;
using NEO.Common.Data;
using NEO.Core;

namespace NEO.Service
{
    public class MemberService:BaseService<Member>
    {
		public BaseResponse Create(Member entity)
		{
			BaseResponse response = new BaseResponse();

			return response;
		}

		public BaseResponse Modify(Member entity)
		{
			BaseResponse response = new BaseResponse();

			return response;
		}

		public Pager<Member> GetPage()
		{
            return null;
        }
    }
}
