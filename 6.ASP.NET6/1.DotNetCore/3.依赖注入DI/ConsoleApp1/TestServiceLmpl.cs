using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TestServiceLmpl : ITestService
    {
        public string Name { get; set; }

        public void SayHi()
        {
            Console.WriteLine($"i am {Name}");
        }
    }
}
