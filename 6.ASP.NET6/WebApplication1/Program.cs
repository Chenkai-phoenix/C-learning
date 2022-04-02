/*----MVC
 * 1.Models Views Controllers ģ��-��ͼ-������
 * Models������ʵ��������ݴ���洢����
 * Views��ui
 * Controllers��ҵ���߼�������
 * 2.��־���log4net
 * ��1��Nuget����:log4net;��Ŀ���Nuget�����
 * ��2����װlog4net����װ��������--��--����
 * ��3����������ļ���CfgFile�ļ��У����������log4net.Config��Nlog.Config
 * ��4��Nuget����:Microsoft.Extensions.Logging.Log4Net.AspNetCore
 * ��5��log�������log4net:builder.Logging.AddLog4Net("CfgFile/log4net.Config");
 *Nlogд���ı���
 * (1)ILogger<Class> Ilogger��  Ilogger.LogInformation(����
 *��2��ILoggerFactory LoggerFactory; LoggerFactory.CreateLogger<Class>().LogInformation();
 *Nlogд�����ݿ⣺
 * (1)�������system.data.sqlclient
 */

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.ע��
builder.Services.AddControllersWithViews();

builder.Services.AddSession();      //ע��Session

builder.Logging.AddLog4Net("CfgFile/log4net.Config"); //log�������log4net��ʹ��ǰ��Ҫnuget����


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();        //ʹ��Session

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
