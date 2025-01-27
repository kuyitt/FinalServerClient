
using System.Dynamic;
using System.Net;
using System.Net.Sockets;

namespace FinalServerClient
{
    public class Run
    {
        public static void Main()
        {
            string hostName = Dns.GetHostName();
            string IP = Dns.GetHostEntry(hostName).AddressList[0].ToString();
            int port = 16000;
            //int subnet = GetLocalInfo(IP);

            //Console.WriteLine(Needed(IP, port).ToString()); 

            var server = new Server(IP,port);
        }
        //public static int GetLocalInfo(string IP)
        //{
        //    System.Net.IPAddress iPAddress = IPAddress.Parse(IP);
        //    byte[] IPInByte = iPAddress.GetAddressBytes();
        //    uint iPInInt = (uint)IPInByte[0];

        //    if (iPInInt >= 0 && iPInInt < 128) { return 1; }
        //    else if (iPInInt >= 128 && iPInInt < 192) { return 2; }
        //    else if (iPInInt >= 192 && iPInInt < 224) { return 3; }
        //    else return 0;
        //}
        //public static bool Needed(string IP,int port)
        //{
        //    bool needed = true;
        //    for (int i = 0; i < 100; i++) 
        //    {
        //        string IPTemp = ("192.168.0." + 23);
        //        try
        //        {
        //            TcpClient scanner = new TcpClient(IPTemp, port);
        //            needed = false;
        //            Console.WriteLine("hello");
        //        }
        //        catch { Console.WriteLine("fail"); }
        //    }
        //    return needed;
        //}

    }
    public class Server
    {
        public Server(string IP,int port) 
        {
            IPAddress listenerIP = IPAddress.Parse(IP);
            
            int bufferSize = 256;

            TcpListener listener = new TcpListener(listenerIP,port);

            listener.Start();



            Console.WriteLine("skibidi");


        }
        public void Initiate()
        {

        }
    }
}
