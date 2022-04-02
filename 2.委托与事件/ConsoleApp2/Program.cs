using System;
using System.Linq;
/*----事件Event
 * 1.语法：声明委托前面加Event
 * 2.事件作用是在事件内与委托一致享有委托的所有功能，在事件外，仅能使用委托的+ -功能；
 * 3.dotnet定义的事件类，System.EventArgs 
 */
namespace ConsoleApp2
{
    internal class Program
    {
        static event Action ea;       //类内与委托一致，类外仅能进行委托+ ，-操作
        static void Main(string[] args)
        {
            ea = Method1;
            ea = ea + Method2;
            ea = ea + Method3;
            ea();
        }
        public static void Method1()
        {
            Console.WriteLine("i am method1.");
        }

        public static void Method2()
        {
            Console.WriteLine("i am method2.");
        }

        public static void Method3()
        {
            Console.WriteLine("i am method3.");
        }
    }
}
