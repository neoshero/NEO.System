using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEO.Common;
using NEO.Common.Date;
using NEO.Common.Extension;
using NEO.Common.Log;
using NEO.Console.Stream;

namespace NEO.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryStream memory = new MemoryStream();

            var gender = Gender.Famale.ToDescription();

            var content = "JokerFakerleagon";
            var buffer = Encoding.UTF8.GetBytes(content);

            System.Console.WriteLine("Initialize string is : {0}", content);

            if (memory.CanWrite)
            {
                memory.Write(buffer, 0, 5);
            }
            //at position 5
            System.Console.WriteLine("Current stream position at {0}",memory.Position);

            //at position 8
            var newposition = memory.CanSeek ? memory.Seek(3, SeekOrigin.Current) : 0;

            System.Console.WriteLine("Current stream position at {0}", newposition);

            if (newposition < buffer.Length)
            {
                memory.Write(buffer,5,buffer.Length - 5);
            }

            memory.Position = 0;

            byte[] newBuffer = new byte[memory.Length];


            var val = Encoding.UTF8.GetString(newBuffer);

            System.Console.WriteLine("The result string is {0}",val);

            memory.Close();

            System.Console.ReadKey();
        }
    }
}
