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
    public partial class USER : Form
    {
        public bool ckcadd = false;
        public bool ckchash = false;
        public bool errorCOM = false;      //kiem tra cong COM ngat bat thuong hay khong
        public bool errorCONN = false;     //kiem tra cong COM co bi chiem giu hay khong
        private LAB_MANAGER.Properties.Settings settings = LAB_MANAGER.Properties.Settings.Default;
        public string mypathapp = null;

        public USER(string path)
        {
            InitializeComponent();
            InitializeControlValues();
            textBox_password.PasswordChar = '*';
            mypathapp = path;
        }

        // xu li su kien truyen ma the RFID tu form con
        public void setrfid(string tmp)
        {
            lb_stt.Text = tmp;
        }

        // xu li su kien lay dia chi server
        public void setaddress(string refadd, bool ckc)
        {
            uri_request.Text = refadd;
            ckcadd = ckc;
        }

        #region Local Methods
        // initialize values about COM port : portname, baudrate, parity, stopbit, databit
        private void InitializeControlValues()
        {
            CONTROL.Services services = new CONTROL.Services();
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
                services.Local.RefreshserialPortLAB_MANAGERList(ref this.cmB_COMport, ref errorCOM, ref this.serialPortRFID);
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
                //rictext_sttCOM.SelectionAlignment = HorizontalAlignment.Center;
                //rictext_sttCOM.Text = "No COMport!";
                //this.Close();

            }
        }

        
        private void cmB_Baud_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        /*private EditView parentEDIT;
        public void setEditview(EditView parentedit)
        {
            this.parentEDIT = parentedit;
        }*/

        /*private VIEW.REGISTEREDITVIEW parentREGIS;
        public void setrUSERview(VIEW.REGISTEREDITVIEW parentregis)
        {
            this.parentREGIS = parentregis;
        }*/
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
            CONTROL.Services services = new CONTROL.Services();
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.

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
                string mydocpath = @"C:\USERs\Public\Documents\";
                string mypath = mydocpath + @"LAB_MANAGER_file.txt";
                services.Local.writetofile(lb_stt.Text, mypath);
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

        private void ricText2_TextChanged(object sender, EventArgs e)
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

        private void uri_request_TextChanged(object sender, EventArgs e)
        {

        }

        private void RFIDApp_Load(object sender, EventArgs e)
        {

        }

        private void button_Send_Click(object sender, EventArgs e)
        {
            
        }

        private void but_reset_Click(object sender, EventArgs e)
        {
            textBox_FirstName.Text = "";
            textBox_LastName.Text = "";
            textBox_UserName.Text = "";
            textBox_password.Text = "";
            lb_stt.Text = "RFID_code";
            textBox_sttCOM.Text = "";
            richtex_sttServer.Text = "";
        }

        private void button_hasspass_Click(object sender, EventArgs e)
        {
            CONTROL.Services services = new CONTROL.Services();
            if (string.IsNullOrEmpty(textBox_password.Text))
                MessageBox.Show(this, "Chưa điền \"password\"", "Lỗi hash");
            else
            {
                string resulthash = services.Network.hashpass(textBox_password.Text, ref ckchash);
                richtex_sttServer.Text = "Chuối MD5 hash của " + textBox_password.Text + " là: " + resulthash + "." + "\n" + ckchash;
            }
        }

        private void button_config_Click(object sender, EventArgs e)
        {
            VIEW.CONFSERVER frmCONF = new VIEW.CONFSERVER(mypathapp);
            frmCONF.setUSERVIEW(this, "USER");
            frmCONF.Show();
        }

        public bool ErrRes = false;
        public string MessRes = null;
        //xu li su kien DANG KI NGUOI DUNG
        private void but_Regis_Click(object sender, EventArgs e)
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
                else if (!string.IsNullOrEmpty(textBox_FirstName.Text)
                 && !string.IsNullOrEmpty(textBox_LastName.Text)
                 && !string.IsNullOrEmpty(textBox_UserName.Text)
                 && !string.IsNullOrEmpty(textBox_password.Text))
                {
                    richtex_sttServer.Text = "";
                    string url = uri_request.Text;
                    string tmpurl = url.Remove(5, url.Length - 5);

                    string HASSpass = services.Network.hashpass(textBox_password.Text, ref ckchash);
                    if (ckchash) // neu hash thanh cong thi gui len web
                    {
                        string[] Datarequest =   {"FisrtName",textBox_FirstName.Text,
                                        "LastName",textBox_LastName.Text,
                                        "UserName",textBox_UserName.Text,
                                        "Password",HASSpass,
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
                        MessageBox.Show(this, "Hash is crashed!", "Error of security", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (textBox_FirstName.Text == "")
                        richtex_sttServer.Text += "\nThiếu thông tin 'First Name'";
                    if (textBox_LastName.Text == "")
                        richtex_sttServer.Text += "\nThiếu thông tin 'Last Name'";
                    if (textBox_UserName.Text == "")
                        richtex_sttServer.Text += "\nThiếu thông tin 'UserName'";
                    if (textBox_password.Text == "")
                        richtex_sttServer.Text += "\nThiếu thông tin 'Password'";
                    /*if (lb_stt.Text == "")
                        richtex_sttServer.Text += "\nThiếu thông tin 'RFID'";*/
                }
            }
        }

        //xu li su kien SUA RFID NGUOI DUNG
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
                else if (!string.IsNullOrEmpty(textBox_UserName.Text))
                {
                    richtex_sttServer.Text = "";
                    string url = uri_request.Text;
                    string tmpurl = url.Remove(5, url.Length - 5);

                    string HASSpass = services.Network.hashpass(textBox_password.Text, ref ckchash);
                    if (ckchash) // neu hash thanh cong thi gui len web
                    {
                        string[] Datarequest =   {"FisrtName",textBox_FirstName.Text,
                                        "LastName",textBox_LastName.Text,
                                        "UserName",textBox_UserName.Text,
                                        "Password",HASSpass,
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
                        MessageBox.Show(this, "Hash is crashed!", "Error of security", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (textBox_UserName.Text == "")
                        richtex_sttServer.Text += "\nThiếu thông tin 'UserName'";
                    /*if (lb_stt.Text == "")
                        richtex_sttServer.Text += "\nThiếu thông tin 'RFID'";*/
                }
            }
        }
        #endregion Button Click
    }
}
