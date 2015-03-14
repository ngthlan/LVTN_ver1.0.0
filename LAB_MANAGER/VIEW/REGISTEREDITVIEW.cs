using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LAB_MANAGER.VIEW
{
    public partial class REGISTEREDITVIEW : Form
    {
        public string errorWEB;
        public bool errorW = false;
        public bool ckcadd = false;
        public bool ckchash = false;

        #region Local Methods
        public REGISTEREDITVIEW()
        {
            InitializeComponent();
            textBox_password.PasswordChar = '*';
        }

        // xu li su kien truyen ma the RFID tu form con
        public void setrfid(string tmp)
        {
            textBox_RFID.Text = tmp;
        }

        // xu li su kien lay dia chi server
        public void setaddress(string refadd, bool ckc)
        {
            uri_request.Text = refadd;
            ckcadd = ckc;
        }

        #endregion Local Methods

        #region Button_Click
        //xu li su kien DANG KI NGUOI DUNG
        private void but_Regis_Click(object sender, EventArgs e)
        {
            CONTROL.Services services = new CONTROL.Services();
            richText_Stt.Clear();
            if (!ckcadd)
            {
                //richText_Stt.Text = "Máy chủ không tồn tại!";
                MessageBox.Show(this, "Máy chủ không tồn tại!\nVui lòng thiết lập máy chủ!", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!string.IsNullOrEmpty(textBox_FirstName.Text)
                 && !string.IsNullOrEmpty(textBox_LastName.Text)
                 && !string.IsNullOrEmpty(textBox_UserName.Text)
                 && !string.IsNullOrEmpty(textBox_password.Text)
                 && !string.IsNullOrEmpty(textBox_RFID.Text))
                {
                    richText_Stt.Text = "";
                    string url = uri_request.Text;
                    string HASSpass = services.Network.hashpass(textBox_password.Text, ref ckchash);
                    if (ckchash) // neu hash thanh cong thi gui len web
                    {
                        string Data = services.Network.POST(ref errorW, ref errorWEB, url,
                                "FisrtName", textBox_FirstName.Text,
                                "LastName", textBox_LastName.Text,
                                "UserName", textBox_UserName.Text,
                                "Password", HASSpass,
                                "RFID", label_RFID.Text
                                );
                        if (errorW) // neu chua co url thi bao loi
                        {
                            richText_Stt.SelectionAlignment = HorizontalAlignment.Center;
                            if (url == "")
                            {
                                richText_Stt.Text = "Error connection ";
                                MessageBox.Show("The URL is missing!");
                            }
                            else
                            {
                                richText_Stt.Text = "Error connection : " + url;
                                MessageBox.Show(this, errorWEB, "Server : " + url, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            richText_Stt.Text = "Connected to : " + url + "\n" + Data;
                            //MessageBox.Show(this, Data, url + ": \t Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        richText_Stt.Text += "\nThiếu thông tin 'First Name'";
                    if (textBox_LastName.Text == "")
                        richText_Stt.Text += "\nThiếu thông tin 'Last Name'";
                    if (textBox_UserName.Text == "")
                        richText_Stt.Text += "\nThiếu thông tin 'UserName'";
                    if (textBox_password.Text == "")
                        richText_Stt.Text += "\nThiếu thông tin 'Password'";
                    if (textBox_RFID.Text == "")
                        richText_Stt.Text += "\nThiếu thông tin 'RFID'";
                }
            }
        }

        //xu li su kien SUA RFID NGUOI DUNG
        private void button_edit_Click(object sender, EventArgs e)
        {
            CONTROL.Services services = new CONTROL.Services();
            richText_Stt.Clear();
            if (!ckcadd)
            {
                //richText_Stt.Text = "Máy chủ không tồn tại!";
                MessageBox.Show(this, "Máy chủ không tồn tại!\nVui lòng thiết lập máy chủ!", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (!string.IsNullOrEmpty(textBox_UserName.Text)
                 && !string.IsNullOrEmpty(textBox_RFID.Text))
                {
                    richText_Stt.Text = "";
                    string url = uri_request.Text;
                    string Data = services.Network.POST(ref errorW, ref errorWEB, url,
                                "FisrtName", textBox_FirstName.Text,
                                "LastName", textBox_LastName.Text,
                                "UserName", textBox_UserName.Text,
                                "Password", textBox_password.Text,
                                "RFID", label_RFID.Text
                                );
                    if (errorW)
                    {
                        richText_Stt.SelectionAlignment = HorizontalAlignment.Center;
                        if (url == "")
                        {
                            richText_Stt.Text = "Error connection ";
                            MessageBox.Show("The URL is missing!");
                        }
                        else
                        {
                            richText_Stt.Text = "Error connection : " + url;
                            MessageBox.Show(this, errorWEB, "Server : " + url, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        richText_Stt.Text = "Connected to : " + url + "\n" + Data;
                        //MessageBox.Show(this, Data, url + ": \t Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (textBox_UserName.Text == "")
                        richText_Stt.Text += "\nThiếu thông tin '"+label_UserName.Text+"'";
                    if (textBox_RFID.Text == "")
                        richText_Stt.Text += "\nThiếu thông tin '"+label_RFID.Text+"'";
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        // xu li su kien xoa thong tin trong cac field
        private void but_reset_Click(object sender, EventArgs e)
        {
            textBox_FirstName.Text = "";
            textBox_LastName.Text = "";
            textBox_UserName.Text = "";
            textBox_password.Text = "";
            textBox_RFID.Text = "";
            richText_Stt.Text = "";
        }

        //xu li su kien chay form doc ma ther RFID
        private void button_getRFID_Click(object sender, EventArgs e)
        {
            CONTROL.RFIDUser frmRFIDUser = new CONTROL.RFIDUser();
            frmRFIDUser.setruserview(this);
            frmRFIDUser.Show();
        }

        // xu li su kien chay form THIET LAP MAY CHU 
        private void button_config_Click(object sender, EventArgs e)
        {
            VIEW.CONFSERVER frmCONF = new VIEW.CONFSERVER();
            //frmCONF.setUSERVIEW(this,"USER");
            frmCONF.Show();
        }

        private void button_hasspass_Click(object sender, EventArgs e)
        {
            CONTROL.Services services = new CONTROL.Services();
            if (string.IsNullOrEmpty(textBox_password.Text))
                MessageBox.Show(this,"Chưa điền \"password\"","Lỗi hash");
            else
            {
                string resulthash = services.Network.hashpass(textBox_password.Text, ref ckchash);
                richText_Stt.Text = "Chuối MD5 hash của " + textBox_password.Text + " là: " + resulthash + "." + "\n" + ckchash;
            }
        }

        #endregion Button_Click
       
    }
}
