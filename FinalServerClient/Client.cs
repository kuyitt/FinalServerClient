using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FinalServerClient
{
    public class Client
    {
        public Client()
        {

        }
        public void Connect()
        {
            int port = 16000;
            string hostname = "FRANKLIN-LAPTOP";

            using TcpClient client = new TcpClient(hostname, port);

            string msg = "hello";
            byte[] msgInBytes = Encoding.UTF8.GetBytes(msg);

            NetworkStream clientStream = client.GetStream();
            clientStream.Write(msgInBytes, 0, msgInBytes.Length);
        }
    }  
}
