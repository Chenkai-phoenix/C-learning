/*----编写异步方法
 * ---(1)异步方法内的await 前后线程ID测试 可能一样，可能不同；
 * ----（2）异步方法内手动使用新线程，Thread，TASK.Run（委托）
 */
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncDemo2
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            string filepath = @"1.txt";
            await DownLoadAsync("https://www.baidu.com", filepath);
            string htlm = File.ReadAllText(filepath);
            Console.WriteLine("ok");
            Console.WriteLine("html is {0}", htlm);
            Console.WriteLine("异步方法调用前后ThreadID测试。");
            Console.WriteLine("ThreadIDtest1异步方法调用前ThreadID：{0}", Thread.CurrentThread.ManagedThreadId);
            await ThreadIDtest1();
            Console.WriteLine("ThreadIDtest1异步方法调用后ThreadID：{0}", Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("ThreadIDtest2异步方法手动调用新线程前ThreadID：{0}", Thread.CurrentThread.ManagedThreadId);
            await ThreadIDtest2();
            Console.WriteLine("ThreadIDtest2异步方法手动调用新线程后ThreadID：{0}", Thread.CurrentThread.ManagedThreadId);


        }
        static async Task DownLoadAsync(string url, string filename)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                string html = await httpclient.GetStringAsync(url); //获取网页源码
                await File.WriteAllTextAsync(filename, html);
            }

        }

        //前后线程ID测试 
        static async Task ThreadIDtest1()
        {
            Console.WriteLine("异步方法内Await前后ThreadID测试。");
            Console.WriteLine("Await前{0}", Thread.CurrentThread.ManagedThreadId);
            string pathname = @"ThreadIDtest.txt";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10000; i++)
            {
                sb.Append("writing...");
            }
            await File.WriteAllTextAsync(pathname, sb.ToString());
            Console.WriteLine("Await后{0}", Thread.CurrentThread.ManagedThreadId);
        }
        //异步方法手动调用新线程
        static async Task<string> ThreadIDtest2()
        {

            return await Task.Run(() =>          //手动使用新线程
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 10000; i++)
                {
                    sb.Append("writing...");
                }
                return sb.ToString();     //返回给Task.Run（）一个task<string>类型；
            });
        }
    }
}
