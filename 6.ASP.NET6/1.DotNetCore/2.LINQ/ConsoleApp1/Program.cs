using System;
/*----泛型委托
 * 1.Action：无返回值委托类型
 * 2.Func：有返回值委托类型
 * 3.匿名方法委托
 * ----lambda表达式（匿名方法简化写法）
 * 1.可以只写形参，不需要写形参类型；
 * 2.当lambda方法体中无返回值且只有一行代码，也可以省略{}；
 * 3.当lambda方法体中有返回值且只有一行代码，可以同时省略{}和return；（必须同在同去）
 * 4.当lambda仅有一个参数，可以省略（）,没有参数必须写（）；
 */
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Func<int, int, int> func = SumTest1; //有返回值委托 Func<T, out T>;T与委托方法的参数个数，类型一致
            Console.WriteLine(func(3, 5));
            Action<int, int> act1 = SumTest2; //无返回值委托 Action<T>;T与委托方法的参数个数，类型一致
            act1(5, 5);
            Action act2 = delegate ()       //匿名方法委托
            {
                Console.WriteLine("普通匿名方法");
            };
            act2();
            Action act3 = () =>       //无参，无返回值lambda表达式
            {
                Console.WriteLine("无参，无返回值lambda表达式的匿名方法");
            };
            act3();
            Func<int, int, int> func1 = (i, j) =>  ////有参，有返回值lambda表达式
            {
                  return i + j; 
              };
            Console.WriteLine($"有参，有返回值lambda表达式的匿名方法,计算结果为：{func1(3,4)}"); 


        }
        static int SumTest1(int i, int j)
        {
            return i + j;
        }
        static void SumTest2(int i, int j)
        {
            Console.WriteLine(i + j);
        }
    }
}
