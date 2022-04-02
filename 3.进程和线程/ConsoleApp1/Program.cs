/*----进程与线程
 * 1.进程（一列火车）：一个应用程序就是一个进程；Process类，命名空间：System.Diagnostics  
 * （1）运行进程 Process.start();
 * (2)查看所有进程：Process[] allProcess = Process.GetProcesses();
 *（3）查看当前进程：Process curProcess = Process.GetCurrentProcess()
 *(4)杀死进程：curProcess.kill();
 *
 * 2.线程：Thread类,命名空间：System.Threading（车厢）
 * (1)前台线程：只有所有前台线程都关闭，才能关闭程序。 (默认是前台线程)
 *（2）后台线程：只要前台线程结束，后台线程自动结束；thread.IsBackground = true;
 * (3) 静态类进线程与非静态类进线程
 * (4)启动线程：thread.start();
 * (5)暂停线程：thread.Sleep(1);
 * (6)中止线程：thread.Abort();
 * (7)线程名；thread.name
 * (8)当前线程：thread.CurrentsThread
 *注意：当线程中的方法有参数时，其参数类型必须是object类型
 *
 *3.一个程序（进程）同时做多个事情（线程）；
 *4.winform默认禁止UI线程间访问（原因会检查线程）；
 *解决方案：取消检查Control.CheckForIllegalCrossThreadCalls = false;
 */

using System.Diagnostics;
using System.Threading;

namespace ConsoleApp1
{
     class Program
    {
        static void Main(string[] args)
        {
            
            string threadName = Thread.CurrentThread.Name;      //线程名
            Console.WriteLine("线程名是{0}", threadName);
            Thread.Sleep(5000);     //主线程休眠5s在启动  
            //获取当前所有进程
            Console.WriteLine("获取当前所有进程");
            Process[] allProcess = Process.GetProcesses();
            foreach (Process item in allProcess)
            {
                Console.WriteLine(item.ToString());
            }
            //获取当前进程
            Console.WriteLine("获取当前进程");
            Process currentP = Process.GetCurrentProcess();
            Console.WriteLine(Process.GetCurrentProcess().ToString());
            //结束进程
            //currentP.Kill();

            //使用进程启动应用
             //Process.Start("calc");     //"calc" ：计算器命令;
            // Process.Start("mspaint");   //"mspaint":微软画图命令

            Process.Start("explorer", "https://www.baidu.com"); //"打开浏览器"，"网址"；

            //创建线程；
            TestThread1 p1 = new TestThread1();
            Thread thread1 = new Thread(p1.Test); //实例类方法进线程,方法名做参数（委托）
            thread1.IsBackground = true;         //设置后台线程
            thread1.Start();                      //启动线程
            Thread thread2 = new Thread(TestThread2.Test);  //静态类方法进线程
            thread2.Start();                        //启动线程
           // thread2.Abort();                        //中止线程,控制台应用程序不支持,一旦关闭不可以打开

            Console.ReadKey();
            Console.WriteLine();
        }
        public class TestThread1
        {
            public void Test()
            {
               Console.WriteLine("实例类方法进后台线程");
            }
        }

        public static class TestThread2
        {
            public static void Test()
            {           
                    Console.WriteLine("静态类方法进前台线程");
            }
        }
        


    }
}
