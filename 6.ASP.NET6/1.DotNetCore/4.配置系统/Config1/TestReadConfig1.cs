using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Config1.Program;

namespace Config1
{
    internal class TestReadConfig1
    {
        private readonly IOptionsSnapshot<Config> optConfig;
        public TestReadConfig1(IOptionsSnapshot<Config> optConfig1)
        {
            this.optConfig = optConfig1;
        }
        public void Test()
        {
            Console.WriteLine(optConfig.Value.Age);
            Console.WriteLine(optConfig.Value.Name);
        }
    }
    class Config
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public Proxy Proxy { get; set; }
    }

}
