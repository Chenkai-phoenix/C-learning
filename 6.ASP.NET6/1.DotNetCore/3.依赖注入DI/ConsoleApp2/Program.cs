using System;
using Microsoft.Extensions.DependencyInjection;
/*----DI的传染性
 * 优点：代码14,15行，如果对现有服务进行改变只需要改变服务注册，其余代码都不需要动。
 * 降低了模块间的耦合性。
 * 特点：dotnet的DI默认是构造函数注入；
 */
namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<IController, ControllerImpl>();
            //services.AddScoped<IConfigure, ConfigureImpl>();     //都是IConfigure，但对象不一样，无耦合性
            services.AddScoped<IConfigure, DBConfigureImpl>();
            services.AddScoped<ILog, LogImpl>();
            services.AddScoped<IStorage, StorageImpl>();
            using (ServiceProvider sp = services.BuildServiceProvider())
            {
                //只要注册IController，IController中使用到的其他服务接口都会由dotnet框架通过构造函数自动生成对象和传递
                IController control1 = sp.GetService<IController>();
                control1.ControllerShow();
            }

        }
    }
    interface IController
    {
        void ControllerShow();
    }
    class ControllerImpl : IController
    {
        private ILog log;
        private IStorage storage;
        
        public  ControllerImpl(ILog log, IStorage storage)
        {
            this.log = log;
            this.storage = storage;
        }
        public void ControllerShow()
        {
            this.log.Logs("开始上传。");
            this.storage.StorageSave("asdasdasdasdasdasd","1.txt");
            this.log.Logs("上传结束。");
        }
    }

    interface ILog
    {
        void Logs(string logmsg);
    }
    class LogImpl : ILog
    {
        public void Logs(string log)
        {
            Console.WriteLine($"log is: {log}");
        }
    }
    interface IConfigure
    {
        string GetValue(string name);
    }
    class ConfigureImpl : IConfigure
    {
        public string GetValue(string name)
        {
            return "Configure1";
        }
    }

    class DBConfigureImpl : IConfigure
    {
        public string GetValue(string name)
        {
            return "Configure2";
        }
    }

    interface IStorage
    {
        void StorageSave(string context, string pathname);
    }
    class StorageImpl : IStorage
    {
        private readonly IConfigure config;
        private readonly ILog log;
        public StorageImpl(IConfigure config)
        {
            this.config = config;
        }
        public void StorageSave(string context, string name)
        {
            string server =  config.GetValue("server");
            Console.WriteLine($"向服务器{server}的文件名为{name}上传{context}");
        }

    }
}
