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
            string IP = "192.168.0.23";

            using TcpClient client = new TcpClient(IP, port);
        }
    }  
}
