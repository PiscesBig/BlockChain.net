using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using UserService.Users;

namespace UserService.Services
{
    public class Block
    {
        static Semaphore hashlock = new Semaphore(1, 1);
        //public static Mutex hashlock = new Mutex();//获取hash互斥信号量
        public static string hash;
        public static LinkedList<ChainNode> chain = new LinkedList<ChainNode>(); //定义链表
        public static Mutex chainlock = new Mutex();//互斥信号量
        public void setblock()//创建区块生成线程
        {
            Thread getblock = new Thread(block);
            getblock.Start();
        }
        public static Boolean flag = true;//关闭变量
        public static Boolean use = true;//该区块是否使用
        public static Mutex uselock = new Mutex();//互斥信号量



        
        string Markle;
        /// <summary>
        /// 生成区块线程处理
        /// </summary>
        public void block()
        {           
            Boolean flag = true;
            while (flag)
            {
                hash = "";
                #region 等待时钟
                /*----------等待时钟-------------//min
                 DateTime dateTime = new DateTime();
                 int min = 0;
                 do
                 {
                     dateTime = System.DateTime.Now;
                     min = dateTime.Minute;//取当前分钟
                 } while (min % 15 != 0);//15分时刻生成下一区块*/
                #endregion
                uselock.WaitOne();
                use = true;//先置为可传输
                uselock.ReleaseMutex();
                string lasthash = "";//上一区块hash  //TODO:获取上一个hash 
                //string blockhash = "";//本区块生成hashstring blockhash = "";//本区块生成hash
                string json = "";//全体原始数据
                //取出数据
                chainlock.WaitOne();//等待互斥信号量
                LinkedList<ChainNode> chains = chain;//取出当前要处理的数据
                chain = new LinkedList<ChainNode>();//初始化链表
                chainlock.ReleaseMutex();//释放互斥信号量
                int c = chains.Count;
                ArrayList hashlist = new ArrayList(c);               
                //markle 树生成
                int i = 0;
                while (chains.Count!=0)
                {                    
                    LinkedListNode<ChainNode> node = chains.First;
                    string thisdata = node.Value.data;
                    string thishash = node.Value.hash;
                    json += "{\"data\":\""+ thisdata + "\",\"hash\":\"" + thishash + "\"},";
                    hashlist.Add(thishash);
                    i++;
                    chains.RemoveFirst();//处理好每一个节点删除
                }                      
                if (hashlist.Count == 0){//若无数据不允许生成区块
                    continue;
                }
                else{
                    json = json.Substring(0, json.Length - 1);//删除最后多余的逗号         
                    Markle = new Tools.MarkleTree().settree(hashlist);
                    hashlock.WaitOne();
                    Thread gethash1 = new Thread(gethash);
                    gethash1.Start();
                    Thread gethash2 = new Thread(gethash);
                    gethash2.Start();
                    Thread gethash3 = new Thread(gethash);
                    gethash3.Start();
                    Thread gethash4 = new Thread(gethash);
                    gethash4.Start();
                    Thread gethash5 = new Thread(gethash);
                    gethash5.Start();
                    Thread gethash6 = new Thread(gethash);
                    gethash6.Start();
                    Thread gethash7 = new Thread(gethash);
                    gethash7.Start();
                    Thread gethash8 = new Thread(gethash);
                    gethash8.Start();                    

                    hashlock.WaitOne();
                    gethash1.Suspend();
                    gethash1.Interrupt();
                    gethash2.Suspend();
                    gethash2.Interrupt();
                    gethash3.Suspend();
                    gethash3.Interrupt();
                    gethash4.Suspend();
                    gethash4.Interrupt();
                    gethash5.Suspend();
                    gethash5.Interrupt();
                    gethash6.Suspend();
                    gethash6.Interrupt();
                    gethash7.Suspend();
                    gethash7.Interrupt();
                    gethash8.Suspend();
                    gethash8.Interrupt();
                    string hashs = hash;
                    hash = "";//置空中间变量
                    hashlock.Release();
                    //原位置
                }                
                #region 区块发送
                if (use)//开始发送区块
                {
                    //TODO:
                }
                #endregion                
            }
        }

        public void gethash()
        {
            string blockhash = "";//本区块生成hash
            #region 带随机数的hash            
            System.DateTime currentTime1 = new System.DateTime();
            System.DateTime currentTime2 = new System.DateTime();
            currentTime1 = System.DateTime.Now;
            string num = "";
            string front5;
            do
            {
                num = Membership.GeneratePassword(128, 1);                              
                blockhash = new Tools.Hash().Hash_SHA_256(num + "" + Markle);
                front5 = blockhash.Substring(0, 4);
            } while (front5 != "0000");
            currentTime2 = System.DateTime.Now;
            hash = blockhash;
            string s = (currentTime2 - currentTime1).ToString();//计算生成时间
            hashlock.Release();            
            while (true)
            {
                
            }
            #endregion
        }
    }
}