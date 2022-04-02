using System.Net;
using System.Net.Sockets;
using System.Text;



namespace SocketClient
{
    class Program
    {
        public static void Main()
        {
            Socket linkSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse("192.168.0.102");
            int port = 50000;
            IPEndPoint point = new IPEndPoint(ip,port);
            try
            {
                linkSocket.Connect(point);
            }
            catch
            {
                Console.WriteLine("服务器断开连接。");
            }
          
            
            if (linkSocket != null)
            {
                Console.WriteLine("已连接服务器。");
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
            Socket severSocket = (Socket)socket;
            while (true)
            {
                byte[] bufferR = new byte[1024 * 1024];
                int realR = severSocket.Receive(bufferR);
                string recInfo = Encoding.Default.GetString(bufferR);
                Console.WriteLine("from{0}: {1}", severSocket.RemoteEndPoint.ToString(), recInfo);
            }
        }
        public void SendData(object socket)
        {
            Socket severSocket = (Socket)socket;
            while (true)
            {
                Console.WriteLine("input info send to server:");
                string sendInfo = Console.ReadLine();
                byte[] bufferR = new byte[1024 * 1024];
                bufferR = Encoding.Default.GetBytes(sendInfo);
                int realS = severSocket.Send(bufferR);
            }
        }


    }
}