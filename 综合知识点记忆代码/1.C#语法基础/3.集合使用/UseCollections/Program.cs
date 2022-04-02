using System;
using System.Collections;
using System.Collections.Generic;
/*集合的使用
*/
namespace UseCollections
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
           ArrayList al = new ArrayList();
            //for (int i = 0; i < 10; i++)
            //{
            //    al.Add(i);
            //}
            //foreach (var item in al)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(al[0]);
            //al.Add("asd");
            //Console.WriteLine(al[10]);
            //Console.WriteLine($"al长度是{al.Count}");
            //al.Remove(9); //删除al的值
            //Console.WriteLine($"al长度是{al.Count}");
            //al.RemoveAt(9);//删除al索引对应的值
            //int[] arryint = new int[5]{ 23, 24, 25, 26, 27 };  
            //al.AddRange(arryint);
            //foreach (var item in al)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine($"23的位置{ al.IndexOf(23)}");
            //Console.WriteLine($"al中有9吗？{ al.Contains(9)}");
            //al.Clear();
            //Console.WriteLine($"al长度是{al.Count}");
            Hashtable hash = new Hashtable();
            hash.Add(1,"我是第一个");
            hash.Add("一", "我也是第一个");
            hash.Add(2, 1);
            hash[4] = "A";
            foreach (var item in hash.Keys)
            {
                Console.WriteLine($"key is {item},value is {hash[item]}");
            }
            List<int> list = new List<int>();

           Dictionary<string, int> dictionary = new Dictionary<string, int>();

    }
    }
}
