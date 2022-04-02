using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TestServiceLmpl3:ITestService
    {
        public string Name { get; set; }

        public void SayHi()
        {
            Console.WriteLine($"阿尼哈塞呦 ，瓦达西瓦 {Name}得丝");
        }
    }
}
