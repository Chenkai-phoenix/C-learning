using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Config2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConfigurationBuilder cb = new ConfigurationBuilder();
            cb.AddCommandLine(args);
            IConfigurationRoot configRoot = cb.Build();
            //用命令行传参 项目右键--属性--调试--general--打开调试启动ui--命令行参数
            string name = configRoot["name"];
            string age = configRoot["age"];
            //多级结构如何命令行传参---扁平化处理使用：
            string address = configRoot["proxy:address"];
            string port = configRoot["proxy:port"];

            List<string> ids = new List<string>();
            ids.Add(configRoot["proxy:ids:0"]);
            ids.Add(configRoot["proxy:ids:1"]);
            Console.WriteLine(name);
            Console.WriteLine(age);
            Console.WriteLine(address);
            Console.WriteLine(port);
            Console.WriteLine(ids[0]);
            Console.WriteLine(ids[1]);


        }
    }
}
