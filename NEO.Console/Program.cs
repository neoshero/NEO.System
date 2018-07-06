using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEO.Console.Interface;
using NEO.Console.Model;
using Ninject;

namespace NEO.Console
{
    public delegate void CheckAge(int age, string name);
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IValueCaculate>().To<ValueCaculate>();

            Product[] products = new Product[]
            {
                new Product() {Name="西瓜",Price = 40},
                new Product() {Name="橘子",Price = 30},
                new Product() {Name="香蕉",Price = 20},
                new Product() {Name="梨子",Price = 10},
            };
            var caculate = kernel.Get<IValueCaculate>();
            var result = caculate.CaculateValus(products);

            System.Console.WriteLine("The total amount : {0}",result);
            System.Console.ReadKey();
        }

        public static void WriteInfo(int age, string name)
        {
            System.Console.WriteLine("Sorry. your age is {0}. name is {1}", age, name);
        }
    }

}
