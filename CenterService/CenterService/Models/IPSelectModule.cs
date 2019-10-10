using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace CenterService.Models
{
    public class IPSelectModule
    {       
        public DataTable getIPList(string myip)
        {
            DataTable IPDT = new DataTable();//获取除了自己之外的IP列表
            string sql = "select * from [TB_IPList] order by NewId()";//随机排序IP列表
            SqlParameter[] paras = {new SqlParameter("@myip",myip) };//自己的IP
            IPDT=new SQLHelper().ExcuteQuery(sql, paras, CommandType.Text);
            return IPDT;
        }

        /// <summary>
        /// 验证交易合法
        /// </summary>
        /// <param name="data">用户发来交易请求</param>
        /// <returns></returns>
        public bool test(string data)
        {
            bool res = true;
            /****验证交易合法性****/
            //TODO：
            return res;
        }
    }
}