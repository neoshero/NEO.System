using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NEO.Common
{
    public class FileHelper
    {
        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="buffer">字节流</param>
        /// <param name="filename">文件名称</param>
        public void Write(byte[] buffer, string filename)
        {
            var folder = Path.GetDirectoryName(filename);
            
            if (string.IsNullOrEmpty(folder))
            {
                folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "File");
            }

            if(!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var ms = new MemoryStream(buffer);
            var writer  = new StreamWriter(ms);
            writer.Flush();
            ms.Flush();

        }

        public string Read(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            
            return reader.ReadToEnd();
        }
    }
}
