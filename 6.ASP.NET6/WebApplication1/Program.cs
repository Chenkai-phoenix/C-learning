/*----MVC
 * 1.Models Views Controllers 模型-视图-控制器
 * Models：保存实体对象，数据传输存储介质
 * Views：ui
 * Controllers：业务逻辑，计算
 * 2.日志组件log4net
 * （1）Nuget引入:log4net;项目添加Nuget程序包
 * （2）安装log4net，安装后依赖项--包--会有
 * （3）添加配置文件：CfgFile文件夹，里面包括：log4net.Config，Nlog.Config
 * （4）Nuget引入:Microsoft.Extensions.Logging.Log4Net.AspNetCore
 * （5）log功能添加log4net:builder.Logging.AddLog4Net("CfgFile/log4net.Config");
 *Nlog写入文本：
 * (1)ILogger<Class> Ilogger；  Ilogger.LogInformation(）；
 *（2）ILoggerFactory LoggerFactory; LoggerFactory.CreateLogger<Class>().LogInformation();
 *Nlog写入数据库：
 * (1)引入程序集system.data.sqlclient
 */

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.注册
builder.Services.AddControllersWithViews();

builder.Services.AddSession();      //注册Session

builder.Logging.AddLog4Net("CfgFile/log4net.Config"); //log功能添加log4net，使用前需要nuget引入


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();        //使用Session

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
