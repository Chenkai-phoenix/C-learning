using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigServices
{
    public class EnvVarConfigService : IConfigServices
    {
        public string GetValue(string name)
        {
            return Environment.GetEnvironmentVariable(name);    
        }
    }
}
