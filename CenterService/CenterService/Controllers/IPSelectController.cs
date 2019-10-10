using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

namespace CenterService.Controllers
{
    public class IPSelectController : ApiController
    {
        /// <summary>
        /// 获取IP列表
        /// </summary>
        /// <param name="myIP"></param>
        /// <returns></returns>
        public string getIPs(string myIP)//获取IP列表
        {
            string res = "";//返回字符串
            DataTable IPdt = new Models.IPSelectModule().getIPList(myIP);//随机顺序获取IP值
            res = new Tools.jstodt().ToJson(IPdt);
            return res;
        }

        /// <summary>
        /// 创建新用户，返回用户信息+公私钥
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string getuser(string ip,string port, string name, string pwd)
        {
            string res = "";
            DataTable dt = new Models.User().setuser(ip, port, name, pwd);
            if (dt.Rows.Count == 0)
            {
                return "False";
            }
            res = new Tools.jstodt().ToJson(dt);
            return res;
        }

        /// <summary>
        /// 获取公钥
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string getpublickey(string id)
        {
            string res = new Models.User().getpublickey(id);
            res = System.Web.HttpUtility.UrlEncode(res);
            return res;
        }


        /*
        public string getIPList(string data)
        {
            #region 验证交易数据
            bool test = false;
            test = new Models.IPSelectModule().test(data);//验证交易合法
            if (!test)
            {
                return "False";
            }
            #endregion
            string res = "";//返回字符串
            string IP = "";//IP字符串
            string myIP = "10.14.4.203";//获取自己的IP
            DataTable IPdt = new Models.IPSelectModule().getIPList(myIP);//随机顺序获取IP值
            IP = new Tools.jstodt().ToJson(IPdt);//转换成json
            IP = System.Web.HttpUtility.UrlEncode(IP);
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string now = currentTime.ToString();
            now = now.Replace("/", "-");
            data = now + "|" + data;//加入时间戳 格式:"2018/7/23 16:51:50|data"
            data = new Tools.Encrypt().RSAEncrypt(data, Users.User.PubKey);//data加密     
            DataTable resdt = new DataTable();
            resdt.Columns.Add("IP", Type.GetType("System.String"));//IP列表
            resdt.Columns.Add("Data", Type.GetType("System.String"));//加密后的data
            resdt.Columns.Add("User",Type.GetType("System.String"));//加密人
            resdt.Rows.Add();
            resdt.Rows[0]["IP"] = IP;
            resdt.Rows[0]["Data"] = data;
            resdt.Rows[0]["User"] = "ID";
            res = new Tools.jstodt().ToJson(resdt);
            DataTable ss = new Tools.jstodt().ToDataTable(res);
            return res;
        }*/
    }    
}
