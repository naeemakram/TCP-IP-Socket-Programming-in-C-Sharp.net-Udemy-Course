using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LahoreSocketAsync;
using System.IO;

namespace UdemyAsyncSocketServer
{
    public partial class Form1 : Form
    {
        LahoreSocketServer mServer;

        public Form1()
        {
            InitializeComponent();
            mServer = new LahoreSocketServer();
            mServer.RaiseClientConnectedEvent += HandleClientConnected;
            mServer.RaiseTextReceivedEvent += HandleTextReceived;
            mServer.RaiseClientDisconnectedEvent += HandleClientDisconnected;
        }

        private void btnAcceptIncomingAsync_Click(object sender, EventArgs e)
        {
            mServer.StartListeningForIncomingConnection();
        }

        private void btnSendAll_Click(object sender, EventArgs e)
        {
            mServer.SendToAll(txtMessage.Text.Trim());
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            mServer.StopServer();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            mServer.StopServer();
        }

        void HandleClientConnected(object sender, ClientConnectedEventArgs ccea)
        {
            txtConsole.AppendText(string.Format("{0} - New client connected: {1}{2}", 
                DateTime.Now, ccea.NewClient, Environment.NewLine));
        }

        void HandleTextReceived(object sender, TextReceivedEventArgs trea)
        {
            txtConsole.AppendText(
                string.Format(
                    "{0} - Received from {2}: {1}{3}",
                    DateTime.Now,
                    trea.TextReceived, 
                    trea.ClientWhoSentText,
                    Environment.NewLine));
        }

        void HandleClientDisconnected(object sender, ConnectionDisconnectedEventArgs cdea)
        {
            if (!txtConsole.IsDisposed)
            {
                txtConsole.AppendText(string.Format("{0} - Client Disconnected: {1}\r\n",
                    DateTime.Now, cdea.DisconnectedPeer));
            }
        }
    }
}
