using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Config1.Program;

namespace Config1
{
    internal class TestReadConfig2
    {
        private readonly IOptionsSnapshot<Proxy> optProxy;
        public TestReadConfig2(IOptionsSnapshot<Proxy> optProxy)
        {
            this.optProxy = optProxy;
        }
        public void Test()
        {
            Console.WriteLine(optProxy.Value.Address);
            Console.WriteLine(optProxy.Value.Port);
        }
    }
     class Proxy
    {
        public string Address { get; set; }
        public string Port { get; set; }
    }
}
