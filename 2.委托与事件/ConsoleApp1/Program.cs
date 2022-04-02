/*----委托
 * 1.一种存储函数引用的类型，使用：delegate 返回值类型 委托类型名（参数列表）； 返回值类型，参数列表，与要引用的方法保持一致
 * 2.lanbda箭头:=>,类似c语言#define
 * 2.$:代替占位符，
 * string str1 = "ll";
   Console.WriteLine("Hello World!{0},{1}",str1); ========= Console.WriteLine($"Hello World!{str1}");
 * ----多播委托
 * 1.语法：Delegates d = Method1;   d = d+Method2(d += Method2);
 *  (1)当委托的方法都是void时调用顺序与方法的定义顺序一致；
 *  (2)当委托的方法不是void时，返回值是最后一个调用方法的返回值，前面的方法虽然会被调用但是返回值被弃用了；
 * ----泛型委托
 * delegate T d<T>(T);
 * .NET的定义个泛型委托，Action（无返回值），Func（T,OUT）(有返回值)
 * ----委托之间互补兼容，即时都是Deletage类型,不能相互转换
*/

using System;
using System.Threading;

namespace ConsoleApp1
{
    
    internal class Program
    {
        delegate double Params1(double n, double m);         //声明一个委托类型 ，返回值，参数列表与引用方法保持一致
        delegate double Params2(double n, double m);
        delegate void Delegates(int n);
        static double SUMtest(double a, double b) => a + b; //声明委托方法，lambda箭头相当于 #define 同时声明方法名和方法体 编译时替换 
        static void Main(string[] args)
        {
            Params1 P1 = new Params1(SUMtest); //委托实例
            Params2 P2 = new Params2(DIVIDEtest);
            double sum = P1(3, 3);
            double divid = P2(15, 3);
            Console.WriteLine($"和是{sum},商是{divid}.");
            //多播委托
            Delegates delegates = new Delegates(Method1);
            delegates = delegates + Method2;
            delegates(1);
            delegates = delegates - Method1;  //委托移除
            delegates(1);
        }
        public  static double DIVIDEtest(double n, double m)
        {
            return n / m;
        }
        public static void Method1(int n)
        {
            Console.WriteLine("我是method1.");
        }
        public static void Method2(int n)
        {
            Console.WriteLine("我是method2.");
        }
    }
}
