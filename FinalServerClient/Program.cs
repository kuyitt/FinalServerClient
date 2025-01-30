
using System.ComponentModel;
using System.Dynamic;
using System.Net;
using System.Net.Sockets;
using System.Text;

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

            Console.WriteLine(hostName + " " + IP);

            Server server = new Server();
            server._startServer(IP,port);

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

        private List<TcpClient> _clients = new List<TcpClient>();

        private Queue<String> _msgQueue = new Queue<String>();
        public Server() { }

        public void _startServer(string IP, int port)
        {
            IPAddress listenerIP = IPAddress.Parse(IP);
            TcpListener listener = new TcpListener(listenerIP, port);
            listener.Start();

            while (true)
            {
                if (listener.Pending()) { _newConnection(listener); }
                _newMessage();
                _sendMessages();

                Thread.Sleep(1000);                   
            }

            //using TcpClient client = listener.AcceptTcpClient();
            //NetworkStream clientStream = client.GetStream();

            //int bufferSize = 256;
            //byte[] buffer = new byte[bufferSize];
            //int dataLength;

            //while ((dataLength = clientStream.Read(buffer, 0, bufferSize)) != 0)
            //{ 
            //    string msg = Encoding.UTF8.GetString(buffer);
            //}

        }

        private void _newConnection(TcpListener listener)
        {
            TcpClient newClient = listener.AcceptTcpClient();
            _clients.Add(newClient);

            Console.WriteLine("client added");
        }
        private void _newMessage()
        {
            foreach (TcpClient messenger in _clients) 
            {
                int msgLength = messenger.Available;

                if (msgLength > 0) 
                {
                    byte[] msgBytes = new byte[msgLength];
                    string msg = string.Empty;

                    messenger.GetStream().Read(msgBytes, 0, msgBytes.Length);
                    msg = Encoding.UTF8.GetString(msgBytes);

                    _msgQueue.Enqueue(msg);
                }
            }
        }
        private void _checkForDisconnect()
        {
            foreach (TcpClient client in _clients)
            {
                if (_isDisconnected(client))
                {
                    _clients.Remove(client);
                }
            }
        }
        private void _clearClient(TcpClient client)
        {
            client.GetStream().Close();
            client.Close();
        }
        private static bool _isDisconnected(TcpClient client)
        {
            try
            {
                Socket s = client.Client;
                return s.Poll(10 * 1000, SelectMode.SelectRead) && (s.Available == 0);
            }
            catch (SocketException se)
            {
                // We got a socket error, assume it's disconnected
                return true;
            }
        }
        private void _sendMessages()
        {
            foreach (string message in _msgQueue)
            {
                Console.WriteLine(message);
            }
            _msgQueue.Clear();
        }
    }
}
