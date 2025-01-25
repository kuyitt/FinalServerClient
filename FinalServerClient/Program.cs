
using System.Net;
using System.Net.Sockets;

namespace FinalServerClient
{
    public class Run
    {
        public static void Main()
        {
            var server = new Server();
        }
    }
    public class Server
    {
        public Server() 
        {
            string hostName = Dns.GetHostName();
            string IP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            Console.WriteLine(hostName + IP);
            IPAddress listenerIP = IPAddress.Parse(IP);
            int port = 16000;
            int bufferSize = 256;

            TcpListener listener = new TcpListener(listenerIP,port);

            listener.Start();

            




        }
        public void Initiate()
        {

        }
        //public bool Needed()
        //{

        //}
        public void GetLocalInfo()
        {
            
        }
    }
}
