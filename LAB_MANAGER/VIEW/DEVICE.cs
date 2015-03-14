using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Windows;


namespace LAB_MANAGER.VIEW
{
    public partial class DEVICE : Form
    {
        public bool errorCOM = false;      //kiem tra cong COM ngat bat thuong hay khong
        public bool errorCONN = false;     //kiem tra cong COM co bi chiem giu hay khong
        private LAB_MANAGER.Properties.Settings settings = LAB_MANAGER.Properties.Settings.Default;
        public bool ckcadd = false;
        public string mypathapp = null;

        public DEVICE(string path)
        {
            InitializeComponent();
            InitializeControlValues();
            mypathapp = path;
        }

        #region Local Methods
        // initialize values about COM port : portname, baudrate, parity, stopbit, databit
        private void InitializeControlValues()
        {
            cmB_Parity.Items.Clear(); cmB_Parity.Items.AddRange(Enum.GetNames(typeof(Parity)));
            cmbStopBits.Items.Clear(); cmbStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits)));

            //cmB_Parity.Text = settings.Parity.ToString();
            cmbStopBits.Text = settings.StopBits.ToString();
            cmbDataBits.Text = settings.DataBits.ToString();
            //cmB_Parity.Text = settings.Parity.ToString();
            //cmB_Baud.Text = settings.BaudRate.ToString();

            // refresh the COM port in the form if it's available 
            try
            {
                RefreshserialPortLAB_MANAGERList();
            }
            catch (UnauthorizedAccessException)
            {
                errorCONN = true;
            }
            // If it is still avalible, select the last com port used
            if (cmB_COMport.Items.Contains(settings.PortName))
            {
                cmB_COMport.Text = settings.PortName;
                errorCOM = false;
            }
            else if (cmB_COMport.Items.Count > 0) cmB_COMport.SelectedIndex = cmB_COMport.Items.Count - 1;
            else if (!errorCOM)
            {
                MessageBox.Show(this, "There are no COM Ports detected on this computer.\nPlease install a COM Port and restart this app.", "No COM Ports Installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorCOM = true;
                cmB_Baud.Items.Clear();
                cmB_Parity.Items.Clear();
                cmB_COMport.Items.AddRange(new Object[] { });
                cmB_Baud.Items.AddRange(new Object[] { });
                cmB_Parity.Items.AddRange(new Object[] { });
                //textBox_sttCOM.SelectionAlignment = HorizontalAlignment.Center;
                textBox_sttCOM.Text = "No COMport!";
                //this.Close();

            }
        }

        // define the function refresh COM port list
        private void RefreshserialPortLAB_MANAGERList()
        {
            // Determain if the list of com port names has changed since last checked
            string selected = RefreshserialPortLAB_MANAGERList(cmB_COMport.Items.Cast<string>(), cmB_COMport.SelectedItem as string, serialPortRFID.IsOpen);

            // If there was an update, then update the control showing the user the list of port names
            if (!String.IsNullOrEmpty(selected))
            {
                cmB_COMport.Items.Clear();
                cmB_COMport.Items.AddRange(OrderedPortNames());
                cmB_COMport.SelectedItem = selected;
            }
        }

        private string[] OrderedPortNames()
        {
            // Just a placeholder for a successful parsing of a string to an integer
            int num;

            // Order the serial port names in numberic order (if possible)
            return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
        }

        private string[] ports;
        private string RefreshserialPortLAB_MANAGERList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
        {
            // Create a new return report to populate
            string selected = null;

            // Retrieve the list of ports currently mounted by the operating system (sorted by name)
            ports = SerialPort.GetPortNames();

            if (ports.Length != 0)
            {
                errorCOM = false;
                // First determain if there was a change (any additions or removals)
                bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

                // If there was a change, then select an appropriate default port
                if (updated)
                {
                    // Use the correctly ordered set of port names
                    ports = OrderedPortNames();

                    // Find newest port if one or more were added
                    string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

                    // If the port was already open... (see logic notes and reasoning in Notes.txt)
                    if (PortOpen)
                    {
                        if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                        else if (!String.IsNullOrEmpty(newest)) selected = newest;
                        else selected = ports.LastOrDefault();
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(newest)) selected = newest;
                        else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                        else selected = ports.LastOrDefault();
                    }
                }
            }

            // If there was a change to the port list, return the recommended default selection
            return selected;
        }

        private void cmB_Baud_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /*public string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }

        public string ByteArrayToString(byte[] data)
        {
            string des = null;
            foreach (char tmp in temp)
            {
                if (tmp != ' ')
                    des += tmp.ToString();
            }
            return des;
        }

        public void writetofile(string data, string path)
        {
            StreamWriter sw;
            //sw = File.CreateText("c:\\testtext.txt");
            //sw.WriteLine("this is just a test");

            if (!File.Exists(path))
            {
                sw = File.CreateText(path);
                sw.Close();
            }
            TextWriter tw = new StreamWriter(path);
            tw.WriteLine(lb_stt.Text);
            tw.Close();
        }*/
        public Label RFIDcode
        {
            get
            {
                return lb_stt;
            }
        }
        // xu li su kien lay dia chi server
        public void setaddress(string refadd, bool ckc)
        {
            uri_request.Text = refadd;
            ckcadd = ckc;
        }

        #endregion Local Methods

        #region Events

        public const int maxlength = 7;
        private string txt_S;
        public string txt_D = "";
        //private string temp = "";
        public char[] temp = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        //private int num_temp;
        public string errorWEB;
        public bool errorW = false;
        public string res2, sttdes;


        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

            CONTROL.Services services = new CONTROL.Services();
            if (this.lb_stt.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                byte[] buffer = new byte[serialPortRFID.BytesToRead];
                serialPortRFID.Read(buffer, 0, buffer.Length);
                txt_S = services.Local.ByteArrayToHexString(buffer);
                txt_S.CopyTo(3, temp, 0, 10 + 4);
                //Console.WriteLine("temp is : "+temp);
                txt_D = services.Local.CharArrayToString(temp);
                Console.WriteLine("RFID is : " + txt_D);
                lb_stt.Text = txt_D;
                if (txt_S.Length > maxlength)
                {
                    txt_S = "";
                    txt_D = "";
                    buffer = new byte[14];
                }

                //string mydocpath = @"C:/xampp/htdocs/DTB/";
                string mydocpath = @"C:\Users\Public\Documents\";
                string mypath = mydocpath + @"LAB_MANAGER_file.txt";
                services.Local.writetofile(lb_stt.Text, mypath);

                //  gui thong tin POST len server tu class WEB
                /*string url = uri_request.Text;
                string Data = LAB_MANAGER.services.Network.POST(ref errorW, ref errorWEB, url, "UserName", lb_stt.Text, "pass", "123");
                if (errorW)
                {
                    textBox2.SelectionAlignment = HorizontalAlignment.Center;
                    textBox2.Text = "Error connection : " + url;
                    MessageBox.Show(this, errorWEB, "Server : " + url, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!errorCOM || !errorCONN)
                {
                    //    textBox2.Text = Data;
                    textBox2.Text = "Connected to : " + url + "\n" + Data;
                    //MessageBox.Show(this, Data,url.Remove(0, 7)+": \t Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }*/
            }
        }


        private void serialPortLAB_MANAGER_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPortRFID.BytesToRead >= maxlength)
                SetText("");
        }


        #endregion Events

        #region Button Click

        private void label_Num_Click(object sender, EventArgs e)
        {
            //CopyToTest();
            //    ToStringSample();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void stt_trip1_TextChanged(object sender, EventArgs e)
        {

        }

        /*private void button2_Click(object sender, EventArgs e)
        {
            string url = uri_request.Text;
            string Data = LAB_MANAGER.services.Network.POST(ref errorW, ref errorWEB, url, "UserName", LAB_MANAGER_demo.Text);
            if (errorW)
            {
                textBox2.SelectionAlignment = HorizontalAlignment.Center;
                if (url == "")
                {
                    textBox2.Text = "Error connection ";
                    MessageBox.Show("The URL is missing!");
                }
                else
                {
                    textBox2.Text = "Error connection : " + url;
                    MessageBox.Show(this, errorWEB, "Server : " + url, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (!errorCOM || !errorCONN)
            {
                //    textBox2.Text = Data;
                textBox2.Text = "Connected to : " + url + "\n" + Data;
                //MessageBox.Show(this, Data, url + ": \t Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }*/

        private void cmB_COMport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void but_OpenPort_Click(object sender, EventArgs e)
        {
            // Change the state of the form's controls
            // If the port is open, send focus to the send data box
            bool error = false;

            if (errorCOM)
            {
                InitializeControlValues();
                if (errorCOM)
                {
                    //textBox_sttCOM.SelectionAlignment = HorizontalAlignment.Center;
                    textBox_sttCOM.Text = "No COMport!";
                    cmB_COMport.Items.Clear();
                    cmB_Baud.Items.Clear();
                    cmB_Parity.Items.Clear();
                    cmB_COMport.Items.AddRange(new Object[] { });
                    cmB_Baud.Items.AddRange(new Object[] { });
                    cmB_Parity.Items.AddRange(new Object[] { });
                    MessageBox.Show(this, "Please insert device", "ERROR DEVICE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Console.WriteLine("no COM!");
                }
                else
                {
                    cmB_Baud.Items.AddRange(new object[] {
                        "300",
                        "600",
                        "1200",
                        "2400",
                        "4800",
                        "9600",
                        "14400",
                        "28800",
                        "36000",
                        "115000"});
                    /*cmB_Parity.Items.AddRange(new object[] {
                        "NONE",
                        "EVEN",
                        "ODD"});*/
                    textBox_sttCOM.Text = "";
                }
            }
            else if (errorCONN)
            {
                errorCONN = false;
                MessageBox.Show(this, "Could not open the COM port.\n Please turn off another device", "ERROR CONNECTION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if ((cmB_Parity.Text == "") || (cmB_Baud.Text == ""))
            {
                error = true;
                InitializeControlValues();
                if (!errorCOM)
                    MessageBox.Show(this, "None parameter! \nPlease select available options!", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else
                {
                    //textBox_sttCOM.SelectionAlignment = HorizontalAlignment.Center;
                    textBox_sttCOM.Text = "No COMport!";
                    cmB_COMport.Items.Clear(); cmB_COMport.Items.AddRange(new Object[] { });
                    cmB_Baud.Items.Clear(); cmB_Baud.Items.AddRange(new Object[] { });
                    cmB_Parity.Items.Clear(); cmB_Parity.Items.AddRange(new Object[] { });
                    MessageBox.Show(this, "Please insert device", "ERROR DEVICE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Console.WriteLine("no COM!");
                }
            }
            else
            {
                // If the port is open, close it.
                if (serialPortRFID.IsOpen)
                {
                    try
                    {
                        serialPortRFID.Close();
                        but_OpenPort.BackColor = System.Drawing.Color.AliceBlue;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        errorCONN = true;
                        MessageBox.Show(this, "Could not open the COM port.\n Please turn off another device", "ERROR CONNECTION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    lb_stt.Text = "LAB_MANAGER_code";
                    but_OpenPort.Text = "Open port";
                    //textBox_sttCOM.SelectionAlignment = HorizontalAlignment.Center;
                    textBox_sttCOM.Text = "COMPort is Closed!";

                    //Console.WriteLine("COMport is closed ...");
                }
                else
                {
                    try
                    {
                        // Set the port's settings
                        serialPortRFID.BaudRate = int.Parse(cmB_Baud.Text);
                        serialPortRFID.DataBits = int.Parse(cmbDataBits.Text);
                        serialPortRFID.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text);
                        serialPortRFID.Parity = (Parity)Enum.Parse(typeof(Parity), cmB_Parity.Text);
                        serialPortRFID.PortName = cmB_COMport.Text;

                        // Open the port
                        serialPortRFID.Open();
                    }

                    catch (UnauthorizedAccessException) { error = true; errorCONN = true; }
                    catch (IOException) { error = true; errorCOM = true; }
                    catch (ArgumentException) { error = true; }

                    if (errorCOM)
                    {
                        but_OpenPort.Text = "Open port";
                        //textBox_sttCOM.SelectionAlignment = HorizontalAlignment.Center;
                        textBox_sttCOM.Text = "No COMport!";

                        cmB_COMport.Items.Clear();
                        cmB_Baud.Items.Clear();
                        cmB_Parity.Items.Clear();
                        cmB_COMport.Items.AddRange(new Object[] { });
                        cmB_Baud.Items.AddRange(new Object[] { });
                        cmB_Parity.Items.AddRange(new Object[] { });
                        MessageBox.Show(this, "Please insert device", "ERROR DEVICE", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        serialPortRFID.Close();
                    }
                    else if (errorCONN)
                    {
                        errorCONN = false;
                        MessageBox.Show(this, "Could not open the COM port.\n Please turn off another device", "ERROR CONNECTION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (error)
                    {
                        but_OpenPort.Text = "Open port";
                        //textBox_sttCOM.SelectionAlignment = HorizontalAlignment.Center;
                        textBox_sttCOM.Text = "COMPort is Closed!";
                        MessageBox.Show(this, "Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        serialPortRFID.Close();
                    }
                    /*else
                {
                    // Show the initial pin states
                    UpdatePinState();
                    chkDTR.Checked = serialPortLAB_MANAGER.DtrEnable;
                    chkRTS.Checked = serialPortLAB_MANAGER.RtsEnable;
                }*/
                    else
                    {
                        txt_S = "";
                        but_OpenPort.Text = "Close port";
                        //textBox_sttCOM.SelectionAlignment = HorizontalAlignment.Center;
                        textBox_sttCOM.Text = "COMPort is Opened!";
                        //Console.WriteLine("COMport is opened ...");
                        but_OpenPort.BackColor = System.Drawing.Color.AntiqueWhite;
                    }
                }
            }
        }

        private void uri_request_TextChanged(object sender, EventArgs e)
        {

        }

        private void RFIDApp_Load(object sender, EventArgs e)
        {

        }

        private void button_REGISTERDEV_Click(object sender, EventArgs e)
        {
            CONTROL.Services services = new CONTROL.Services();
            if (textBox_Name.Text == ""
             || textBox_Type.Text == ""
             || textBox_Att.Text == ""
             || lb_stt.Text == "")
                richtex_sttServer.Text = "Error : No information!";
            else
            {
                string url = uri_request.Text;
                string Data = services.Network.POST(ref errorW, ref errorWEB, url,
                            "Name", textBox_Name.Text,
                            "Type", textBox_Type.Text,
                            "Attribute", textBox_Att.Text,
                            "RFID", lb_stt.Text
                            );
                if (errorW)
                {
                    richtex_sttServer.SelectionAlignment = HorizontalAlignment.Center;
                    if (url == "")
                    {
                        richtex_sttServer.Text = "Error connection ";
                        MessageBox.Show("The URL is missing!");
                    }
                    else
                    {
                        richtex_sttServer.Text = "Error connection : " + url;
                        MessageBox.Show(this, errorWEB, "Server : " + url, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    richtex_sttServer.Text = "Connected to : " + url + "\n" + Data;
                    //MessageBox.Show(this, Data, url + ": \t Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void but_reset_Click(object sender, EventArgs e)
        {
            textBox_Att.Text = "";
            textBox_Name.Text = "";
            textBox_Type.Text = "";
            lb_stt.Text = "RFID_code";
        }

        public bool ErrRes = false;
        public string MessRes = null;
        private void but_Send_Click(object sender, EventArgs e)
        {
            string Dataresponse = null;

            CONTROL.Services services = new CONTROL.Services();
            richtex_sttServer.Clear();
            if (!ckcadd)
            {
                //richtex_sttServer.Text = "Máy chủ không tồn tại!";
                MessageBox.Show(this, "Máy chủ không tồn tại!\nVui lòng thiết lập máy chủ!", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (lb_stt.Text == "RFID_code")
                    MessageBox.Show(this, "Vui lòng quét thẻ RFID trước khi gửi", "Thiếu thông tin 'RFID'");
                else if (!string.IsNullOrEmpty(textBox_Name.Text)
                 && !string.IsNullOrEmpty(textBox_Type.Text)
                 && !string.IsNullOrEmpty(textBox_Att.Text))
                {
                    richtex_sttServer.Text = "";
                    string url = uri_request.Text;
                    string tmpurl = url.Remove(5, url.Length - 5);

                    string[] Datarequest = {"Name",textBox_Name.Text,
                                            "Type",textBox_Type.Text,
                                            "Att",textBox_Att.Text,
                                            "RFID",lb_stt.Text};
                    if (tmpurl == "https")
                        Dataresponse = services.Network.POST(ref errorW, ref errorWEB, url, Datarequest);
                    else
                        Dataresponse = services.Network.POST(ref errorW, ref errorWEB, url, Datarequest);

                    if (errorW) // neu chua co url thi bao loi
                    {
                        richtex_sttServer.SelectionAlignment = HorizontalAlignment.Center;
                        richtex_sttServer.Text = "Error connection : " + url;
                        MessageBox.Show(this, errorWEB, "Server : " + url, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //richtex_sttServer.Text = "Connected to : " + url + "\n" + Dataresponse;
                        services.Network.showresponse(mypathapp, Dataresponse, uri_request.Text, ref ErrRes, ref MessRes, ref Dataresponse);
                        if (ErrRes)
                            MessageBox.Show(MessRes);
                        else
                            richtex_sttServer.Text = Dataresponse;
                    }
                }
                else
                {
                    if (textBox_Name.Text == "")
                        richtex_sttServer.Text += "\nThiếu thông tin 'Name'";
                    if (textBox_Type.Text == "")
                        richtex_sttServer.Text += "\nThiếu thông tin 'Type'";
                    if (textBox_Att.Text == "")
                        richtex_sttServer.Text += "\nThiếu thông tin 'Att'";
                    /*if (lb_stt.Text == "")
                        richtex_sttServer.Text += "\nThiếu thông tin 'RFID'";*/
                }
            }
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            string Dataresponse = null;

            CONTROL.Services services = new CONTROL.Services();
            richtex_sttServer.Clear();
            if (!ckcadd)
            {
                //richtex_sttServer.Text = "Máy chủ không tồn tại!";
                MessageBox.Show(this, "Máy chủ không tồn tại!\nVui lòng thiết lập máy chủ!", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (lb_stt.Text == "RFID_code")
                    MessageBox.Show(this, "Vui lòng quét thẻ RFID trước khi gửi", "Thiếu thông tin 'RFID'");
                else if (!string.IsNullOrEmpty(textBox_Name.Text))
                {
                    richtex_sttServer.Text = "";
                    string url = uri_request.Text;
                    string tmpurl = url.Remove(5, url.Length - 5);

                    string[] Datarequest = {"Name",textBox_Name.Text,
                                                "Type",textBox_Type.Text,
                                                "Att",textBox_Att.Text,
                                                "RFID", lb_stt.Text};
                    if (tmpurl == "https")
                        Dataresponse = services.Network.POST(ref errorW, ref errorWEB, url, Datarequest);
                    else
                        Dataresponse = services.Network.POST(ref errorW, ref errorWEB, url, Datarequest);

                    if (errorW) // neu chua co url thi bao loi
                    {
                        richtex_sttServer.SelectionAlignment = HorizontalAlignment.Center;
                        richtex_sttServer.Text = "Error connection : " + url;
                        MessageBox.Show(this, errorWEB, "Server : " + url, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //richtex_sttServer.Text = "Connected to : " + url + "\n" + Dataresponse;
                        services.Network.showresponse(mypathapp, Dataresponse, uri_request.Text, ref ErrRes, ref MessRes, ref Dataresponse);
                        if (ErrRes)
                            MessageBox.Show(MessRes);
                        else
                            richtex_sttServer.Text = Dataresponse;
                    }
                }
                else
                {
                    if (textBox_Name.Text == "")
                        richtex_sttServer.Text += "\nThiếu thông tin 'Name'";
                    /*if (lb_stt.Text == "")
                        richtex_sttServer.Text += "\nThiếu thông tin 'RFID'";*/
                }
            }
        }

        private void button_config_Click(object sender, EventArgs e)
        {
            VIEW.CONFSERVER frmCONF = new VIEW.CONFSERVER(mypathapp);
            frmCONF.setDEVVIEW(this, "DEV");
            frmCONF.Show();
        }

        #endregion
        
    }
}
