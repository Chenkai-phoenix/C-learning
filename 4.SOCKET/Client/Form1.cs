using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace Client
{
    public partial class Form1 : Form
    {
        //��1����������Socket
        Socket linkSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //��1.1�����÷�����ip�Ͷ˿�
            IPAddress ip = IPAddress.Parse("192.168.0.102");
            int port = 50000;
            //��1.2�����ӷ�����
            try
            {
                linkSocket.Connect(ip, port);
                textBox3.AppendText("����������ӳɹ���\r\n");
                //(2)���շ�����������
                Thread thread1 = new Thread(ReceiveData);
                thread1.IsBackground = false;
                thread1.Start(linkSocket);
            }
            catch
            {
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread2 = new Thread(SendData);
            thread2.IsBackground = false;
            thread2.Start(linkSocket);
        }

        public void ReceiveData(object socket)
        {
            Socket severSocket = socket as Socket;
            try
            {
                byte[] buffer = new byte[1024 * 1024 * 5];
                while (true)
                {
                    int realByte = severSocket.Receive(buffer);
                    if (realByte == 0)
                    {
                        break;
                    }
                    if (buffer[0] == 0)    //�������λ0����ʾ���յ������ַ�
                    {
                        string str = Encoding.Default.GetString(buffer, 1, realByte);
                        textBox3.AppendText("Receive" + severSocket.RemoteEndPoint.ToString() + "data:" + str + "\r\n");
                    }
                    if (buffer[0] == 1)    //�������λ1����ʾ���յ������ļ�
                    {
                        MessageBox.Show("������ļ���");
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.InitialDirectory = "DownLoad";
                        sfd.Title = "��ѡ�񱣴�·��";
                        sfd.Filter = "�����ļ�|*.*";
                        sfd.ShowDialog(this);        //����Ի���ִ�м�this
                  
                        string path = sfd.FileName;
                        using (FileStream fileWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            fileWrite.Write(buffer, 1, realByte - 1);
                        }
                        MessageBox.Show("�ļ�����ɹ���");
                    }
                    if (buffer[0] == 2)    //�������λ2����ʾ��
                    {
                        FormShocked();
                    }

                }
            }
            catch
            {
            }
        }
        public void SendData(object socket)
        {
            Socket severSocket = socket as Socket;
            try
            {
                byte[] buffer = new byte[1024];
                if (textBox4.Text != "")
                {
                    buffer = Encoding.Default.GetBytes(textBox4.Text);
                    severSocket.Send(buffer);
                }
            }
            catch
            {
                textBox4.AppendText("�������Ͽ�����.");
            }
        }
        public void FormShocked()
        {
            for (int i = 0; i < 100; i++)
            {
                this.Location = new Point(200, 200);
                this.Location = new Point(180, 180);
            }
        }
    }
}