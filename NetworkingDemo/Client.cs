using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.IO;

namespace NetworkingDemo
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            GetNetworkInfo();
        }
        public void GetNetworkInfo()
        {
            //***    this block for get local ip address   *****
            //**************************************************
            string hostName = Dns.GetHostName();
           
            // Get the IP from GetHostByName method of dns class.
            string IP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            local_ip_lab.Text= IP;


            //this block for get local ip address
            var request = (HttpWebRequest)WebRequest.Create("http://ifconfig.me");

            request.UserAgent = "curl"; // this will tell the server to return the information as if the request was made by the linux "curl" command

            string publicIPAddress;

            request.Method = "GET";
            using (WebResponse response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    global_ip_lab.Text = reader.ReadToEnd();
                }
            }
       

        }
        public void PingLocalDeviceWithIpAddress(string IPAddress)
        {
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply rep = p.Send(IPAddress);
            if (rep.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                listBox1.Items.Add(rep.Address.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TcpClient thisDevice = new TcpClient();
            NetworkStream OtherDeviceStream;
            string RecivedData ="";
            thisDevice.Connect(port_txtb.Text.Trim(), Int32.Parse(ip_txtb.Text));

           // Thread ctThread = new Thread(GetMessage());

        }

        public string GetMessage()
        {
            while(true)
            {
                
            }
            return "";
            
        }
    }
}
