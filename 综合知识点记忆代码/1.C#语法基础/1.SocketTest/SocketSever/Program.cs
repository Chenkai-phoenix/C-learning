using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
namespace SocketSever
{
    class Program
    {
        public static void Main()
        {

            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Any;
            int port = 50000;
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            listenSocket.Bind(endPoint);
            Console.WriteLine("监听配置已完成。");

            listenSocket.Listen(10);
            Console.WriteLine("同时监听个数：10");


            Console.WriteLine("连接通道空闲，正在监听访问。");
            Socket linkSocket = listenSocket.Accept();

            if (linkSocket != null)
            {
                Console.WriteLine("有访问者，连接建立成功");
                Program program = new Program();
                Thread threadR = new Thread(program.ReceiveData);
                threadR.Start(linkSocket);
                Thread threadS = new Thread(program.SendData);
                threadS.Start(linkSocket);
            }

            Console.ReadKey();


        }

        public void ReceiveData(object socket)
        {
            Socket clientSocket = (Socket)socket;
            while (true)
            {
                byte[] bufferR = new byte[1024 * 1024];
                int realR = clientSocket.Receive(bufferR);
                string recInfo = Encoding.Default.GetString(bufferR);
                Console.WriteLine("from{0}: {1}", clientSocket.RemoteEndPoint.ToString(), recInfo);
            }
        }
        public void SendData(object socket)
        {
            Socket clientSocket = (Socket)socket;
            while (true)
            {
                Console.WriteLine("input info send to client:");
                string sendInfo = Console.ReadLine();
                byte[] bufferR = new byte[1024 * 1024];
                bufferR = Encoding.Default.GetBytes(sendInfo);
                int realS = clientSocket.Send(bufferR);
            }
        }

    }
}