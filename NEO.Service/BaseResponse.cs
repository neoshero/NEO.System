using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO.Service
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Code = 1;
            Message = "操作成功";
        }

        /// <summary>
        /// 1 Success
        /// -1 Fail
        /// </summary>
        public int Code { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
