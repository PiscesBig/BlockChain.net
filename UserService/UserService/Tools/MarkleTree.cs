using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserService.Tools
{
    public class MarkleTree
    {
        /// <summary>
        /// 生成hash
        /// </summary>
        /// <returns></returns>
        public string settree(ArrayList hashs)
        {
            string lasthash = "";//最终MarkleTree的头
            int count = hashs.Count;//哈希值个数
            while (count>1)//哈希值个数大于一时执行，等于一时结束
            {
                int half =(int)Math.Ceiling((double)count /2);//向上取整 一半个数
                ArrayList halfhash = new ArrayList(half);//重新创建列表
                for (int i = 0; i < half; i++)//哈希值两两重新计算 h12=hash(h1+h2)
                {
                    string hash1=hashs[2*i].ToString();//第一个hash
                    string hash2;
                    if (2 * i + 1 >= count){//若最后一个为单数无法凑对则复制自身
                        hash2 = hash1;
                    }else{
                        hash2 = hashs[2 * i+1].ToString();//第二个hash
                    }
                    string hashthis = new Tools.Hash().Hash_SHA_256(hash1+hash2);//计算hash
                    halfhash.Add(hashthis);
                }
                count = half;//hash个数变为一半
                hashs = halfhash;//hash数组更换进入下一轮
            }
            lasthash = hashs[0].ToString();//获取头
            return lasthash;
        }
    }
}