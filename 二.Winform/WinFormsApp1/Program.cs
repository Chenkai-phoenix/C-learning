/**************************��һ��******************************/
/* 1.winformӦ�ó�����һ�����ܵĿͻ��˼�����ͨ��ʹ��winformӦ�ó�����������Ϣ���ߴ�����Ϣ����C/Sģʽ��
 * 2.�޸��������
 * 3.�������¼�
 * 4.Main�����еĴ����Ϊ�����壬��������ر�ʱ���г���������Ӵ���رղ�Ӱ��
 * 5.Button���
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