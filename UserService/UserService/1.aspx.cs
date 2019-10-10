using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserService
{
    public partial class _1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn1_Click(object sender, EventArgs e)
        {            
            
        // string data = new Tools.HttpHelper().HttpGet("http://localhost:58465/api/IPSelect/getpublicKey?id=1");
        string data1 = new Controllers.DealController().getDealChecked("我想问您一个问题，我用C#实现的RSA加密每次只能加密117个字节，我想分段加密让后结果拼接起来，我用什么字符作为中间分隔符比较合适呢？这个字符或者是自负组合一定是密文中不能存在的组合吧。我现在也想不到有什么好的组合。谢谢老师");
            string data2 = new Controllers.DealController().getDealChecked("我想问您一个问题，我用C#实现的RSA加密每次只能加密117个字节，我想分段加密让后结果拼接起来，我用什么字符作为中间分隔符比较合适呢？这个字符或者是自负组合一定是密文中不能存在的组合吧。我现在也想不到有什么好的组合。谢谢老师");
            string data3 = new Controllers.DealController().getDealChecked("我想问您一个问题，我用C#实现的RSA加密每次只能加密117个字节，我想分段加密让后结果拼接起来，我用什么字符作为中间分隔符比较合适呢？这个字符或者是自负组合一定是密文中不能存在的组合吧。我现在也想不到有什么好的组合。谢谢老师");
            string data4 = new Controllers.DealController().getDealChecked("我想问您一个问题，我用C#实现的RSA加密每次只能加密117个字节，我想分段加密让后结果拼接起来，我用什么字符作为中间分隔符比较合适呢？这个字符或者是自负组合一定是密文中不能存在的组合吧。我现在也想不到有什么好的组合。谢谢老师");
            string data5 = new Controllers.DealController().getDealChecked("我想问您一个问题，我用C#实现的RSA加密每次只能加密117个字节，我想分段加密让后结果拼接起来，我用什么字符作为中间分隔符比较合适呢？这个字符或者是自负组合一定是密文中不能存在的组合吧。我现在也想不到有什么好的组合。谢谢老师");
            string data6= new Controllers.DealController().getDealChecked("我想问您一个问题，我用C#实现的RSA加密每次只能加密117个字节，我想分段加密让后结果拼接起来，我用什么字符作为中间分隔符比较合适呢？这个字符或者是自负组合一定是密文中不能存在的组合吧。我现在也想不到有什么好的组合。谢谢老师");
            string data7 = new Controllers.DealController().getDealChecked("我想问您一个问题，我用C#实现的RSA加密每次只能加密117个字节，我想分段加密让后结果拼接起来，我用什么字符作为中间分隔符比较合适呢？这个字符或者是自负组合一定是密文中不能存在的组合吧。我现在也想不到有什么好的组合。谢谢老师");
            string data8 = new Controllers.DealController().getDealChecked("我想问您一个问题，我用C#实现的RSA加密每次只能加密117个字节，我想分段加密让后结果拼接起来，我用什么字符作为中间分隔符比较合适呢？这个字符或者是自负组合一定是密文中不能存在的组合吧。我现在也想不到有什么好的组合。谢谢老师");
            string data9 = new Controllers.DealController().getDealChecked("我想问您一个问题，我用C#实现的RSA加密每次只能加密117个字节，我想分段加密让后结果拼接起来，我用什么字符作为中间分隔符比较合适呢？这个字符或者是自负组合一定是密文中不能存在的组合吧。我现在也想不到有什么好的组合。谢谢老师");

            string data10 = new Controllers.DealController().getDealChecked("我想问您一个问题，我用C#实现的RSA加密每次只能加密117个字节，我想分段加密让后结果拼接起来，我用什么字符作为中间分隔符比较合适呢？这个字符或者是自负组合一定是密文中不能存在的组合吧。我现在也想不到有什么好的组合。谢谢老师");
            new Services.Block().setblock();
            //string data =new Controllers.IPSelectController().getIP("dsadsadasdsadasdasdasd");
            lab1.Text = data1;
        }
    }
}