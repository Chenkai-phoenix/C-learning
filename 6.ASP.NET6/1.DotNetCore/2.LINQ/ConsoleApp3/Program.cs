using System;
using System.Collections.Generic;
using System.Linq;
/*----LINQ
* 1.命名空间：system.Linq;
* 2.where的使用及原理；
* 3.var:推断类型；编译时编译器根据赋值确定数据类型,编译时一旦确定类型不可改变。
*/
namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arry1 = new int[] { 1,2,4,64,77,58,345,789};
            IEnumerable<int> res1 = arry1.Where(i => i > 10); //where是system.Linq的扩展方法；where遍历集合的每个元素
            Console.WriteLine("res1 is :");
            foreach (int i in res1)
            {
                Console.WriteLine(i);
            }
            //where的原理，一般返回
            Func<int, bool> func1 = i => i > 10;
            IEnumerable<int> res2 = Mywhere1(arry1, func1); 
            Console.WriteLine("res2 is :");
            foreach (int i in res2)
            {
                Console.WriteLine(i);
            }
            //where的原理，yield返回
            IEnumerable<int> res3 = Mywhere2(arry1, func1);
            Console.WriteLine("res3 is :");
            foreach (int i in res3)
            {
                Console.WriteLine(i);
            }
        }


        //where的原理
        static IEnumerable<int> Mywhere1(IEnumerable<int> arry,Func<int,bool> func)
        {
            List<int> res = new List<int>();
            foreach (int i in arry)
            {
                if (func(i) == true)
                {
                    res.Add(i);
                }  
            }
            return res;    //所有集合处理完毕一起返回；
        }

        static IEnumerable<int> Mywhere2(IEnumerable<int> arry, Func<int, bool> func)
        {
            foreach (int i in arry)
            {
                if (func(i) == true)
                {
                   yield return i;  //获得一个数据立马返回，然后继续拿数据；
                    // yield return i;运行过程，第一个元素返回给res3后又返回到Mywhere2（）继续下一个foreach，
                    //再返回给res3，再回到Mywhere2（）继续下一个foreach，直到Mywhere2（）执行完毕。
                    //yield return;特色调用和被调用反复横跳。
                }
            }

        }
    }
}
