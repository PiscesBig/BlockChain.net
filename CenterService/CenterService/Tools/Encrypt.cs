//引入命名空间
using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Collections;

namespace CenterService.Tools
{
    public class Encrypt
    {

        /*//RSA测试实例
        private string oldData = "taiyonghai";
        CreateRSAKey();
        string ciphertext = RSAEncrypt(oldData);
        string newData = RSADecrypt(ciphertext);*/


        /// <summary>
        /// 创建RSA公钥私钥
        /// </summary>
        public string[] CreateRSAKey()
        {
            //设置[公钥私钥]文件路径
            //string privateKeyPath = @"d:\\PrivateKey.xml";
            //string publicKeyPath = @"d:\\PublicKey.xml";
            //创建RSA对象
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //生成RSA[公钥私钥]
            string privateKey = rsa.ToXmlString(true);
            string publicKey = rsa.ToXmlString(false);
            string[] Key = new string[2];
            Key[0] = publicKey;
            Key[1] = privateKey;
            return Key;
            //将密钥写入指定路径
            //File.WriteAllText(privateKeyPath, privateKey);//文件内包含公钥和私钥
            //File.WriteAllText(publicKeyPath, publicKey);//文件内只包含公钥
        }
        /// <summary>
        /// 使用RSA实现加密
        /// </summary>
        /// <param name="data">加密数据</param>
        /// <returns></returns>
        public string RSAEncrypt(string data, string publicKey)
        {
            //C#默认只能使用[公钥]进行加密(想使用[公钥解密]可使用第三方组件BouncyCastle来实现)
            //string publicKeyPath = @"d:\\PublicKey.xml";
            //string publicKey = File.ReadAllText(publicKeyPath);
            //创建RSA对象并载入[公钥]
            RSACryptoServiceProvider rsaPublic = new RSACryptoServiceProvider();
            rsaPublic.FromXmlString(publicKey);
            string publicStr = "";//要返回的密文
            byte[] databyte = Encoding.UTF8.GetBytes(data);//将要加密的数据打成字符数组
            int count = databyte.Length;//要加密数组长度
            byte[] datagroup = new byte[117];//中间加密组
            int i = 0; //分段标志位
            //RSA只能加密117位，此处为分组加密
            while (count > 117)
            {
                datagroup = new byte[117];
                Array.ConstrainedCopy(databyte, i * 117, datagroup, 0, 117);//截取117位
                i++;//i添加一位
                count = count - 117;
                byte[] publicValue = rsaPublic.Encrypt(datagroup, false);//只能加密117位
                publicStr += Convert.ToBase64String(publicValue);//使用Base64将byte转换为string
                publicStr += "??";//间隔字符组
            }
            datagroup = new byte[117];
            Array.ConstrainedCopy(databyte, i * 117, datagroup, 0, databyte.Length - i * 117);//截取剩下的位数
            byte[] publicValue2 = rsaPublic.Encrypt(datagroup, false);//只能加密117位
            publicStr += Convert.ToBase64String(publicValue2);//使用Base64将byte转换为string
            //对数据进行加密
            return publicStr;
        }
        /// <summary>
        /// 使用RSA实现解密
        /// </summary>
        /// <param name="data">解密数据</param>
        /// <returns></returns>
        public string RSADecrypt(string data, string privateKey)
        {
            //C#默认只能使用[私钥]进行解密(想使用[私钥加密]可使用第三方组件BouncyCastle来实现)
            //string privateKeyPath = @"d:\\PrivateKey.xml";
            //string privateKey = File.ReadAllText(privateKeyPath);
            //创建RSA对象并载入[私钥]
            RSACryptoServiceProvider rsaPrivate = new RSACryptoServiceProvider();
            rsaPrivate.FromXmlString(privateKey);
            string[] datagroup = data.Split(new string[] { "??" }, StringSplitOptions.RemoveEmptyEntries);//分组解密字符串
            string privateStr = "";//要返回的解密明文
            ArrayList AL = new ArrayList();
            for (int i = 0; i < datagroup.Length; i++)
            {
                //对数据进行解密
                byte[] privateValue = rsaPrivate.Decrypt(Convert.FromBase64String(datagroup[i]), false);//使用Base64将string转换为byte
                privateStr = Encoding.UTF8.GetString(privateValue);
                foreach (byte item in privateValue)
                {
                    AL.Add(item);//按位添加字符
                }
            }
            byte[] al = (byte[])AL.ToArray(typeof(byte));
            privateStr = Encoding.UTF8.GetString(al);
            privateStr = privateStr.Replace('\0'.ToString(), string.Empty);
            return privateStr;
        }
    }

}

