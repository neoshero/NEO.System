using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEO.Console.Interface
{
    public interface IDiscount
    {
        decimal ApplyDiscount(decimal amount);
    }
}
