using LogServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*----类的扩展方法
 * 1.改变命名空间，使用要扩展的类对应的命名空间
 * 2.使用静态类，静态方法
 * 3.语法：扩展方法名（this 类名 类变量 ）{}
 * 4.对某个类的方法进行修改形成该类的新方法，但不是对该类方法的重载；
 */
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConsoleLogExtensions
    {
        public static void AddConsoleLog(this IServiceCollection services)
        {
            services.AddScoped<ILogProvider, ConsoleProvider>();
        }
    }
}
