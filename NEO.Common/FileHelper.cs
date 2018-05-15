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
        public static void Write(string filename, byte[] buffer)
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
            writer.Close();
            ms.Close();
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="content">文本内容</param>
        /// <param name="filename">文件名称</param>
        public static void Write(string filename, string content)
        {
            var folder = Path.GetDirectoryName(filename);

            if (string.IsNullOrEmpty(folder))
            {
                folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "File");
            }

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            var buffer = Encoding.UTF8.GetBytes(content);
            var ms = new MemoryStream(buffer);
            var writer = new StreamWriter(ms);
            writer.Close();
            ms.Close();
        }

        public static string GetFileText(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            
            return reader.ReadToEnd();
        }
    }
}
