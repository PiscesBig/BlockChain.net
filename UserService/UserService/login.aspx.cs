using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace UserService
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            DataTable dt;
            string name = txt1.Text.Trim();
            string pwd = txt2.Text.Trim();
            string url = Request.Url.ToString();
            url = url.Split('/')[2];
            string ip = url.Split(':')[0];
            string port = url.Split(':')[1].Split('/')[0];
            string res = new Tools.HttpHelper().HttpGet("http://10.14.4.167:9503/api/IPSelect/getuser?ip=" + ip+"&port="+port+"&name="+name+"&pwd="+pwd);//注册（一次）
            try
            {
                lab1.Text = res;
                dt = new Tools.jstodt().ToDataTable(res);
                new Models.User().setuser(dt.Rows[0]["User_ID"].ToString(),name, dt.Rows[0]["User_PriKey"].ToString(), dt.Rows[0]["User_PubKey"].ToString(),ip,port);
            }
            catch (Exception)
            {
                lab1.Text = res;
            }
        }
    }
}