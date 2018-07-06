using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEO.Console.Model;

namespace NEO.Console.Interface
{
    interface IValueCaculate
    {
        decimal CaculateValus(params Product[] parameters);
    }
}
