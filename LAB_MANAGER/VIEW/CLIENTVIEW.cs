using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LAB_MANAGER
{
    public partial class CLIENTVIEW : Form
    {
        
        public CLIENTVIEW()
        {
            InitializeComponent();
            InitializeControlValues();
        }

        public string address = null;
        public bool ckcadd = false;
        public static string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments, Environment.SpecialFolderOption.Create);
        string mypathapp = mydocpath + @"\Response.html";


        #region Local Methods
        private void InitializeControlValues()
        {
            //Console.WriteLine("Domain id of " + this.Name + " is : " + Thread.GetDomainID());        
            /*richTextBox1.Font = new System.Drawing.Font("Arial", 18);
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
//            richTextBox1.
            richTextBox1.BackColor = Color.SandyBrown;
            richTextBox1.ForeColor = Color.SlateGray;

            richTextBox1.ReadOnly = true;
            richTextBox1.Text = "LABORATORY MANAGING SYSTEM \nF.CSE HCMUT";   */
        }

        /*public void setaddress(string refaddress, bool ckc)
        {
            address = refaddress;
            ckcadd = ckc;
            //MessageBox.Show(this, address, "Server Address : ");
        }*/

           // xu li su kien tat ung dung
        private void CLIENTVIEW_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Bạn thật sự muốn tắt ứng dụng?", "Tắt chương trình", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = false;
                    Process[] myproc = Process.GetProcessesByName("firefox");
                    foreach (Process tmppro in myproc)
                    {
                        tmppro.Kill();
                    }
                     //myproc.has;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
                //MessageBox.Show("\n End Thread");
            
        }
        #endregion Local Methods

        #region Button_Click

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CLIENTVIEW_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        // xu li su kien nhan nut chay form QUAN LI NGUOI DUNG 
        private void button_USER_Click(object sender, EventArgs e)
        {
            VIEW.USER frmRegisEdit = new VIEW.USER(mypathapp);
            frmRegisEdit.Show();
        }

        // xu li su kien nhan nut chay form QUAN LI THIET BI
        private void button_DEVICE_Click(object sender, EventArgs e)
        {
            VIEW.DEVICE frmDEV = new VIEW.DEVICE(mypathapp);
            frmDEV.Show();
        }

        // xu li su kien nhan nut chay form QUAN LI MUON/TRA THIET BI
        private void button_BORROW_RETURN_Click(object sender, EventArgs e)
        {
               /*VIEW.RFIDMAN frMAN = new VIEW.RFIDMAN();
                frMAN.Show();*/
            VIEW.CONFSERVER frmCONF = new VIEW.CONFSERVER(mypathapp);
            frmCONF.setparentadd(this, "VIEW");
            frmCONF.Show();
        }

        private void button_Test_Click(object sender, EventArgs e)
        {
            VIEW.CONFSERVER frmCONF = new VIEW.CONFSERVER(mypathapp);
            frmCONF.setparentadd(this, "TEST");
            frmCONF.Show();
        }

        private void but_Try_Click(object sender, EventArgs e)
        {
            /*CONTROL.Services services = new CONTROL.Services();
            services.Local.demoprocess();*/
            MessageBox.Show(this, "Chức năng đang được xây dựng", "Đang cập nhật ...");
        }

        private void button_Detail_Click(object sender, EventArgs e)
        {
            VIEW.DETAIL frmDetail = new VIEW.DETAIL();
            frmDetail.Show();
        }

        // xu li su kien nhan nut chay form THIET LAP MAY CHU 
        /*private void button_CONFSER_Click(object sender, EventArgs e)
        {
            VIEW.CONFSERVER frmCONF = new VIEW.CONFSERVER();
            frmCONF.setCLIENTVIEW(this);
            frmCONF.Show();
            //MessageBox.Show(this, "Chức năng đang được xây dựng!", "Đang cập nhật ...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }*/

        #endregion Button_Click
    }
}
