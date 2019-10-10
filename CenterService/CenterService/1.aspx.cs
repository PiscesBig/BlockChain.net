using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CenterService
{
    public partial class _1 : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            /* Thread t = new Thread(test);            
             //string a = new HttpHelper().HttpGet("http://localhost:58495/api/Values/Get?id=1");
             t.Start();*/
           string[] test =  new Tools.Encrypt().CreateRSAKey();
            string pub = test[1];
            string pri = test[0];
            string sss = new Tools.Encrypt().RSAEncrypt("123456abcd", pub);
            string sss2 = new Tools.Encrypt().RSADecrypt(sss, pri);

            //lab1.Text = now;
            //lab1.Text = ss1+"----"+ss2+"---"+ss3;


            //Get异步回调

        }


         void test()
        {
            new Tools.HttpHelper().HttpGetAsync("http://localhost:58495/api/Values/");
            new Tools.HttpHelper().HttpGetAsync("http://localhost:58495/api/Values/Get?id=1", DownStringCompleted);
            new Tools.HttpHelper().HttpGetAsync("http://localhost:58495/api/Values/Get?id=1");
            new Tools.HttpHelper().HttpGetAsync("http://localhost:58495/api/Values/Get?id=1", DownStringCompleted);
            new Tools.HttpHelper().HttpGetAsync("http://localhost:58api/Values/Get?id=1");
            new Tools.HttpHelper().HttpGetAsync("http://localhost:58i/Values/Get?id=1", DownStringCompleted);
            new Tools.HttpHelper().HttpGetAsync("http://localhost:58495/api/Values/Get?id=1");
            new Tools.HttpHelper().HttpGetAsync("http://localhost:58495/api/Values/Get?id=1", DownStringCompleted);
            new Tools.HttpHelper().HttpGetAsync("http://localhost:58495/api/Values/Get?id=1");
            new Tools.HttpHelper().HttpGetAsync("http://localhost:58495/api/Values/Get?id=1", DownStringCompleted);
            new Tools.HttpHelper().HttpGetAsync("http://localhost:58495/api/Values/Get?id=1");
            new Tools.HttpHelper().HttpGetAsync("http://localhost:58495/api/Values/Get?id=1", DownStringCompleted);
        }

        private  void DownStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            
            Thread.Sleep(1000*60);
            lab1.Text += e.Result;
        }

        private void UploadDataCompleted(object sender, UploadDataCompletedEventArgs e)
        {
            Response.Write(Encoding.GetEncoding("GB2312").GetString(e.Result));
        }
    }
}