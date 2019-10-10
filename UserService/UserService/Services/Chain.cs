using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using UserService.Users;

namespace UserService.Services
{
    /// <summary>
    /// markle树生成
    /// </summary>
    public class Chain
    {
        

        public void settree()
        {
            Thread settree = new Thread(tree);
            settree.Start();
        }
        public static Boolean flag = true;
        public void tree()
        {
            Boolean flag = true;//关闭信号
            while (flag)
            {


            }
        }




        /* public static void Main()
         {
             //1.链表的声明以及节点的定义
             LinkedList<string> link = new LinkedList<string>(); //定义链表
             LinkedListNode<string> node1 = new LinkedListNode<string>("jiajia"); //第一个节点
             LinkedListNode<string> node2 = new LinkedListNode<string>("jiajia2"); //第二个节点s
             LinkedListNode<string> node3 = new LinkedListNode<string>("jiajia3");
             LinkedListNode<string> node4 = new LinkedListNode<string>("jiajia5");

             //2.节点的加入
             link.AddFirst(node1); //加入第一个节点
             link.AddAfter(node1, node2);
             link.AddAfter(node2, node3);
             link.AddAfter(node3, node4);

             //3.计算包含的数量
             Console.WriteLine(link.Count);

             //4.显示
             LinkedListNode<string> current = link.First;
             while (current != null)
             {
                 Console.WriteLine(current.Value);
                 current = current.Next;
             }

             //5.查找
             LinkedListNode<string> temp = link.Find("jiajia2");
             if (temp != null)
             {
                 Console.WriteLine("找到这个节点" + temp.Value);
             }

             //6.定位最后节点
             temp = link.Last;
             Console.WriteLine("最后这个节点" + temp.Value);

             //7.一些删除操作
             link.RemoveFirst();
             link.Remove("jiajia2");
             link.Clear();

         }*/

    }
}