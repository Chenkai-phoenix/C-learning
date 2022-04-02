using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        //��1���������˴�������Socket
        // IP���ͣ�AddressFamily.InterNetwork ipv4��InterNetworkV6 ipv6;
        Socket sockListening = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Socket clientSocket = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void SocketLs_Click(object sender, EventArgs e)
        {
            //(2)����IP����Ͷ˿ںŶ���
            IPAddress ip = IPAddress.Any;//IPAddress.Parse(textServer.Text);  (д����) //stringת����IPAddress
            IPEndPoint point = new IPEndPoint(ip, int.Parse(textPort.Text)); //(IPAddress ip,int port)

            //(3)�󶨼���Socket ��ip��port
            sockListening.Bind(point);
            textBox3.AppendText("�����������.\r\n");

            //��4�����ü�������
            sockListening.Listen(10);    //������������10��

            //(5)����Socket���տͻ����������󣬲�����ͨ��Socket
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
            list.Add(0);                            //���ֽ������һ���������λ               
            list.AddRange(buffer);
            byte[] newBuffer = list.ToArray();     //���ֽ�����һλ����0��ʾ�ַ���
            clientSocket.Send(newBuffer);
        }



        //(5)����Socket���տͻ����������󣬲�����ͨ��Socket(�����ͻ�������)
        public void BuildSocketLink()
        {
            clientSocket = sockListening.Accept();
            textBox3.AppendText(clientSocket.RemoteEndPoint.ToString() + "������...\r\n");

            //(6)�����ͻ������Ӻ�����ֽ�����
            Thread thread2 = new Thread(ReceiveData);    //�߳��д���������
            thread2.IsBackground = true;
            thread2.Start(clientSocket);

        }

        //(6)�����ͻ������Ӻ�����ֽ�����
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
                textBox3.AppendText("���յ�" + socket.RemoteEndPoint.ToString() + "��������:" + str + "\r\n");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "C:";
            ofd.Title = "��ѡ��Ҫ���͵��ļ�";
            ofd.Filter = "�����ļ�|*.*";
            ofd.ShowDialog();
            textBox5.Text = ofd.FileName;       //���ļ�·�����ı���
            
   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = textBox5.Text;
            using (FileStream fileRead = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[1024 * 1024 * 5];
                int realByte = fileRead.Read(buffer, 0, buffer.Length);
                List<byte> list = new List<byte>();
                list.Add(1);                            //���ֽ������һ���������λ               
                list.AddRange(buffer);
                byte[] newBuffer = list.ToArray();     //���ֽ�����һλ����1��ʾ�ļ�
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