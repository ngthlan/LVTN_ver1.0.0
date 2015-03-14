namespace LAB_MANAGER.VIEW
{
    partial class REGISTEREDITVIEW
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //public string txt_D = "";
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_FisrtName = new System.Windows.Forms.Label();
            this.label_LastName = new System.Windows.Forms.Label();
            this.label_UserName = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.label_RFID = new System.Windows.Forms.Label();
            this.but_reset = new System.Windows.Forms.Button();
            this.but_Regis = new System.Windows.Forms.Button();
            this.groupBox_infor = new System.Windows.Forms.GroupBox();
            this.textBox_RFID = new System.Windows.Forms.TextBox();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.textBox_LastName = new System.Windows.Forms.TextBox();
            this.textBox_FirstName = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.button_getRFID = new System.Windows.Forms.Button();
            this.groupBox_Setting = new System.Windows.Forms.GroupBox();
            this.uri_request = new System.Windows.Forms.TextBox();
            this.button_config = new System.Windows.Forms.Button();
            this.label_server = new System.Windows.Forms.Label();
            this.groupBox_Status = new System.Windows.Forms.GroupBox();
            this.richText_Stt = new System.Windows.Forms.RichTextBox();
            this.button_edit = new System.Windows.Forms.Button();
            this.button_hasspass = new System.Windows.Forms.Button();
            this.groupBox_infor.SuspendLayout();
            this.groupBox_Setting.SuspendLayout();
            this.groupBox_Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_FisrtName
            // 
            this.label_FisrtName.AutoSize = true;
            this.label_FisrtName.Location = new System.Drawing.Point(6, 21);
            this.label_FisrtName.Name = "label_FisrtName";
            this.label_FisrtName.Size = new System.Drawing.Size(57, 13);
            this.label_FisrtName.TabIndex = 2;
            this.label_FisrtName.Text = "First Name";
            // 
            // label_LastName
            // 
            this.label_LastName.AutoSize = true;
            this.label_LastName.Location = new System.Drawing.Point(6, 49);
            this.label_LastName.Name = "label_LastName";
            this.label_LastName.Size = new System.Drawing.Size(58, 13);
            this.label_LastName.TabIndex = 3;
            this.label_LastName.Text = "Last Name";
            // 
            // label_UserName
            // 
            this.label_UserName.AutoSize = true;
            this.label_UserName.Location = new System.Drawing.Point(6, 77);
            this.label_UserName.Name = "label_UserName";
            this.label_UserName.Size = new System.Drawing.Size(57, 13);
            this.label_UserName.TabIndex = 4;
            this.label_UserName.Text = "UserName";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(7, 104);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(53, 13);
            this.label_Password.TabIndex = 5;
            this.label_Password.Text = "Password";
            // 
            // label_RFID
            // 
            this.label_RFID.AutoSize = true;
            this.label_RFID.Location = new System.Drawing.Point(7, 129);
            this.label_RFID.Name = "label_RFID";
            this.label_RFID.Size = new System.Drawing.Size(56, 13);
            this.label_RFID.TabIndex = 6;
            this.label_RFID.Text = "RFIDcode";
            // 
            // but_reset
            // 
            this.but_reset.Location = new System.Drawing.Point(9, 156);
            this.but_reset.Name = "but_reset";
            this.but_reset.Size = new System.Drawing.Size(55, 22);
            this.but_reset.TabIndex = 16;
            this.but_reset.Text = "Xóa";
            this.but_reset.UseVisualStyleBackColor = true;
            this.but_reset.Click += new System.EventHandler(this.but_reset_Click);
            // 
            // but_Regis
            // 
            this.but_Regis.Location = new System.Drawing.Point(107, 199);
            this.but_Regis.Name = "but_Regis";
            this.but_Regis.Size = new System.Drawing.Size(85, 22);
            this.but_Regis.TabIndex = 17;
            this.but_Regis.Text = "ĐĂNG KÍ MỚI";
            this.but_Regis.UseVisualStyleBackColor = true;
            this.but_Regis.Click += new System.EventHandler(this.but_Regis_Click);
            // 
            // groupBox_infor
            // 
            this.groupBox_infor.Controls.Add(this.textBox_RFID);
            this.groupBox_infor.Controls.Add(this.textBox_UserName);
            this.groupBox_infor.Controls.Add(this.textBox_LastName);
            this.groupBox_infor.Controls.Add(this.textBox_FirstName);
            this.groupBox_infor.Controls.Add(this.textBox_password);
            this.groupBox_infor.Controls.Add(this.button_getRFID);
            this.groupBox_infor.Controls.Add(this.label_FisrtName);
            this.groupBox_infor.Controls.Add(this.but_reset);
            this.groupBox_infor.Controls.Add(this.label_LastName);
            this.groupBox_infor.Controls.Add(this.label_UserName);
            this.groupBox_infor.Controls.Add(this.label_Password);
            this.groupBox_infor.Controls.Add(this.label_RFID);
            this.groupBox_infor.Location = new System.Drawing.Point(7, 7);
            this.groupBox_infor.Name = "groupBox_infor";
            this.groupBox_infor.Size = new System.Drawing.Size(185, 186);
            this.groupBox_infor.TabIndex = 18;
            this.groupBox_infor.TabStop = false;
            this.groupBox_infor.Text = "THÔNG TIN NGƯỜI DÙNG";
            this.groupBox_infor.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBox_RFID
            // 
            this.textBox_RFID.Location = new System.Drawing.Point(68, 129);
            this.textBox_RFID.Name = "textBox_RFID";
            this.textBox_RFID.Size = new System.Drawing.Size(106, 20);
            this.textBox_RFID.TabIndex = 24;
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Location = new System.Drawing.Point(68, 74);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(106, 20);
            this.textBox_UserName.TabIndex = 23;
            // 
            // textBox_LastName
            // 
            this.textBox_LastName.Location = new System.Drawing.Point(68, 47);
            this.textBox_LastName.Name = "textBox_LastName";
            this.textBox_LastName.Size = new System.Drawing.Size(106, 20);
            this.textBox_LastName.TabIndex = 22;
            // 
            // textBox_FirstName
            // 
            this.textBox_FirstName.Location = new System.Drawing.Point(68, 18);
            this.textBox_FirstName.Name = "textBox_FirstName";
            this.textBox_FirstName.Size = new System.Drawing.Size(106, 20);
            this.textBox_FirstName.TabIndex = 21;
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(68, 101);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(106, 20);
            this.textBox_password.TabIndex = 20;
            // 
            // button_getRFID
            // 
            this.button_getRFID.Location = new System.Drawing.Point(71, 156);
            this.button_getRFID.Name = "button_getRFID";
            this.button_getRFID.Size = new System.Drawing.Size(103, 22);
            this.button_getRFID.TabIndex = 19;
            this.button_getRFID.Text = "Lấy mã thẻ RFID";
            this.button_getRFID.UseVisualStyleBackColor = true;
            this.button_getRFID.Click += new System.EventHandler(this.button_getRFID_Click);
            // 
            // groupBox_Setting
            // 
            this.groupBox_Setting.Controls.Add(this.button_hasspass);
            this.groupBox_Setting.Controls.Add(this.uri_request);
            this.groupBox_Setting.Controls.Add(this.button_config);
            this.groupBox_Setting.Controls.Add(this.label_server);
            this.groupBox_Setting.Location = new System.Drawing.Point(201, 3);
            this.groupBox_Setting.Name = "groupBox_Setting";
            this.groupBox_Setting.Size = new System.Drawing.Size(199, 86);
            this.groupBox_Setting.TabIndex = 19;
            this.groupBox_Setting.TabStop = false;
            this.groupBox_Setting.Text = "THIẾT LẬP MÁY CHỦ";
            // 
            // uri_request
            // 
            this.uri_request.Location = new System.Drawing.Point(50, 23);
            this.uri_request.Name = "uri_request";
            this.uri_request.Size = new System.Drawing.Size(136, 20);
            this.uri_request.TabIndex = 25;
            // 
            // button_config
            // 
            this.button_config.Location = new System.Drawing.Point(80, 53);
            this.button_config.Name = "button_config";
            this.button_config.Size = new System.Drawing.Size(106, 22);
            this.button_config.TabIndex = 19;
            this.button_config.Text = "Thiết lập địa chỉ";
            this.button_config.UseVisualStyleBackColor = true;
            this.button_config.Click += new System.EventHandler(this.button_config_Click);
            // 
            // label_server
            // 
            this.label_server.AutoSize = true;
            this.label_server.Location = new System.Drawing.Point(6, 26);
            this.label_server.Name = "label_server";
            this.label_server.Size = new System.Drawing.Size(38, 13);
            this.label_server.TabIndex = 18;
            this.label_server.Text = "Server";
            // 
            // groupBox_Status
            // 
            this.groupBox_Status.Controls.Add(this.richText_Stt);
            this.groupBox_Status.Location = new System.Drawing.Point(201, 95);
            this.groupBox_Status.Name = "groupBox_Status";
            this.groupBox_Status.Size = new System.Drawing.Size(198, 126);
            this.groupBox_Status.TabIndex = 20;
            this.groupBox_Status.TabStop = false;
            this.groupBox_Status.Text = "TRẠNG THÁI";
            // 
            // richText_Stt
            // 
            this.richText_Stt.Location = new System.Drawing.Point(22, 16);
            this.richText_Stt.Name = "richText_Stt";
            this.richText_Stt.ReadOnly = true;
            this.richText_Stt.Size = new System.Drawing.Size(164, 101);
            this.richText_Stt.TabIndex = 12;
            this.richText_Stt.Text = "";
            // 
            // button_edit
            // 
            this.button_edit.Location = new System.Drawing.Point(6, 199);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(85, 22);
            this.button_edit.TabIndex = 21;
            this.button_edit.Text = "SỬA MÃ THẺ";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // button_hasspass
            // 
            this.button_hasspass.Location = new System.Drawing.Point(6, 53);
            this.button_hasspass.Name = "button_hasspass";
            this.button_hasspass.Size = new System.Drawing.Size(68, 22);
            this.button_hasspass.TabIndex = 26;
            this.button_hasspass.Text = "HassPass";
            this.button_hasspass.UseVisualStyleBackColor = true;
            this.button_hasspass.Click += new System.EventHandler(this.button_hasspass_Click);
            // 
            // REGISTEREDITVIEW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 228);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.groupBox_Status);
            this.Controls.Add(this.groupBox_Setting);
            this.Controls.Add(this.but_Regis);
            this.Controls.Add(this.groupBox_infor);
            this.Name = "REGISTEREDITVIEW";
            this.Text = "ĐĂNG KÍ - SỬA RFID NGƯỜI DÙNG";
            this.groupBox_infor.ResumeLayout(false);
            this.groupBox_infor.PerformLayout();
            this.groupBox_Setting.ResumeLayout(false);
            this.groupBox_Setting.PerformLayout();
            this.groupBox_Status.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_FisrtName;
        private System.Windows.Forms.Label label_LastName;
        private System.Windows.Forms.Label label_UserName;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Label label_RFID;
        private System.Windows.Forms.Button but_reset;
        private System.Windows.Forms.Button but_Regis;
        private System.Windows.Forms.GroupBox groupBox_infor;
        private System.Windows.Forms.GroupBox groupBox_Setting;
        private System.Windows.Forms.Label label_server;
        private System.Windows.Forms.GroupBox groupBox_Status;
        private System.Windows.Forms.RichTextBox richText_Stt;
        private System.Windows.Forms.Button button_getRFID;
        private System.Windows.Forms.Button button_config;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_RFID;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.TextBox textBox_LastName;
        private System.Windows.Forms.TextBox textBox_FirstName;
        private System.Windows.Forms.TextBox uri_request;
        private System.Windows.Forms.Button button_hasspass;
    }
}