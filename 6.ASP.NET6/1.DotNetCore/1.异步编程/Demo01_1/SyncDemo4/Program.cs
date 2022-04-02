using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
/*---异步编程之CancellationToken
*(1) CancellationToken结构体
* 成员：
None：空
bool IsCancellationRequested 是否取消
ThrowIfCancellationRequested（）； 若任务被取消，执行这句话就抛异常。
(2)使用用CancellationTokenSurce类初始化
a.可以new
b.CancelAfter():超时后发出取消信号；
c.Cancel():发出取消信号
d.this.Token：返回CancellationToken类型
案例：下载一个网站N次，若5秒没下载完，则下载取消；
(3)异步方法中有重载带有 CancellationToken参数时，由.net框架传值。

*/
namespace SyncDemo4
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await DownLoadEXP1("https://www.taobao.com", 100);
            CancellationTokenSource cltS = new CancellationTokenSource();
            cltS.CancelAfter(2000);
            CancellationToken clt = cltS.Token;    //通过给CancellationTokenSource对象赋值，使用.token给结构体赋值
            await DownLoadEXP2("https://www.taobao.com", 100, clt);
        }
        static async Task DownLoadEXP1(string url,int n) 
        {
            using ( HttpClient httpclient = new HttpClient())
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < n; i++)
                {
                    await httpclient.GetStringAsync(url);
                }
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds);
            }
        }

        //案例：下载一个网站N次，若2秒没下载完，则下载取消；
        static async Task DownLoadEXP2(string url, int n,CancellationToken cancellationTocken)
        {
            using (HttpClient httpclient = new HttpClient())
            {
                for (int i = 0; i < n; i++)
                {
                    await httpclient.GetStringAsync(url);
                    if (cancellationTocken.IsCancellationRequested)
                    {
                        Console.WriteLine("下载已经取消");
                        return;
                    }
                }
                Console.WriteLine("下载完成");
            }
        }
    }
}
