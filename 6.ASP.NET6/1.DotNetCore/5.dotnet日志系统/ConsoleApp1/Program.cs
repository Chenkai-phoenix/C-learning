using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using SystemServices;
/*----日志输出到控制台
* 1.nuget：Microsoft.Extensions.Logging；Microsoft.Extensions.Logging.Console
* 2. DI输出日志步骤
（1）创建DI容器
（2）注册服务
（3）设置日志的输出方式[按需要设置输出级别]
（4）获取日志服务


*/
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<LoggingDemo1>(); //注册服务
            services.AddScoped<LoggingDemo2>(); //注册服务
            services.AddLogging(logBuilder =>     //设置日志的输出方式
            {
                //logBuilder.AddConsole();          
                //logBuilder.SetMinimumLevel(LogLevel.Trace);  //最低日志级别输出设置，默认只输出warning级别及以上的日志，
                logBuilder.AddNLog();     //Nlog日志输出到文本
            });
            
            using (ServiceProvider sp = services.BuildServiceProvider())
            {
                LoggingDemo1 logDemo1 = sp.GetRequiredService<LoggingDemo1>();
                logDemo1.Test();

                //通过修改Nlog配置文件输出指定类下的日志
                LoggingDemo2 logDemo2 = sp.GetRequiredService<LoggingDemo2>();
                for (int i = 0; i < 10000; i++)
                {
                    logDemo2.Test();
                }
                
            }
        }
    }
}
