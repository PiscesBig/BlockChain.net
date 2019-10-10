using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Security;

namespace UserService.Controllers
{
    public class HashController : ApiController
    {
        // GET: api/Hash
        /// <summary>
        /// 其他用户接收到交易数据
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public string PostUnlocked(string IP = "http://localhost", string port = "58465")
        {
            string data = HttpContext.Current.Request.Form.ToString();//获取传来的数据
            try
            {
                #region 数据验证
                string res = "";//
                res = System.Web.HttpUtility.UrlDecode(data);//数据解码
                DataTable dtget = new Tools.jstodt().ToDataTable(res);//将获取到的Json打成datatable
                string ID1 = dtget.Rows[0]["ID"].ToString();//获取ID
                string data1locked = dtget.Rows[0]["Data"].ToString();//第一层数据
                string key1 = new Tools.HttpHelper().HttpGet(IP + ":" + port + "/api/IPSelect/getpublickey?id=" + ID1);
                key1 = System.Web.HttpUtility.UrlDecode(key1);//获取到秘钥必须解码
                DataTable key1dt = new Tools.jstodt().ToDataTable(key1);
                key1 = key1dt.Rows[0]["User_PriKey"].ToString();
                string data1unlocked = new Tools.Encrypt().RSADecrypt(data1locked, key1);//第一层解密
                string date1 = data1unlocked.Split('|')[0];//第一个日期
                string datalocked2 = data1unlocked.Replace(date1 + "|", "");//第二层加密数据
                datalocked2 = System.Web.HttpUtility.UrlDecode(datalocked2);//解码

                DataTable dtdata2 = new Tools.jstodt().ToDataTable(datalocked2);//将获取到的Json打成datatable
                string ID2 = dtdata2.Rows[0]["ID"].ToString();//获取ID
                string data2locked = dtdata2.Rows[0]["Data"].ToString();//第二层数据
                string key2 = new Tools.HttpHelper().HttpGet(IP + ":" + port + "/api/IPSelect/getpublickey?id=" + ID2);
                key2 = System.Web.HttpUtility.UrlDecode(key2);//获取到秘钥解码
                DataTable key2dt = new Tools.jstodt().ToDataTable(key2);
                key2 = key2dt.Rows[0]["User_PriKey"].ToString();
                string data2unlocked = new Tools.Encrypt().RSADecrypt(data2locked, key2);//第二层解密
                #endregion

                #region 数据存入记录
                string hash = new Tools.Hash().Hash_SHA_256(data);//计算hash
                Users.ChainNode node = new Users.ChainNode();//新建存储节点
                node.data = data;
                node.hash = hash;
                Services.Block.chainlock.WaitOne();//等待互斥信号量
                Services.Block.chain.AddLast(node);//插入
                Services.Block.chainlock.ReleaseMutex();//释放互斥信号量
                #endregion
            }
            catch (Exception e)
            {
                string exp = e.ToString();
                return "error";
            } 
            return "true";
        }
    }
}
