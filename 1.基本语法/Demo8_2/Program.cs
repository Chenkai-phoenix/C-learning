//多态综合案例---超市收银系统
/*
 * 1.GUID:唯一身份码，结构体类型，GUID.newGUID() 返回一个GUID结构实例；Guid.NewGuid().ToString();
 * 
 */
using System;

namespace Demo8_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            SuperMarket sm1 = new SuperMarket();
            sm1.ShowProducts();  //原有货物
            sm1.AskBuying();     //用户买完
            sm1.ShowProducts();  //剩余货物
            Console.WriteLine();
            Console.ReadKey();       
        }
    }
}
