using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace Client
{
    public partial class Form1 : Form
    {
        //（1）创建连接Socket
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
            //（1.1）设置服务器ip和端口
            IPAddress ip = IPAddress.Parse("192.168.0.102");
            int port = 50000;
            //（1.2）连接服务器
            try
            {
                linkSocket.Connect(ip, port);
                textBox3.AppendText("与服务器连接成功。\r\n");
                //(2)接收服务器的数据
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
                    if (buffer[0] == 0)    //辅助标记位0：表示接收到的是字符
                    {
                        string str = Encoding.Default.GetString(buffer, 1, realByte);
                        textBox3.AppendText("Receive" + severSocket.RemoteEndPoint.ToString() + "data:" + str + "\r\n");
                    }
                    if (buffer[0] == 1)    //辅助标记位1：表示接收到的是文件
                    {
                        MessageBox.Show("请接收文件！");
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.InitialDirectory = "DownLoad";
                        sfd.Title = "请选择保存路径";
                        sfd.Filter = "所有文件|*.*";
                        sfd.ShowDialog(this);        //保存对话框不执行加this
                  
                        string path = sfd.FileName;
                        using (FileStream fileWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            fileWrite.Write(buffer, 1, realByte - 1);
                        }
                        MessageBox.Show("文件保存成功！");
                    }
                    if (buffer[0] == 2)    //辅助标记位2：表示震动
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
                textBox4.AppendText("服务器断开连接.");
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