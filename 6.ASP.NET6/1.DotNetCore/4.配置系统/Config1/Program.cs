using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

/*----Json格式
1、准备：
（1）nuget：microsoft.extensions.configuration        //配置框架
（2）nuget：microsoft.extensions.configuration.json  //读取json
 (3).json文件属性为始终复制
2.配置读取方式一
（1）ConfigurationBuilder创建config框架
（2）.AddJsonFile()添加和设置配置文件
 (3).Build()读取到的配置文件
（4）IConfigurationRoot类接收读取到的配置文件根节点
3.配置读取方式二
（1）nuget： Microsoft.Extensions.Configuration.Binder;
 (2) T XXX = configRoot.GetSection("T").Get<T>() //将子节点的内容返回给子节点类的对象
4.推荐读取方式
(1)nuget：Microsoft.Extensions.Options
   nuget: Microsoft.Extensions.Configuration.Binder;
(2)读取配置时，DI声明IOptions<T>(不会读取到新值)；IoptionSnapShot(一定范围内保持不变)推荐；
                    IoptionMonitor（读取到新值）；
(3)读取步骤：
a>创建DI容器
b>注册服务
c>使用Option.Configure<t>()绑定配置文件根节点
d>获取DI服务
 */
namespace Config1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigurationBuilder configBuilder = new ConfigurationBuilder(); //创建config框架
            //AddJsonFile(string configpath,bool optional, bool reloadOnChange)
            //optional:true (如果没有文件报错);reloadOnChange:true（自动更新配置文件）
            configBuilder.AddJsonFile("jsconfig1.json", true, true);//添加和设置配置文件
            IConfigurationRoot configRoot1 = configBuilder.Build(); //读取配置文件根节点
            //配置读取方式一
            string name = configRoot1["name"];
            Console.WriteLine($"name is ：{name}");
            string address = configRoot1.GetSection("Proxy:address").Value;
            Console.WriteLine($"address is : {address}");

            //配置读取方式二
            Proxy proxy1 = configRoot1.GetSection("proxy").Get<Proxy>();
            Console.WriteLine($"address is {proxy1.Address},Port is {proxy1.Port}");

            Config configRoot2 = configRoot1.Get<Config>();
            Console.WriteLine($"name is {configRoot2.Name},age is {configRoot2.Age} ");
            //DI注册读取配置
            ServiceCollection services = new ServiceCollection();//创建DI容器
            services.AddScoped<TestReadConfig1>();   //注册服务读取
            services.AddScoped<TestReadConfig2>();
            //可以同时绑定多个节点
            services.AddOptions().Configure<Config>(e => configRoot1.Bind(e))   //绑定配置文件根节点
                                 .Configure<Proxy>(e => configRoot1.GetSection("Proxy").Bind(e));//绑定配置文件根节点
            //using (ServiceProvider sp = services.BuildServiceProvider())
            //{
            //    while (true)   //展示IOptionSnapShot<>不同范围时自动更新配置（测试：修改bin里的配置文件值）
            //    {
            //        using (IServiceScope iss = sp.CreateScope())
            //        {
            //            //获取DI服务
            //            TestReadConfig1 c1 = iss.ServiceProvider.GetRequiredService<TestReadConfig1>();
            //            c1.Test();
            //            Console.WriteLine("*********************************");
            //            //获取DI服务
            //            TestReadConfig2 c2 = iss.ServiceProvider.GetRequiredService<TestReadConfig2>();
            //            c2.Test();
            //        }
            //        Console.ReadKey();
            //    }

            //}

            using (ServiceProvider sp = services.BuildServiceProvider())
            {


                using (IServiceScope iss = sp.CreateScope())
                {
                    while (true)  //展示IOptionSnapShot<>在一定范围内不更新配置（测试：修改bin里的配置文件值）
                    {
                        //获取DI服务
                        TestReadConfig1 c1 = iss.ServiceProvider.GetRequiredService<TestReadConfig1>();
                        c1.Test();
                        Console.WriteLine("*********************************");
                        //获取DI服务
                        TestReadConfig2 c2 = iss.ServiceProvider.GetRequiredService<TestReadConfig2>();
                        c2.Test();
                        Console.ReadKey();
                    }
                }


            }

        }

    }
}
