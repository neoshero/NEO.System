using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEO.Console.Interface;

namespace NEO.Console.Model
{
    public class SmallValue
    {
        private IValueCaculate valueCaculate;

        public Product[] Products { get; set; }

        public SmallValue(IValueCaculate valueCaculate)
        {
            this.valueCaculate = valueCaculate;

            Products = new Product[]
            {
                 new Product() {Name="西瓜",Price = 40},
                new Product() {Name="橘子",Price = 30},
                new Product() {Name="香蕉",Price = 20},
                new Product() {Name="梨子",Price = 10},
            };
        }

        public virtual decimal ValueCaculate()
        {
            return Products.Sum(t => t.Price);
        }
    }
}
