/*----TextBox�ı������
 * (1)WordWrap:���й���
 *��2��ScrollBar:������Ƭ
 *��3��PasswordChar�����������ַ�����'*'
 *----Lable���
 *(1)�ı�������
 *
 *----Timer���
 *��1��interval����ʱ100msһ��
 *��2���¼���������������ư���
 * (3) �¼���������ʾ��ǰϵͳʱ�� DateTime.Now ����DateTime����
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