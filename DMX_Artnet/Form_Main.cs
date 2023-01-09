using Haukcode.ArtNet;
using Haukcode.ArtNet.IO;
using Haukcode.ArtNet.Packets;
using Haukcode.ArtNet.Sockets;
using Haukcode.Sockets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMX_Artnet
{
    public partial class Form_Main : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Form_Main()
        {
            InitializeComponent();
        }

        protected ArtNetSocket socket;
        private IPAddress lastIPReceived;

        private void Form_Main_Load(object sender, EventArgs e)
        {
            Settings.Init();
            Settings.Updated += Settings_Updated;

            // Chargement des ports série
            string[] ports = SerialPort.GetPortNames();
            List_Serial.Items.Clear();
            string currentSerialPort = Settings.Get(Settings.SettingsList.dmxPort);
            foreach (string port in ports)
            {
                List_Serial.Items.Add(port);
            }
            List_Serial.SelectedItem = currentSerialPort;

            // Création du socket ArtNet
            socket = new ArtNetSocket()
            {
                EnableBroadcast = true
            };
            socket.NewPacket += Socket_NewPacket;
            socket.NewRdmPacket += Socket_NewRdmPacket;
            socket.UnhandledException += Socket_UnhandledException;
        }

        private void Settings_Updated(Settings.SettingsUpdatedEventArgs e)
        {
            // Called if settings edited by another form
            //throw new NotImplementedException();
        }

        private void Form_Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            string pattern = @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)";
            Regex rg = new Regex(pattern);
            if (!rg.IsMatch(Text_IPAddress.Text))
            {
                Text_IPAddress.BorderStyle = BorderStyle.FixedSingle;
                Text_IPAddress.BackColor = Color.Red;
            }
            else
                Text_IPAddress.BackColor = Color.White;

            var addresses = Helper.GetAddressesFromInterfaceType();
            foreach((IPAddress, IPAddress) address in addresses)
            {
                AddLog(address.Item1 + "-" + address.Item2);
            }

            try
            {
                socket.Open(IPAddress.Parse(Text_IPAddress.Text), IPAddress.Parse("255.255.255.0"));
                AddLog("Socket opened !");
                AddLog("Connected: " + socket.Connected);
                AddLog("LocalIP: " + socket.LocalIP);
                AddLog("LocalSubnetMask: " + socket.LocalSubnetMask);
                AddLog("PortOpen: " + socket.PortOpen);
                Btn_Stop.Enabled = true;
                Btn_Start.Enabled = false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                AddLog(ex.Message);
            }
        }

        private void Btn_Stop_Click(object sender, EventArgs e)
        {
            Btn_Stop.Enabled = false;
            socket.Close();
            AddLog("Socket closed");
            Btn_Start.Enabled = true;
        }

        private void Socket_NewPacket(object sender, NewPacketEventArgs<Haukcode.ArtNet.Packets.ArtNetPacket> e)
        {
            if (e.Packet.OpCode == ArtNetOpCodes.Poll)
            {
                FlashLabel(Label_PollReceived);
                if (Checkbox_PollPacketLogs.Checked)
                    LogPacket(e.Packet);

                try
                {
                    ArtPollReplyPacket packet = new ArtPollReplyPacket();
                    if (lastIPReceived != null)
                    {
                        byte[] firstMacAddress = NetworkInterface
                            .GetAllNetworkInterfaces()
                            .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                            .Select(nic => nic.GetPhysicalAddress().GetAddressBytes())
                            .FirstOrDefault();
                        packet.IpAddress = IPAddress.Parse(Text_IPAddress.Text).GetAddressBytes();
                        packet.Status = PollReplyStatus.None;
                        //packet.Status2 = 0b11100001;
                        packet.PortCount = 4;
                        packet.PortTypes = new byte[] { 0, 0, 0, 0 };
                        packet.BindIpAddress = IPAddress.Parse(Text_IPAddress.Text).GetAddressBytes();
                        packet.BindIndex = 1;
                        packet.MacAddress = firstMacAddress;
                        packet.Status2 = 0x0c;
                        Thread t = new Thread(() =>
                        {
                            socket.Send(packet);
                            AddLog("=> Poll Reply sent !");
                        });
                        t.Start();
                    }
                    else
                        AddLog("ERROR: Packet is null");
                }
                catch(InvalidCastException ex)
                {
                    AddLog("ERROR: " + ex.Message);
                }
            }
            if (e.Packet.OpCode == ArtNetOpCodes.PollReply)
            {
                FlashLabel(Label_PollReceived);
                if (Checkbox_PollPacketLogs.Checked)
                {
                    LogPacket(e.Packet);
                    ArtPollReplyPacket packet = (ArtPollReplyPacket)e.Packet;
                    IPAddress address = new IPAddress(packet.IpAddress);
                    AddLog("    IpAddress: " + address.ToString());
                    AddLog("    Status: " + packet.Status);
                    AddLog("    Status2: " + packet.Status2);
                    lastIPReceived = address;
                }
            }
            if (e.Packet.OpCode == ArtNetOpCodes.Dmx)
            {
                FlashLabel(Label_DMXReceived);
                if (Checkbox_DMXPacketLogs.Checked)
                    LogPacket(e.Packet);
            }
        }

        private void LogPacket(ArtNetPacket packet)
        {
            AddLog("<= New packet received: " + packet.ToString());
            AddLog("    OpCode: " + packet.OpCode);
            AddLog("    DataLength: " + packet.DataLength);
        }

        private void Socket_NewRdmPacket(object sender, NewPacketEventArgs<Haukcode.Rdm.RdmPacket> e)
        {
            AddLog("<= New RDM packet received: " + e.Packet.ToString());
        }

        private void Socket_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            AddLog("Unhandled exception: " + e.ExceptionObject.ToString());
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            socket.Close();
            socket.Dispose();
            AddLog("Socket closed");
            this.Close();
        }

        public void AddLog(string message)
        {
            if (RichText_Logs.InvokeRequired)
                RichText_Logs.BeginInvoke(new Action(() => {
                    RichText_Logs.AppendText(DateTime.Now.ToString() + " " + message + "\r\n");
                    RichText_Logs.ScrollToCaret();
                }));
            else
            {
                RichText_Logs.AppendText(DateTime.Now.ToString() + " " + message + "\r\n");
                RichText_Logs.ScrollToCaret();
            }
        }
        }

        public void FlashLabel(Label label)
        {
            Thread t = new Thread(new ThreadStart(() =>
            {
                Color defaultColor = Color.RoyalBlue;
                if (label.InvokeRequired)
                    label.BeginInvoke(new Action(() => label.BackColor = Color.Green));
                else
                    label.BackColor = Color.Green;
                Thread.Sleep(200);
                if (label.InvokeRequired)
                    label.BeginInvoke(new Action(() => label.BackColor = defaultColor));
                else
                    label.BackColor = defaultColor;
            }));
            t.Start();
        }
    }
}
