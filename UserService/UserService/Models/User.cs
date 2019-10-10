using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserService.Models
{
    public class User
    {
        public void setuser(string id, string name,  string PriKey, string PubKey, string IP, string Port)
        {           
            Users.User.ID = id;
            Users.User.Name = name;
            Users.User.IP = IP;
            Users.User.Port = Port;
            Users.User.PriKey = PriKey;
            Users.User.PubKey = PubKey;
        }
           
    }
}