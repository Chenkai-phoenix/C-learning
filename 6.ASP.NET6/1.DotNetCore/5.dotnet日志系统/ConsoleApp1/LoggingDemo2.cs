using ConsoleApp1;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemServices
{
    internal class LoggingDemo2
    {
        //dotnet注入对象
        private readonly ILogger<LoggingDemo2> Ilogger;      //为什么ILogger<LoggingDemo1>要使用自身类类型
        public LoggingDemo2(ILogger<LoggingDemo2> ilogger)
        {
            this.Ilogger = ilogger;
        }

        public void Test()
        {
            Ilogger.LogDebug("开始运行。。。"); //因为ILogger对象的日志返回除了返回日志内容，还会返回日志所属类
            Ilogger.LogDebug("正在运行。。。");
            Ilogger.LogWarning("运行失败，正在重试。。。");
            Ilogger.LogError("运行异常。。。");
        }
    }
}
