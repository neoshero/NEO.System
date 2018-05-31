using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO.Common.Data
{
    public class Pager<T> where T:class 
    {
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int Total { get; set; }

        public int TotalPage {
            get { return Convert.ToInt32(Math.Ceiling(1.0*Total/PageSize)); } 
        }

        public List<T> Data { get; set; }
    }
}
