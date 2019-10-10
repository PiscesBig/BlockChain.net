using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UserService.Controllers
{
    public class IPSelectController : ApiController
    {
        /// <summary>
        /// 获取IP列表
        /// </summary>
        /// <param name="data"></param>
        /// <param name="IP"></param>
        /// <returns></returns>
        public string getIP(string data, string IP = "http://10.14.4.167:9503/api/")
        {            
            string result = new Tools.HttpHelper().HttpGet(IP + "IPSelect/getIPList?data=" + data);
            if (result == "False")//认证失败
            {
                return "False";
            }
           /* DataTable Resultdt = new Tools.jstodt().ToDataTable(result);
            string user = Resultdt.Rows[0]["User"].ToString();//认证人
            string datares = Resultdt.Rows[0]["Data"].ToString();//加密后数据
            //根据user的公钥对datares解密
            //对解密后数据进行验证
            string IPs = Resultdt.Rows[0]["IP"].ToString();//IP列表
            IPs = System.Web.HttpUtility.UrlDecode(IPs);
            DataTable IPsdt = new Tools.jstodt().ToDataTable(IPs);//IP列表*/
            return result;

        }

        public string getuser(string id, string name, string PriKey, string PubKey, string IP, string Port)
        {
            new Models.User().setuser(id,name,PriKey,PubKey,IP,Port);
            return "true";
        }

        public string getpublickey(string id, string IP = "http://10.14.4.167:9503/api/")
        {
            string res = new Tools.HttpHelper().HttpGet(IP + "IPSelect/getpublickey?id=" + id);//取回公钥
            return res;
        }

    }
}
