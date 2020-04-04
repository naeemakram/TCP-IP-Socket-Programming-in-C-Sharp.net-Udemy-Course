using LahoreSocketAsync;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketClientGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        LahoreSocketClient client;
        private void Form1_Load(object sender, EventArgs e)
        {
            client = new LahoreSocketClient();
            client.RaiseTextReceivedEvent += HandleTextReceived;
            client.RaiseServerDisconnected += HandleServerDisconnected;
            client.RaiseServerConnected += HandleServerConnected;
        }

        private void HandleTextReceived(object sender, TextReceivedEventArgs trea)
        {
            Console.WriteLine(
                string.Format(
                    "{0} - Received: {1}{2}",
                    DateTime.Now,
                    trea.TextReceived,
                    Environment.NewLine));

            tbConsole.Text += $"{DateTime.Now} - Received text: {trea.TextReceived}{Environment.NewLine}";

        }

        private void HandleServerDisconnected(object sender, ConnectionDisconnectedEventArgs cdea)
        {
            Console.WriteLine(
                string.Format(
                    "{0} - Disconnected from server: {1}{2}",
                    DateTime.Now,
                    cdea.DisconnectedPeer,
                    Environment.NewLine));
            System.Console.ReadLine();
            tbConsole.Text += $"{DateTime.Now} - Disconnected from server: {cdea.DisconnectedPeer}{Environment.NewLine}";
            Environment.Exit(1);
        }

        private void HandleServerConnected(object sender, ConnectionDisconnectedEventArgs cdea)
        {
            Console.WriteLine(
                string.Format(
                    "{0} - Connected to server: {1}{2}",
                    DateTime.Now,
                    cdea.DisconnectedPeer,
                    Environment.NewLine));

            tbConsole.Text += $"{DateTime.Now} - Connected to server: {cdea.DisconnectedPeer}{Environment.NewLine}";

        }

        private void BtnConnect_ClickAsync(object sender, EventArgs e)
        {
            if(!client.SetServerIPAddress(tbServerIP.Text))
            {
                MessageBox.Show($"Server IP is incorrect: {tbServerIP}");
                return;
            }

            if (!client.SetPortNumber(tbServerPort.Text))
            {
                MessageBox.Show($"Server port is incorrect: {tbServerPort}");
                return;
            }

            client.ConnectToServer();
        }

        private async Task ConnectToServerCall()
        {
            
            
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if(client != null)
            {
                if(client.IsConnected)
                {
                    client.SendToServer(tbTextToSend.Text);
                }
            }
        }
    }
}
