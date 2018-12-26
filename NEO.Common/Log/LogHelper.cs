using System;
using System.IO;
using System.Text;

namespace NEO.Common
{
    public class LogHelper
    {
        public static void Log(string content)
        {
            var filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Log" ,DateTime.Today.ToString("yyyy-MM-dd") + ".txt");
            var folder = Path.GetDirectoryName(filename);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            using (var filestream = new FileStream(filename,FileMode.Append,FileAccess.Write))
            {
                var buffer = Encoding.Default.GetBytes(content + "\n");
                filestream.Write(buffer,0,buffer.Length);
                filestream.Flush();
            }
        }
    }
}
