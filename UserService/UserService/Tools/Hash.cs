using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace UserService.Tools
{
    public class Hash
    {
        /// <summary>
        /// 计算SHA-256码
        /// </summary>
        /// <param name="word">字符串</param>
        /// <param name="toUpper">返回哈希值格式 true：英文大写，false：英文小写</param>
        /// <returns></returns>
        public string Hash_SHA_256(string word, bool toUpper = true)
        {
            try
            {
                byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(word);
                System.Security.Cryptography.SHA256CryptoServiceProvider SHA256
                    = new System.Security.Cryptography.SHA256CryptoServiceProvider();
                
                byte[] bytHash = SHA256.ComputeHash(bytValue);
                SHA256.Clear();               
                
                StringBuilder sb = new StringBuilder();

                foreach (var b in bytHash)
                    sb.Append(b.ToString("X2"));
                string sHash = sb.ToString();       

                #region 同上
                //根据计算得到的Hash码翻译为SHA-1码
                /*string sHash = "", sTemp = "";
                for (int counter = 0; counter < bytHash.Count(); counter++)
                {
                    long i = bytHash[counter] / 16;
                    if (i > 9)
                    {
                        sTemp = ((char)(i - 10 + 0x41)).ToString();
                    }
                    else
                    {
                        sTemp = ((char)(i + 0x30)).ToString();
                    }
                    i = bytHash[counter] % 16;
                    if (i > 9)
                    {
                        sTemp += ((char)(i - 10 + 0x41)).ToString();
                    }
                    else
                    {
                        sTemp += ((char)(i + 0x30)).ToString();
                    }
                    sHash += sTemp;
                }*/
                #endregion

                //根据大小写规则决定返回的字符串
                return toUpper ? sHash : sHash.ToLower();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string ComputeHash(string str)
        {
            byte[] buffer = System.Text.Encoding.Default.GetBytes(str);
            if (buffer == null || buffer.Length < 1)
                return "";

            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(buffer);
            StringBuilder sb = new StringBuilder();

            foreach (var b in hash)
                sb.Append(b.ToString("x2"));

            return sb.ToString();
        }

        internal object Hash_SHA_256(object p)
        {
            throw new NotImplementedException();
        }
    }
}