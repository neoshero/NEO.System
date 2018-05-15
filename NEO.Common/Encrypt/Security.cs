using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NEO.Common.Encrypt
{
    public class Security
    {
        //默认密钥向量   
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        /// <summary>   
        /// DES加密字符串   
        /// </summary>   
        /// <param name="content">待加密的字符串</param>   
        /// <param name="secretKey">加密密钥,要求为8位</param>   
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>   
        public static string EncryptDES(string content, string secretKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(secretKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(content);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return content;
            }
        }

        /// <summary>   
        /// DES解密字符串   
        /// </summary>   
        /// <param name="content">待解密的字符串</param>   
        /// <param name="secretKey">解密密钥,要求为8位,和加密密钥相同</param>   
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>   
        public static string DecryptDES(string content, string secretKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(secretKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(content);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return content;
            }
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="content">明文</param>
        /// <returns></returns>
        public static string MD5Encrypt(string content)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] current = Encoding.UTF8.GetBytes(content);
            byte[] target = md5.ComputeHash(current);

            string encrypt = string.Empty;
            for (int i = 0; i < target.Length; i++)
            {
                encrypt += target[i].ToString("X2");
            }

            return encrypt;
        }
    }
}
