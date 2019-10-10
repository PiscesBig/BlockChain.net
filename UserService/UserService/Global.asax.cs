using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace UserService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Users.User.ID = "3";
            Users.User.Name = "jtm";
            Users.User.PubKey = "<RSAKeyValue><Modulus>iCVlOLm9I90/Ic8d5AIGsBL4ARzNcM5aD6bPDtAcMCqHl4SlzJEhukwvdsKozNG9zYHz5EVHS5bSjhLe6a60LBchR1B2jpMl1CAdLjroiTqPb8plK+sWgQ5dZ0WQM6ciAqkiwrLkSUaCPs1uxQIBMAm5UU6941uzjxhxmVfm5ps=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            Users.User.PriKey = "<RSAKeyValue><Modulus>iCVlOLm9I90/Ic8d5AIGsBL4ARzNcM5aD6bPDtAcMCqHl4SlzJEhukwvdsKozNG9zYHz5EVHS5bSjhLe6a60LBchR1B2jpMl1CAdLjroiTqPb8plK+sWgQ5dZ0WQM6ciAqkiwrLkSUaCPs1uxQIBMAm5UU6941uzjxhxmVfm5ps=</Modulus><Exponent>AQAB</Exponent><P>tvga5N0YW7lGTD2GAHZUWoOxYnTLdr9Qi9RBCI66OVElEgaH6v8pFreBB0sEXln3Brb1eY2BTALGhfXFjSG9aQ==</P><Q>vnzhYaEaA/hsTunZCjhy+CEcPJGrvyzeTVJxgvV710Ps0FtsDLIhLOfbKWORf+tmEHrikFzltRVje7EMeAWPYw==</Q><DP>oycTnDbGzKumUr+dqPXa/CdoWnn5IDcylK09HGthBVElNDCcrGDA+9+/74fmKlggnV0yASS8QdJLwhJJCTMn2Q==</DP><DQ>rTGYLo8uuzttJpbiOrO2fLqGFOARuwGNodn60SpoDgJ5V7w30pdHKLAqiUg5a4hZRVSlmMKOLIYk7Lq+boYHpw==</DQ><InverseQ>Y6S5vAx6qLICDJkX1R6ukSIR4vRwA8ggXAe5Jh9VRguqlb9hyfU+/T1nkU/wjRbwgIcA2M0KEnBUtdaFiRh47Q==</InverseQ><D>C2sbfLDzQIVHTLYauytCVVUZ8LnyLwJXglWKqyLgIlgGzDnnT+tiKUZHes3jq13x7cD27A+1ZY0ONrU1deLdoG+zzA1Xg6AbHs6QcSKJzY3+W0CI7l39YSyuXGT4KXoNcwowVIZVxhZ/YeMkqS91isElhJG1rQnKW6WYNzRk9mk=</D></RSAKeyValue>";
            Users.User.IP = "localhost"; ;
            Users.User.Port = "58495";
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }       
    }
}
