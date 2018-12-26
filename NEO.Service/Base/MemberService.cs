using System;
using System.Collections.Generic;
using System.Text;
using NEO.Common;
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

        public BaseResponse Login(string uid,string pwd)
        {
            var response = new BaseResponse();
            return response;
        }
    }
}
