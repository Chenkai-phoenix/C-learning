using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class LoggingDemo1
    {
        //dotnet注入对象
        private readonly ILogger<LoggingDemo1> Ilogger;      //为什么ILogger<LoggingDemo1>要使用自身类类型
        public LoggingDemo1(ILogger<LoggingDemo1> ilogger)
        {
            this.Ilogger = ilogger;
        }

        public void Test()
        {
            Ilogger.LogDebug("开始运行。。。"); //因为ILogger对象的日志返回除了返回日志内容，还会返回日志所属类
            Ilogger.LogDebug("正在运行。。。");
            Ilogger.LogWarning("运行失败，正在重试。。。");
            Ilogger.LogError("运行异常。。。");
            try
            {
                File.ReadAllText("xxx.txt");
                Ilogger.LogDebug("读取完成");

            }
            catch (Exception ex)
            {
                Ilogger.LogError(ex,"读取失败");//LogError()重载，可以放异常的对象
            }
                
        }
    }
}
