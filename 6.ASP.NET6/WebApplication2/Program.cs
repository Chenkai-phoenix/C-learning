/*IIS����
 * step1����װIIS,�������--����---�������߹ر�windows����---internet information serviceȫ����ѡ��
 * step2��https://dotnet.microsoft.com/zh-cn/download/dotnet/6.0 ���ذ�װiis֧��
 * step3������iis
 * step4��VS������Ŀ�����Ƹ�Ŀ¼
 * step5��iis��վ---�����վ---�����ַ�Ƿ���Ŀ¼----�������д
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
