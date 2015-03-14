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
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Web;
using System.Windows;

namespace LAB_MANAGER.VIEW
{
  /*  public partial class RFIDMAN : Form
    {
       /*private void RFIDMAN_Load(object sender, EventArgs e)
        {

        }
    }*/
    public partial class RFIDMAN : Form
    {
        public bool errorCOM = false;      //kiem tra cong COM ngat bat thuong hay khong
        public bool errorCONN = false;     //kiem tra cong COM co bi chiem giu hay khong
        private LAB_MANAGER.Properties.Settings settings = LAB_MANAGER.Properties.Settings.Default;
        public bool ckcadd = false;
        public string mypathapp = null;

        public RFIDMAN(string path)
        {
            InitializeComponent();
            InitializeControlValues();
          //  uri_request.Text = refaddress;
           // ckcadd = ckc;
            mypathapp = path;
        }
       
        //private int errorCOMcount = 0;      //dem khi cong COM bi ngat

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

        private void cmB_COMport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void richtex_sttServer_TextChanged(object sender, EventArgs e)
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
                    lb_stt.Text = "RFID_code";
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

        #endregion

        #region Local Methods
        // initialize values about COM port : portname, baudrate, parity, stopbit, databit
        private void InitializeControlValues()
        {
            uri_request.ReadOnly = true;
            textBox_sttCOM.ReadOnly = true;
            CONTROL.Services services = new CONTROL.Services();
            //Console.WriteLine("process id of "+this.Name+" is : "+Process.GetCurrentProcess().Id);
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
                services.Local.RefreshserialPortLAB_MANAGERList(ref this.cmB_COMport,ref errorCOM, ref this.serialPortRFID);
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


        private void cmB_Baud_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        public char[] temp = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', };
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
            do
            {
                if (this.InvokeRequired)
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
                    string Dataresponse = null;
                    //string mydocpath = @"C:/xampp/htdocs/DTB/";
                    string mydocpath = @"C:\Users\Public\Documents\";
                    string mypath = mydocpath + @"LAB_MANAGER_file.txt";
                    services.Local.writetofile(lb_stt.Text, mypath);

                    //  gui thong tin POST len server tu class WEB

                    bool ErrRes = false;
                    string MessRes = null;
                    //CONTROL.WebServices services = new CONTROL.WebServices();
                    if (string.IsNullOrEmpty(uri_request.Text))
                    {
                        lb_stt.Text = "RFID_code";
                        MessageBox.Show("Vui lòng thiết lập máy chủ!");
                    }
                    else
                    {
                        string url = uri_request.Text + "DTB/check.php";
                        string[] Datarequest = { "RFID", lb_stt.Text };
                        string tmpurl = url.Remove(5, url.Length - 5);

                        if (tmpurl == "https")
                            Dataresponse = services.Network.POSTHTTPS(ref errorW, ref errorWEB, url, Datarequest);
                        else
                            Dataresponse = services.Network.POST(ref errorW, ref errorWEB, url, Datarequest);
                        if (errorW)
                        {
                            lb_stt.Text = "RFID_code";
                            richtex_sttServer.SelectionAlignment = HorizontalAlignment.Center;
                                //richtex_sttServer.Text = "Error connection : " + uri_request.Text;
                            richtex_sttServer.Text = "Máy chủ không tồn tại!";
                            uri_request.Text = "";
                            MessageBox.Show(this, errorWEB, "Server : " + uri_request.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //MessageBox.Show("Vui lòng thiết lập máy chủ!");        
                        }
                        else if (!errorCOM || !errorCONN)
                        {
                            services.Network.showresponse(mypath, Dataresponse, uri_request.Text, ref ErrRes, ref MessRes, ref Dataresponse);
                            if (ErrRes)
                                MessageBox.Show(MessRes);
                            else
                                richtex_sttServer.Text = Dataresponse;
                        }
                    }
                }
            }
            while (!ckcadd);
        }


        private void serialPortLAB_MANAGER_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
                if (serialPortRFID.BytesToRead >= maxlength)
                    SetText("");
                
        }

        private void uri_request_TextChanged(object sender, EventArgs e)
        {

        }

        private void RFIDMAN_Load(object sender, EventArgs e)
        {

        }

        private void button_config_Click(object sender, EventArgs e)
        { 
            VIEW.CONFSERVER frmCONF = new VIEW.CONFSERVER(mypathapp);
            frmCONF.setMANVIEW(this, "MAN");
            frmCONF.Show();
        }

    }
        #endregion Events


}
