using ConfigServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static  class IniConfigServiceExtensions
    {
        public static void AddIniConfig(this IServiceCollection services,string filepath)
        {
            services.AddScoped(typeof(IConfigServices), s => new IniFileConfigService { FilePath = filepath });
        }
    }
}
