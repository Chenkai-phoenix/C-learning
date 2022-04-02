/*IIS部署
 * step1：安装IIS,控制面板--程序---启动或者关闭windows功能---internet information service全部勾选；
 * step2：https://dotnet.microsoft.com/zh-cn/download/dotnet/6.0 下载安装iis支持
 * step3：启动iis
 * step4：VS发布项目并复制根目录
 * step5：iis网站---添加网站---物理地址是发布目录----其余随便写
 */

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Logging.AddLog4Net("CfgFile/log4net.Config"); 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
