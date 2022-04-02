
/*----1.多选框checkBox
 *----2.单选框redioButton
 *（1）没有容器时，一个窗口内的所有单选框只能选择一个
 *----3.容器groupBox
 *（1）给控件分组
 */
namespace WinFormsApp3
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