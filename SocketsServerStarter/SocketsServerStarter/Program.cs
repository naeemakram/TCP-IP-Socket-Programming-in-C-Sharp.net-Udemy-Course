using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace SocketsServerStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipaddr = IPAddress.Any;

            IPEndPoint ipep = new IPEndPoint(ipaddr, 23000);

            listenerSocket.Bind(ipep);

            listenerSocket.Listen(5);
            listenerSocket.Accept();


        }
    }
}
