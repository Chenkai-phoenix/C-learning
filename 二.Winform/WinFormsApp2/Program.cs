/*----TextBox文本框组件
 * (1)WordWrap:换行功能
 *（2）ScrollBar:滚动条片
 *（3）PasswordChar：设置密码字符例如'*'
 *----Lable组件
 *(1)文本输出组件
 *
 *----Timer组件
 *（1）interval：计时100ms一次
 *（2）事件案例：星星跑马灯案例
 * (3) 事件案例：显示当前系统时间 DateTime.Now 返回DateTime对象
 */

namespace WinFormsApp2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}