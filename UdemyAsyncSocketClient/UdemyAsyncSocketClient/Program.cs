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
                if (strInputUser.Trim() != "<EXIT>")
                {
                    client.SendToServer(strInputUser);
                }

                strInputUser = Console.ReadLine();
            } while (strInputUser != "<EXIT>");



        }
    }
}
