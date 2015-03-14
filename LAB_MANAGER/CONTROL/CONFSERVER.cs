using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LAB_MANAGER.VIEW
{
    public partial class CONFSERVER : Form
    {
        public string errorWEB;
        public bool errorW = false;
        public bool ckcOK = false;
        public string sttpostHTTPS;
        public string errorHTTPS;
        public string mypathapp = null;

        // bien kiem tra loai app goi den
        public string apptype = null;

        public CONFSERVER(string path)
        {
            InitializeComponent();
            mypathapp = path;
        }

        #region Local Methods
        
        // truyen sang class nay tu class goi toi no
        private USER ParentUSER;
        public void setUSERVIEW(USER parentuser, string reftype)
        {
            this.ParentUSER = parentuser;
            apptype = reftype;
        }

        private DEVICE ParentDEV;
        public void setDEVVIEW(DEVICE parentdev, string reftype)
        {
            this.ParentDEV = parentdev;
            apptype = reftype;
        }

        private CLIENTVIEW ParentVIEW;
        public void setparentadd(CLIENTVIEW parentview, string reftype)
        {
            this.ParentVIEW = parentview;
            apptype = reftype;
        }

        private RFIDMAN ParentMAN;
        public void setMANVIEW(RFIDMAN parentman, string reftype)
        {
            this.ParentMAN = parentman;
            apptype = reftype;
        }

        private void CONFSERVER_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!ckcOK)
                {
                    DialogResult result = MessageBox.Show("Bạn thật sự không muốn thiết lập kết nối?", "Tắt thiết lập", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        e.Cancel = false;
                        //parentVIEW.setaddress("", false);
                        //Environment.Exit(1);
                        //this.Close();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
        
        /*public void showresponse(string Data, string url)
        {
            bool cmpres = false;
            try
            {
                Console.WriteLine("Data[0] is : \"" + Data[0] + "\", Data[1] is : \"" + Data[1] + "\"");
                if (Data[0].Equals('<') || Data[0].Equals('?') || Data[0].Equals('!') || Data[0].Equals(' ') || Data[0].Equals('\r') || Data[0].Equals('\n')
                 || Data[1].Equals('<') || Data[1].Equals('?') || Data[1].Equals('!') || Data[1].Equals(' ') || Data[1].Equals('\r') || Data[1].Equals('\n'))
                    cmpres = true;
                else
                    cmpres = false;
            }
            catch (Exception ex)
            {
                ErrRes = true;
                MessRes = ex.Message;
                //MessageBox.Show(ex.Message);
            }

            if (ErrRes)
            {
                ErrRes = false;
                MessageBox.Show(this, MessRes, "Connection timed out");
            }
            else if (cmpres)
            {
                //string mydocpath = @"C:\Users\Public\Documents\";
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments, Environment.SpecialFolderOption.Create);
                string mypath = mydocpath + @"\Response.html";
                CONTROL.Services services = new CONTROL.Services();
                services.Local.writetofile(Data, mypath);
                //richText_Stt.Text = "Connected successful \n" + url;
                richText_Stt.Text = "Connected successful";
                System.Diagnostics.Process.Start(mypath);
                cmpres = false;
            }
            else
            {
                richText_Stt.Text = "Connected to : " + url + "\n" + Data;
                //Console.WriteLine("Method successful.");
            }
            /*
              IAsyncResult result;
        Action action = () =>
        {
            // Your code here
        };

        result = action.BeginInvoke(null, null);

        if (result.AsyncWaitHandle.WaitOne(10000))
            Console.WriteLine("Method successful.");
        else
            Console.WriteLine("Method timed out.");
        }*/

        #endregion Local Methods

        #region Button_Click
        public char[] tmpchar = {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '};
        //public string tmpstringrespone = null;
        public string Datares = null;
        public bool ErrRes = false;
        public string MessRes = null;
        private void but_check_Click(object sender, EventArgs e)
        {
            //System.Threading.Timer timer = new System.Threading.Timer(timeoutfunc, this, 0, 18000);
            CONTROL.Services services = new CONTROL.Services();
            richText_Stt.Text = "";
            /*if (textBox_port.Text == "")
                richText_Stt.Text = "Error : No information!";
            else
            {*/
            string url = uri_request.Text + textBox_port.Text;
            //Console.WriteLine(tmpurl);
            if (url == "")
            {
                richText_Stt.Text = "Error connection ";
                MessageBox.Show("The URL is missing!");
                errorW = true;
            }
            else
            {
                string tmpurl = url.Remove(5, url.Length - 5);
                if (tmpurl == "https")
                    Datares = services.Network.POSTHTTPS(ref errorW, ref errorWEB, url,
                            "Request", "Requesting");
                else
                    Datares = services.Network.POST(ref errorW, ref errorWEB, url,
                            "Request", "Requesting");
            }
            if (!string.IsNullOrEmpty(uri_request.Text))
            {
                if (errorW)
                {
                    richText_Stt.SelectionAlignment = HorizontalAlignment.Center;
                    richText_Stt.Text = "Error connection : " + url;
                    MessageBox.Show(this, errorWEB, "Server : " + url, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    services.Network.showresponse(mypathapp, Datares, uri_request.Text,ref ErrRes, ref MessRes, ref Datares);
                    if (ErrRes)
                        MessageBox.Show(MessRes);
                    else
                        richText_Stt.Text = Datares;
                }
            }
        }

        /*public void timeoutfunc(object state)
        {
            //throw new TimeoutException();
            MessageBox.Show(this, "Connection timed out", "Error");
        }*/

        private void button_Connect_Click(object sender, EventArgs e)
        {
            if (richText_Stt.Text == "OK" || richText_Stt.Text == "Connected successfully")
            {
                ckcOK = true;
                if (apptype == "USER")
                {
                    ParentUSER.setaddress(uri_request.Text, true);
                    MessageBox.Show(this, "Địa chỉ máy chủ là "+uri_request.Text, "QUẢN LÝ NGƯỜI DÙNG");
                }
                else if (apptype == "DEV")
                {
                    ParentDEV.setaddress(uri_request.Text, true);
                    MessageBox.Show(this, "Địa chỉ máy chủ là " + uri_request.Text, "QUẢN LÝ THIẾT BỊ");
                }
                else if (apptype == "MAN")
                {
                    ParentMAN.setaddress(uri_request.Text, true);
                    MessageBox.Show(this, "Địa chỉ máy chủ là " + uri_request.Text, "MƯỢN/TRẢ THIẾT BỊ");
                }
                else if (apptype == "TEST")
                {
                    MessageBox.Show(this, "Địa chỉ máy chủ là " + uri_request.Text, "KIỂM TRA THÀNH CÔNG");
                    this.Close();
                }
                else 
                {
                    RFIDMAN frmMAN = new RFIDMAN(mypathapp);
                    frmMAN.setaddress(uri_request.Text, true);
                    MessageBox.Show(this, "Địa chỉ máy chủ là " + uri_request.Text, "MƯỢN/TRẢ THIẾT BỊ");
                    frmMAN.Show();
                }

                this.Close();
            }
            else
            {
                DialogResult result = MessageBox.Show(this, "Vui lòng kiểm tra URL của server trước khi kết nối", "Kết nối bị lỗi", MessageBoxButtons.RetryCancel,MessageBoxIcon.Warning);
                if (result == DialogResult.Retry)
                {
                    richText_Stt.Text = "Không thể kết nối \n "+uri_request.Text;
                }
                else
                {
                    richText_Stt.Text = "Chưa thiết lập server";
                    //MessageBox.Show(this, "Chưa thiết lập server", "Chú ý : ");
                    this.Close();
                }
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            richText_Stt.SelectionAlignment = HorizontalAlignment.Center;
            richText_Stt.Text = "OK";
        }

        private void button_RESET_Click(object sender, EventArgs e)
        {
            uri_request.Clear();
            textBox_port.Clear();
            richText_Stt.Clear();
        }

        #endregion Button_Click
        
    }
}
