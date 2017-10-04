using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LahoreSocketAsync;

namespace UdemyAsyncSocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            LahoreSocketClient client = new LahoreSocketClient();
            client.RaiseTextReceivedEvent += HandleTextReceived;
            client.RaiseServerDisconnected += HandleServerDisconnected;
            client.RaiseServerConnected += HandleServerConnected;

            Console.WriteLine("*** Welcome to Socket Client Starter Example by Naeem Akram Malik ***");
            Console.WriteLine("Please Type a Valid Server IP Address and Press Enter: ");

            string strIPAddress = Console.ReadLine();

            Console.WriteLine("Please Supply a Valid Port Number 0 - 65535 and Press Enter: ");
            string strPortInput = Console.ReadLine();

            if( !client.SetServerIPAddress(strIPAddress) || 
                    !client.SetPortNumber(strPortInput))
            {
                Console.WriteLine(
                    string.Format(
                        "Wrong IP Address or port number supplied - {0} - {1} - Press a key to exit",
                        strIPAddress, 
                    strPortInput));
                Console.ReadKey();
                return;
            }

            client.ConnectToServer();

            string strInputUser = null;

            do
            {
                strInputUser = Console.ReadLine();

                if (strInputUser.Trim() != "<EXIT>")
                {
                    client.SendToServer(strInputUser);
                }
                else if(strInputUser.Equals("<EXIT>"))
                {
                    client.CloseAndDisconnect();
                }
                
            } while (strInputUser != "<EXIT>");



        }

        private static void HandleTextReceived(object sender, TextReceivedEventArgs trea)
        {
            Console.WriteLine(
                string.Format(
                    "{0} - Received: {1}{2}",
                    DateTime.Now,
                    trea.TextReceived,
                    Environment.NewLine));

        }

        private static void HandleServerDisconnected(object sender, ConnectionDisconnectedEventArgs cdea)
        {
            Console.WriteLine(
                string.Format(
                    "{0} - Disconnected from server: {1}{2}",
                    DateTime.Now,
                    cdea.DisconnectedPeer,
                    Environment.NewLine));
            System.Console.ReadLine();
            Environment.Exit(1);
        }

        private static void HandleServerConnected(object sender, ConnectionDisconnectedEventArgs cdea)
        {
            Console.WriteLine(
                string.Format(
                    "{0} - Connected to server: {1}{2}",
                    DateTime.Now,
                    cdea.DisconnectedPeer,
                    Environment.NewLine));
        }
    }
}
