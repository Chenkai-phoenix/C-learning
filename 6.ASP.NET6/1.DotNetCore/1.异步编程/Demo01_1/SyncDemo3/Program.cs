using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
/*----为什么有的异步方法没有关键字Async？
* 因为没有使用await关键字调用；
* 使用普通方法调用；
* 
* ----async,await使用环境
（1）返回值是TASK的不一定必须用async，写async只是为了使用await取值；
（2）当一个异步方法仅仅对另一个异步方法进行调用，没有过复杂逻辑，可以不加Async，使用普通方法调用规则

----异步方法中的延时
（1）不建议用thread.sleep(),有可能阻塞主线程;
（2）使用await Task.Delay();
案例：

*/
namespace SyncDemo3
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string str1 = await Test1(); //异步正常写法
            Console.WriteLine("Test1结果是：{0}", str1);

            Task<string> taskString = Test2(); //普通方法调用规则
            string str2 = taskString.Result;
            Console.WriteLine("Test2结果是：{0}", str2);
            /*输出结果一样；
             * await 将task<string>的string的值直接取到；await必须和async配合使用
             * 普通调用返回task<string>类型，需要.resault获取string的值
             */
            //异步方法中的延时
            await DelayTest();

        }
        static async Task<string> Test1()
        {
            return await File.ReadAllTextAsync(@"1.txt");   //await和async必须同时使用,与不使用的返回值类型不同
        }
        static Task<string> Test2()
        {
            return File.ReadAllTextAsync(@"1.txt");      //不使用的返回值类型是task<string>;
        }
        static async Task DelayTest()
        {
            using ( HttpClient httpclient = new HttpClient())
            {
                string str1 = await httpclient.GetStringAsync("https://www.baidu.com");
                Console.WriteLine(str1.Substring(0,10));
            }
            await Task.Delay(5000);

            using (HttpClient httpclient = new HttpClient())
            {
                string str1 = await httpclient.GetStringAsync("https://www.baidu.com");
                Console.WriteLine(str1.Substring(10, 20));
            }

        }
    }
}
