using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CenterService.Users
{
    public class User
    {
        public static string ID//ID地址
        {
            set;
            get;
        }
        public static string Name//姓名
        {
            set;
            get;
        }
        public static string PriKey//私钥
        {
            set;
            get;
        }
        public static string PubKey//公钥
        {
            set;
            get;
        }
        public static string IP//IP地址
        {
            set;
            get;
        }
        public static string Port//端口
        {
            set;
            get;
        }
    }
}