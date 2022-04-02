using System;
using ConfigServices;
using LogServices;
using MailServices;
using Microsoft.Extensions.DependencyInjection;
/*----DI综合案例
 * 1.目的：演示DI的能力
 * 2.有配置服务，日志服务，开发一个邮件发送器服务。可以用过配置服务来从文件，环境变量，数据库等地方读取配置，
 * 可以通过日志服务来将程序运行过程中的日志信息写入文件，控制台，数据库等；
 * 
 * 
 */
namespace Case1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            //services.AddScoped<IConfigServices,EnvVarConfigService>();
            //services.AddScoped(typeof(IConfigServices), s => new IniFileConfigService { FilePath = "mail.ini" });
            services.AddIniConfig("mail.ini");////ServiceCollection的扩展方法，优点：调用时不需要再知道接口名，类名

            //services.AddScoped<ILogProvider, ConsoleProvider>();
            services.AddConsoleLog(); //ServiceCollection的扩展方法，优点：调用时不需要再知道接口名，类名
            services.AddScoped<IMailService, MailService>();

            using (ServiceProvider sp = services.BuildServiceProvider())
            {
                using (IServiceScope iss = sp.CreateScope())
                {
                    IMailService mail = iss.ServiceProvider.GetRequiredService<IMailService>();
                    mail.send("hello", "280863017@qq.com", "凯总好");

                }
            }
        }
    }
}
