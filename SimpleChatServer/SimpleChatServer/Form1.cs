using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace SimpleChatServer
{
    public partial class Form1 : Form
    {
        Socket socket;
        EndPoint eplocal, epremote;
        byte[] buffer;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Setup Socket
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            //get user Ip
            textLocalIP.Text = GetLocalIP();
            textRemoteIP.Text= GetLocalIP();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            //binding Socket 
            eplocal = new IPEndPoint(IPAddress.Parse(textLocalIP.Text), Convert.ToInt32(textLocalPort.Text));
            socket.Bind(eplocal);
            //Connect the socket
            epremote = new IPEndPoint(IPAddress.Parse(textRemoteIP.Text), Convert.ToInt32(textRemotePort.Text));
            socket.Connect(epremote);
            //Listing thr specific port
            buffer = new byte[1500];
            socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epremote, new AsyncCallback(MessageCallBack), buffer);
        }
        private void MessageCallBack(IAsyncResult result)
        {
            try
            {
                byte[] reciveData = new byte[1500];
                reciveData = (byte[])result.AsyncState;
                //converting byte [] to string
                ASCIIEncoding encoding = new ASCIIEncoding();
                string recivedmsg = encoding.GetString(reciveData);
                //Adding msg into the list box
                listmsg.Items.Add("FRIEND: " + recivedmsg);
                buffer = new byte[1500];
                socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epremote, new AsyncCallback(MessageCallBack), buffer);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Converting string message into byte
            ASCIIEncoding aencoding = new ASCIIEncoding();
            byte[] sendingmsg = new byte[1500];
            sendingmsg = aencoding.GetBytes(textmsg.Text);
            //Sending the encoded message
            socket.Send(sendingmsg);
            //message add to the list box
            listmsg.Items.Add("Me:"+textmsg.Text);
            textmsg.Text = "";
        }

        private string GetLocalIP()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach(IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "";
        }
    }
}
