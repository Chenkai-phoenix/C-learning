
/*----1.��ѡ��checkBox
 *----2.��ѡ��redioButton
 *��1��û������ʱ��һ�������ڵ����е�ѡ��ֻ��ѡ��һ��
 *----3.����groupBox
 *��1�����ؼ�����
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