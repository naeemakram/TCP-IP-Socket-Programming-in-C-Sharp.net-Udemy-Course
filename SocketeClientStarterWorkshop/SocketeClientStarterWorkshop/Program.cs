using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace SocketeClientStarterWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipaddrserver = null;
            

            try
            {
                Console.WriteLine("*** Welcome to Socket Client Starter Example by Naeem Akram Malik ***");
                Console.WriteLine("Please Type a Valid Server IP Address and Press Enter: ");
                string strServerIPInput = Console.ReadLine();

                Console.WriteLine("Please Type a Valid Server Port Number(Integer Only, max 65535) and Press Enter: ");
                string strPortInput =  Console.ReadLine();
                int nPortInput = 23000;

                if(!IPAddress.TryParse(strServerIPInput.Trim(), out ipaddrserver))
                {
                    Console.WriteLine("Invalid server IP supplied.");
                    return;
                }

                if(!int.TryParse(strPortInput.Trim(), out nPortInput))
                {
                    Console.WriteLine("Invalid port number supplied, return.");
                }
                if (nPortInput <= 0 || nPortInput > 65535)
                {
                    Console.WriteLine("Port number must be between 0 and 65535.");
                    return;
                }
                System.Console.WriteLine(string.Format("IPAddress: {0} - Port: {1}", ipaddrserver.ToString(), nPortInput));

                client.Connect(ipaddrserver, nPortInput);
                Console.WriteLine("Connected to server.");



                Console.ReadKey();
            }
            catch(Exception excp)
            {
                Console.WriteLine(excp.ToString());
            }
        }
    }
}
