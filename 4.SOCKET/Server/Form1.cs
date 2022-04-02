using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        //（1）服务器端创建监听Socket
        // IP类型：AddressFamily.InterNetwork ipv4；InterNetworkV6 ipv6;
        Socket sockListening = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket clientSocket = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void SocketLs_Click(object sender, EventArgs e)
        {
            //(2)创建IP对象和端口号对象
            IPAddress ip = IPAddress.Any;//IPAddress.Parse(textServer.Text);  (写死了) //string转换成IPAddress
            IPEndPoint point = new IPEndPoint(ip, int.Parse(textPort.Text)); //(IPAddress ip,int port)

            //(3)绑定监听Socket 和ip，port
            sockListening.Bind(point);
            textBox3.AppendText("监听设置完成.\r\n");

            //（4）设置监听队列
            sockListening.Listen(10);    //设置最大监听数10；

            //(5)监听Socket接收客户端连接请求，并传给通信Socket
            Thread thread1 = new Thread(BuildSocketLink);
            thread1.IsBackground = true;
            thread1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sendToClient = textBox4.Text;
            byte[] buffer = new byte[1024];
            buffer = Encoding.Default.GetBytes(sendToClient);
            List<byte> list = new List<byte>();
            list.Add(0);                            //给字节流添加一个辅助标记位               
            list.AddRange(buffer);
            byte[] newBuffer = list.ToArray();     //新字节流第一位多了0表示字符串
            clientSocket.Send(newBuffer);
        }



        //(5)监听Socket接收客户端连接请求，并传给通信Socket(完成与客户端连接)
        public void BuildSocketLink()
        {
            clientSocket = sockListening.Accept();
            textBox3.AppendText(clientSocket.RemoteEndPoint.ToString() + "连接中...\r\n");

            //(6)完成与客户端连接后接收字节数据
            Thread thread2 = new Thread(ReceiveData);    //线程中带参数方法
            thread2.IsBackground = true;
            thread2.Start(clientSocket);

        }

        //(6)完成与客户端连接后接收字节数据
        public void ReceiveData(object linksocket)
        {
            Socket socket = (Socket)linksocket;
            byte[] buffer = new byte[1024 * 1024];
            while (true)
            {
                int r = socket.Receive(buffer);
                if (r == 0)
                {
                    break;
                }
                string str = Encoding.Default.GetString(buffer, 0, r);
                textBox3.AppendText("接收到" + socket.RemoteEndPoint.ToString() + "的数据是:" + str + "\r\n");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "C:";
            ofd.Title = "请选择要发送的文件";
            ofd.Filter = "所有文件|*.*";
            ofd.ShowDialog();
            textBox5.Text = ofd.FileName;       //将文件路径给文本框
            
   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = textBox5.Text;
            using (FileStream fileRead = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[1024 * 1024 * 5];
                int realByte = fileRead.Read(buffer, 0, buffer.Length);
                List<byte> list = new List<byte>();
                list.Add(1);                            //给字节流添加一个辅助标记位               
                list.AddRange(buffer);
                byte[] newBuffer = list.ToArray();     //新字节流第一位多了1表示文件
                clientSocket.Send(newBuffer, 0, realByte+1, SocketFlags.None);
            }   
        }

        private void button5_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[1];
            List<byte> list = new List<byte>();
            list.Add(2);
            list.AddRange(buffer);
            byte[] newBuffer = list.ToArray();
            clientSocket.Send(newBuffer, 0, buffer.Length + 1, SocketFlags.None);
        }
    }
}