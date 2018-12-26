using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEO.Console.Interface;

namespace NEO.Console.Model
{
    public class ShopValueCaculate : IValueCaculate
    {
        public decimal CaculateValus(params Product[] parameters)
        {
            return parameters.Sum(t => t.Price) * 7 / 10;
        }
    }
}
