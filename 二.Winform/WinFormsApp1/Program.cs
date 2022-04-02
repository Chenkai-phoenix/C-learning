/**************************第一天******************************/
/* 1.winform应用程序是一种智能的客户端技术，通过使用winform应用程序帮助获得信息或者传输信息；（C/S模式）
 * 2.修改组件属性
 * 3.添加组件事件
 * 4.Main函数中的窗体称为主窗体，当主窗体关闭时所有程序结束，子窗体关闭不影响
 * 5.Button组件
 */

namespace WinFormsApp1
{
     static class Program
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