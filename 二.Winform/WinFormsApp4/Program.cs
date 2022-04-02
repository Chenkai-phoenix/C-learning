/*Mdi窗口设计
 * 1.设置一个主窗口，其余子窗口均在主窗口内；
 * （1）选择一个窗口设置为主窗口，属性----isMidContainer (true)
 *  (2) 创建子窗口对象    Form2 form2 = new Form2();
 * （3）子窗口认爹        form2.MdiParent = this;
 * （4）子窗口在主窗口排列 ： 
 *  LayoutMdi(MdiLayout.TileHorizontal);     行排列
 *  LayoutMdi(MdiLayout.TileVertical);       纵排列
 */
namespace WinFormsApp4
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