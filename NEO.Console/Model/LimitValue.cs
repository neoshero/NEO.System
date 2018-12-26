using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEO.Console.Interface;

namespace NEO.Console.Model
{
    public class LimitValue:SmallValue
    {
        private IValueCaculate valueCaculate;
        public LimitValue(IValueCaculate valueCaculate) : base(valueCaculate)
        {
            this.valueCaculate = valueCaculate;
        }

        public decimal DiscountSize { get; set; }

        public override decimal ValueCaculate()
        {
            var products = Products.Where(t => t.Price > 10);
            return products.Sum(t => t.Price)*DiscountSize/10;
        }
    }
}
