using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace CenterService.Controllers
{
    public class DealController : ApiController
    {
        /// <summary>
        /// 发送交易请求
        /// </summary>
        /// <param name="data"></param>
        /// <param name="IP"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public string getDealChecked(string data, string IP = "http://localhost", string port = "58465")
        {
            string res;
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string now = currentTime.ToString();
            now = now.Replace("/", "-");
            data = now + "|" + data;//加入时间戳 格式:"2018/7/23 16:51:50|data"
            data = new Tools.Encrypt().RSAEncrypt(data, Users.User.PubKey);//data加密
            //data = System.Web.HttpUtility.UrlEncode(data);
            DataTable resdt = new DataTable();
            resdt.Columns.Add("ID", Type.GetType("System.String"));//ID列表
            resdt.Columns.Add("User", Type.GetType("System.String"));//加密人
            resdt.Columns.Add("IP", Type.GetType("System.String"));//IP
            resdt.Columns.Add("Port", Type.GetType("System.String"));//端口
            resdt.Columns.Add("Data", Type.GetType("System.String"));//加密后的data            
            resdt.Rows.Add();
            resdt.Rows[0]["ID"] = Users.User.ID;
            resdt.Rows[0]["User"] = Users.User.Name;
            resdt.Rows[0]["IP"] = Users.User.IP;
            resdt.Rows[0]["Port"] = Users.User.Port;
            resdt.Rows[0]["Data"] = data;
            string poststr = new Tools.jstodt().ToJson(resdt);
            poststr = System.Web.HttpUtility.UrlEncode(poststr);
            string url = IP + ":" + port + "/api/Deal/postCheckDeal";//;?dataget="+ poststr;
            try
            {
                res = new Tools.HttpHelper().HttpPost(url, poststr);
                //res = new Tools.HttpHelper().HttpGet(url);//发送确认
            }
            catch (Exception)
            {

                throw;
            }
            res = System.Web.HttpUtility.UrlDecode(res);
            DataTable dt = new Tools.jstodt().ToDataTable(res);
            string ID = dt.Rows[0]["ID"].ToString();
            string datalocked = dt.Rows[0]["Data"].ToString();
            #region 检查确认数据
            string pubkeyres = new Tools.HttpHelper().HttpGet(IP + ":" + port + "/api/IPSelect/getpublickey?id=" + ID);
            pubkeyres = System.Web.HttpUtility.UrlDecode(pubkeyres);
            DataTable pubdt = new Tools.jstodt().ToDataTable(pubkeyres);
            string pubkey = pubdt.Rows[0]["User_PriKey"].ToString();
            string data1 = new Tools.Encrypt().RSADecrypt(datalocked, pubkey);//解密
            #endregion
            return res;
        }

        /// <summary>
        /// 接收并确认交易请求
        /// </summary>
        /// <returns></returns>
        public string postCheckDeal()
        {
            string dataget = HttpContext.Current.Request.Form.ToString();
            dataget = System.Web.HttpUtility.UrlDecode(dataget);
            DataTable dt = new Tools.jstodt().ToDataTable(dataget);
            string ID = dt.Rows[0]["ID"].ToString();
            string datalocked = dt.Rows[0]["Data"].ToString();
            #region 检查确认数据
            string url = "http://10.14.4.167:9503/api/IPSelect/getpublickey?id=" + ID;
            string pubkey = new Tools.HttpHelper().HttpGet(url);
            string data = new Tools.Encrypt().RSADecrypt(datalocked, pubkey);//解密
            #endregion
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            string now = currentTime.ToString();
            now = now.Replace("/", "-");
            dataget = System.Web.HttpUtility.UrlEncode(dataget);
            datalocked = now + "|" + dataget;//加入时间戳 格式:"2018/7/23 16:51:50|data"
            datalocked = new Tools.Encrypt().RSAEncrypt(datalocked, Users.User.PubKey);//data加密
            DataTable resdt = new DataTable();
            resdt.Columns.Add("ID", Type.GetType("System.String"));//ID列表
            resdt.Columns.Add("User", Type.GetType("System.String"));//加密人
            resdt.Columns.Add("IP", Type.GetType("System.String"));//IP
            resdt.Columns.Add("Port", Type.GetType("System.String"));//端口
            resdt.Columns.Add("Data", Type.GetType("System.String"));//加密后的data            
            resdt.Rows.Add();
            resdt.Rows[0]["ID"] = Users.User.ID;
            resdt.Rows[0]["User"] = Users.User.Name;
            resdt.Rows[0]["IP"] = Users.User.IP;
            resdt.Rows[0]["Port"] = Users.User.Port;
            resdt.Rows[0]["Data"] = datalocked;
            string retstr = new Tools.jstodt().ToJson(resdt);
            retstr = System.Web.HttpUtility.UrlEncode(retstr);
            //string url2 = "http://localhost:58495/api/Hash/PostHash";//;?dataget="+ poststr;
            //string res = new Tools.HttpHelper().HttpPost(url2, retstr);//完全揭秘
            string url2 = "http://localhost:58495/api/Hash/PostUnlocked";//;?dataget="+ poststr;
            string res = new Tools.HttpHelper().HttpPost(url2, retstr);
            return retstr;
        }
    }
}
