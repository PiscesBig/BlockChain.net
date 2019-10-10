using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace CenterService.Models
{
    public class User
    {
        public DataTable setadmin(string pubkey,string prikey )
        {
            DataTable res;
            string sql = "select * from TB_User where User_ID = 1  ";
            res = new SQLHelper().ExcuteQuery(sql, CommandType.Text);
            if (res.Rows.Count > 0)
            {
                return res;//若已存在则不需添加
            }
            sql = "insert into TB_User (User_Name,User_PubKey,User_PriKey) values ('Admin',@pubkey,@prikey)";
            SqlParameter[] paras = {new SqlParameter("@pubkey",pubkey),new SqlParameter("@prikey", prikey) };
            int flag = new SQLHelper().ExcuteNonQuery(sql, paras, CommandType.Text);
            if (flag > 0)
            {
                res = new DataTable();//制空为添加成功
            }
            else {
                res = new DataTable();
                res.Rows.Add();
                res.Rows.Add();
            }//两行为添加失败
            return res;
        }
        public DataTable setuser(string ip, string port, string name, string pwd)
        {
            string res = "";
            string sql = "select * from TB_User u inner join TB_IPList IP on u.User_ID = ip.Sel_User where (ip.Sel_IP = @ip and ip.Sel_Port = @port) or u.User_Name = @name";
            SqlParameter[] para1 = { new SqlParameter("@ip", ip), new SqlParameter("@port", port), new SqlParameter("@name", name) };
            DataTable dt = new Models.SQLHelper().ExcuteQuery(sql, para1, CommandType.Text);
            if (dt.Rows.Count != 0)
            {
                return new DataTable();
            }
            string[] keys = new Tools.Encrypt().CreateRSAKey();//创建秘钥
            sql = "insertuser";
            SqlParameter[] para2 = {
                new SqlParameter("@ip", ip),
                new SqlParameter("@port", port),
                new SqlParameter("@name", name),
                new SqlParameter("pubkey",keys[0]),
                new SqlParameter("prikey",keys[1]) };
            dt = new Models.SQLHelper().ExcuteQuery(sql, para2, CommandType.StoredProcedure);            
            return dt;
        }
        public string getpublickey(string id)
        {
            string res;
            string sql = "select User_PriKey from TB_User where User_ID = @id";//私钥是这里的公钥，用于解密
            SqlParameter[] paras = { new SqlParameter("@id", id) };
            DataTable dt = new Models.SQLHelper().ExcuteQuery(sql,paras,CommandType.Text);
            res = new Tools.jstodt().ToJson(dt);
            return res;
        }
    }
}