/*Mdi�������
 * 1.����һ�������ڣ������Ӵ��ھ����������ڣ�
 * ��1��ѡ��һ����������Ϊ�����ڣ�����----isMidContainer (true)
 *  (2) �����Ӵ��ڶ���    Form2 form2 = new Form2();
 * ��3���Ӵ����ϵ�        form2.MdiParent = this;
 * ��4���Ӵ��������������� �� 
 *  LayoutMdi(MdiLayout.TileHorizontal);     ������
 *  LayoutMdi(MdiLayout.TileVertical);       ������
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