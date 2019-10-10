using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Net;
using System.Text;

namespace CenterService.Tools
{
    public class HttpHelper
    {        
        /// <summary>  
        /// Http同步Get同步请求  
        /// </summary>  
        /// <param name="url">Url地址</param>  
        /// <param name="encode">编码(默认UTF8)</param>  
        /// <returns></returns>  
        public  string HttpGet(string url, Encoding encode = null)
        {
            string result="404";//默认报错
            try
            {
                

                try
                {
                    var webClient = new WebClient { Encoding = Encoding.UTF8 };

                    if (encode != null)
                        webClient.Encoding = encode;

                    result = webClient.DownloadString(url);
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }               
            }
            catch (Exception e) { }
            result = result.Substring(1);
            result = result.Remove(result.Length - 1, 1);//删除自动添加的首尾的""
            result = result.Replace("\\\"", "\"");//将自动生成的\"换成"
            return result;
        }

        /// <summary>  
        /// Http同步Get异步请求  
        /// </summary>  
        /// <param name="url">Url地址</param>  
        /// <param name="callBackDownStringCompleted">回调事件</param>  
        /// <param name="encode">编码(默认UTF8)</param>  
        public  void HttpGetAsync(string url,
            DownloadStringCompletedEventHandler callBackDownStringCompleted = null, Encoding encode = null)
        {
            try
            {
                var webClient = new WebClient { Encoding = Encoding.UTF8 };

                if (encode != null)
                    webClient.Encoding = encode;

                if (callBackDownStringCompleted != null)
                    webClient.DownloadStringCompleted += callBackDownStringCompleted;

                webClient.DownloadStringAsync(new Uri(url));

            }
            catch (Exception e)
            { }           
        }

        /// <summary>  
        ///  Http同步Post同步请求  
        /// </summary>  
        /// <param name="url">Url地址</param>  
        /// <param name="postStr">请求Url数据</param>  
        /// <param name="encode">编码(默认UTF8)</param>  
        /// <returns></returns>  
        public  string HttpPost(string url, string postStr = "", Encoding encode = null)
        {
            string result;

            try
            {
                var webClient = new WebClient { Encoding = Encoding.UTF8 };

                if (encode != null)
                    webClient.Encoding = encode;

                var sendData = Encoding.GetEncoding("GB2312").GetBytes(postStr);

                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                webClient.Headers.Add("ContentLength", sendData.Length.ToString(CultureInfo.InvariantCulture));

                var readData = webClient.UploadData(url, "POST", sendData);

                result = Encoding.GetEncoding("GB2312").GetString(readData);

            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            result = result.Substring(1);
            result = result.Remove(result.Length - 1, 1);//删除自动添加的首尾的""
            result = result.Replace("\\\"", "\"");//将自动生成的\"换成"
            return result;
        }

        /// <summary>  
        /// Http同步Post异步请求  
        /// </summary>  
        /// <param name="url">Url地址</param>  
        /// <param name="postStr">请求Url数据</param>  
        /// <param name="callBackUploadDataCompleted">回调事件</param>  
        /// <param name="encode"></param>  
        public  void HttpPostAsync(string url, string postStr = "",
            UploadDataCompletedEventHandler callBackUploadDataCompleted = null, Encoding encode = null)
        {
            try
            {
                var webClient = new WebClient { Encoding = Encoding.UTF8 };

                if (encode != null)
                    webClient.Encoding = encode;

                var sendData = Encoding.GetEncoding("GB2312").GetBytes(postStr);

                webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                webClient.Headers.Add("ContentLength", sendData.Length.ToString(CultureInfo.InvariantCulture));

                if (callBackUploadDataCompleted != null)
                    webClient.UploadDataCompleted += callBackUploadDataCompleted;

                webClient.UploadDataAsync(new Uri(url), "POST", sendData);
            }
            catch (Exception e)
            {            }
           
        }


/*
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(HttpCommon.HttpGet("http://localhost:14954/WebForm4.aspx"));                          //Get同步  
            HttpCommon.HttpGetAsync("http://localhost:14954/WebForm4.aspx");                                     //Get异步  
            HttpCommon.HttpGetAsync("http://localhost:14954/WebForm4.aspx", DownStringCompleted);                //Get异步回调  

            Response.Write(HttpCommon.HttpPost("http://localhost:14954/WebForm4.aspx", "post=POST"));            //Post同步  
            HttpCommon.HttpPostAsync("http://localhost:14954/WebForm4.aspx", "post=POST");                       //Post异步  
            HttpCommon.HttpPostAsync("http://localhost:14954/WebForm4.aspx", "post=POST", UploadDataCompleted);  //Post异步回调  
        }

    */      

    }
}