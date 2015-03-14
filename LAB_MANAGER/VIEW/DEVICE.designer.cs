namespace LAB_MANAGER.VIEW
{
    partial class DEVICE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            this.components = new System.ComponentModel.Container();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.but_OpenPort = new System.Windows.Forms.Button();
            this.group_SETTINGS = new System.Windows.Forms.GroupBox();
            this.cmB_Parity = new System.Windows.Forms.ComboBox();
            this.label_Parity = new System.Windows.Forms.Label();
            this.cmB_Baud = new System.Windows.Forms.ComboBox();
            this.label_Baud = new System.Windows.Forms.Label();
            this.cmB_COMport = new System.Windows.Forms.ComboBox();
            this.label_COMport = new System.Windows.Forms.Label();
            this.group_INFOR = new System.Windows.Forms.GroupBox();
            this.textBox_Att = new System.Windows.Forms.TextBox();
            this.textBox_Type = new System.Windows.Forms.TextBox();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label_att = new System.Windows.Forms.Label();
            this.but_reset = new System.Windows.Forms.Button();
            this.label_Type = new System.Windows.Forms.Label();
            this.label_RFID = new System.Windows.Forms.Label();
            this.label_DeviceName = new System.Windows.Forms.Label();
            this.lb_stt = new System.Windows.Forms.Label();
            this.groupBox_Setting = new System.Windows.Forms.GroupBox();
            this.uri_request = new System.Windows.Forms.TextBox();
            this.button_config = new System.Windows.Forms.Button();
            this.label_server = new System.Windows.Forms.Label();
            this.group_STT = new System.Windows.Forms.GroupBox();
            this.textBox_sttCOM = new System.Windows.Forms.TextBox();
            this.label_sttServer = new System.Windows.Forms.Label();
            this.richtex_sttServer = new System.Windows.Forms.RichTextBox();
            this.label_sttCOM = new System.Windows.Forms.Label();
            this.serialPortRFID = new System.IO.Ports.SerialPort(this.components);
            this.button_edit = new System.Windows.Forms.Button();
            this.but_Regis = new System.Windows.Forms.Button();
            this.group_SETTINGS.SuspendLayout();
            this.group_INFOR.SuspendLayout();
            this.groupBox_Setting.SuspendLayout();
            this.group_STT.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.Location = new System.Drawing.Point(0, 0);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(121, 21);
            this.cmbStopBits.TabIndex = 0;
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.Location = new System.Drawing.Point(0, 0);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(121, 21);
            this.cmbDataBits.TabIndex = 0;
            // 
            // but_OpenPort
            // 
            this.but_OpenPort.Location = new System.Drawing.Point(98, 93);
            this.but_OpenPort.Name = "but_OpenPort";
            this.but_OpenPort.Size = new System.Drawing.Size(71, 28);
            this.but_OpenPort.TabIndex = 25;
            this.but_OpenPort.Text = "Open Port";
            this.but_OpenPort.UseVisualStyleBackColor = true;
            this.but_OpenPort.Click += new System.EventHandler(this.but_OpenPort_Click);
            // 
            // group_SETTINGS
            // 
            this.group_SETTINGS.Controls.Add(this.cmB_Parity);
            this.group_SETTINGS.Controls.Add(this.but_OpenPort);
            this.group_SETTINGS.Controls.Add(this.label_Parity);
            this.group_SETTINGS.Controls.Add(this.cmB_Baud);
            this.group_SETTINGS.Controls.Add(this.label_Baud);
            this.group_SETTINGS.Controls.Add(this.cmB_COMport);
            this.group_SETTINGS.Controls.Add(this.label_COMport);
            this.group_SETTINGS.Location = new System.Drawing.Point(210, 6);
            this.group_SETTINGS.Name = "group_SETTINGS";
            this.group_SETTINGS.Size = new System.Drawing.Size(198, 125);
            this.group_SETTINGS.TabIndex = 27;
            this.group_SETTINGS.TabStop = false;
            this.group_SETTINGS.Text = "THIẾT LẬP CỔNG COM";
            // 
            // cmB_Parity
            // 
            this.cmB_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_Parity.FormattingEnabled = true;
            this.cmB_Parity.Location = new System.Drawing.Point(85, 68);
            this.cmB_Parity.Name = "cmB_Parity";
            this.cmB_Parity.Size = new System.Drawing.Size(92, 21);
            this.cmB_Parity.TabIndex = 3;
            // 
            // label_Parity
            // 
            this.label_Parity.AutoSize = true;
            this.label_Parity.Location = new System.Drawing.Point(22, 72);
            this.label_Parity.Name = "label_Parity";
            this.label_Parity.Size = new System.Drawing.Size(33, 13);
            this.label_Parity.TabIndex = 7;
            this.label_Parity.Text = "Parity";
            // 
            // cmB_Baud
            // 
            this.cmB_Baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_Baud.FormattingEnabled = true;
            this.cmB_Baud.Items.AddRange(new object[] {
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
            this.cmB_Baud.Location = new System.Drawing.Point(85, 44);
            this.cmB_Baud.Name = "cmB_Baud";
            this.cmB_Baud.Size = new System.Drawing.Size(92, 21);
            this.cmB_Baud.TabIndex = 11;
            // 
            // label_Baud
            // 
            this.label_Baud.AutoSize = true;
            this.label_Baud.Location = new System.Drawing.Point(22, 47);
            this.label_Baud.Name = "label_Baud";
            this.label_Baud.Size = new System.Drawing.Size(32, 13);
            this.label_Baud.TabIndex = 5;
            this.label_Baud.Text = "Baud";
            // 
            // cmB_COMport
            // 
            this.cmB_COMport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_COMport.FormattingEnabled = true;
            this.cmB_COMport.Location = new System.Drawing.Point(85, 19);
            this.cmB_COMport.Name = "cmB_COMport";
            this.cmB_COMport.Size = new System.Drawing.Size(92, 21);
            this.cmB_COMport.TabIndex = 4;
            // 
            // label_COMport
            // 
            this.label_COMport.AutoSize = true;
            this.label_COMport.Location = new System.Drawing.Point(22, 21);
            this.label_COMport.Name = "label_COMport";
            this.label_COMport.Size = new System.Drawing.Size(49, 13);
            this.label_COMport.TabIndex = 1;
            this.label_COMport.Text = "COMport";
            // 
            // group_INFOR
            // 
            this.group_INFOR.Controls.Add(this.textBox_Att);
            this.group_INFOR.Controls.Add(this.textBox_Type);
            this.group_INFOR.Controls.Add(this.textBox_Name);
            this.group_INFOR.Controls.Add(this.label_att);
            this.group_INFOR.Controls.Add(this.but_reset);
            this.group_INFOR.Controls.Add(this.label_Type);
            this.group_INFOR.Controls.Add(this.label_RFID);
            this.group_INFOR.Controls.Add(this.label_DeviceName);
            this.group_INFOR.Controls.Add(this.lb_stt);
            this.group_INFOR.Location = new System.Drawing.Point(7, 6);
            this.group_INFOR.Name = "group_INFOR";
            this.group_INFOR.Size = new System.Drawing.Size(195, 146);
            this.group_INFOR.TabIndex = 24;
            this.group_INFOR.TabStop = false;
            this.group_INFOR.Text = "THÔNG TIN THẺ RFID";
            // 
            // textBox_Att
            // 
            this.textBox_Att.Location = new System.Drawing.Point(70, 90);
            this.textBox_Att.Name = "textBox_Att";
            this.textBox_Att.Size = new System.Drawing.Size(106, 20);
            this.textBox_Att.TabIndex = 24;
            // 
            // textBox_Type
            // 
            this.textBox_Type.Location = new System.Drawing.Point(70, 67);
            this.textBox_Type.Name = "textBox_Type";
            this.textBox_Type.Size = new System.Drawing.Size(106, 20);
            this.textBox_Type.TabIndex = 23;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(70, 42);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(106, 20);
            this.textBox_Name.TabIndex = 22;
            // 
            // label_att
            // 
            this.label_att.AutoSize = true;
            this.label_att.Location = new System.Drawing.Point(14, 95);
            this.label_att.Name = "label_att";
            this.label_att.Size = new System.Drawing.Size(46, 13);
            this.label_att.TabIndex = 17;
            this.label_att.Text = "Attribute";
            // 
            // but_reset
            // 
            this.but_reset.Location = new System.Drawing.Point(107, 117);
            this.but_reset.Name = "but_reset";
            this.but_reset.Size = new System.Drawing.Size(54, 22);
            this.but_reset.TabIndex = 16;
            this.but_reset.Text = "Xóa";
            this.but_reset.UseVisualStyleBackColor = true;
            this.but_reset.Click += new System.EventHandler(this.but_reset_Click);
            // 
            // label_Type
            // 
            this.label_Type.AutoSize = true;
            this.label_Type.Location = new System.Drawing.Point(14, 71);
            this.label_Type.Name = "label_Type";
            this.label_Type.Size = new System.Drawing.Size(31, 13);
            this.label_Type.TabIndex = 15;
            this.label_Type.Text = "Type";
            // 
            // label_RFID
            // 
            this.label_RFID.AutoSize = true;
            this.label_RFID.Location = new System.Drawing.Point(15, 20);
            this.label_RFID.Name = "label_RFID";
            this.label_RFID.Size = new System.Drawing.Size(32, 13);
            this.label_RFID.TabIndex = 14;
            this.label_RFID.Text = "RFID";
            // 
            // label_DeviceName
            // 
            this.label_DeviceName.AutoSize = true;
            this.label_DeviceName.Location = new System.Drawing.Point(14, 46);
            this.label_DeviceName.Name = "label_DeviceName";
            this.label_DeviceName.Size = new System.Drawing.Size(35, 13);
            this.label_DeviceName.TabIndex = 12;
            this.label_DeviceName.Text = "Name";
            // 
            // lb_stt
            // 
            this.lb_stt.AutoSize = true;
            this.lb_stt.Location = new System.Drawing.Point(93, 20);
            this.lb_stt.Name = "lb_stt";
            this.lb_stt.Size = new System.Drawing.Size(62, 13);
            this.lb_stt.TabIndex = 11;
            this.lb_stt.Text = "RFID_code";
            // 
            // groupBox_Setting
            // 
            this.groupBox_Setting.Controls.Add(this.uri_request);
            this.groupBox_Setting.Controls.Add(this.button_config);
            this.groupBox_Setting.Controls.Add(this.label_server);
            this.groupBox_Setting.Location = new System.Drawing.Point(7, 156);
            this.groupBox_Setting.Name = "groupBox_Setting";
            this.groupBox_Setting.Size = new System.Drawing.Size(195, 84);
            this.groupBox_Setting.TabIndex = 29;
            this.groupBox_Setting.TabStop = false;
            this.groupBox_Setting.Text = "THIẾT LẬP MÁY CHỦ";
            // 
            // uri_request
            // 
            this.uri_request.Location = new System.Drawing.Point(50, 23);
            this.uri_request.Name = "uri_request";
            this.uri_request.Size = new System.Drawing.Size(136, 20);
            this.uri_request.ReadOnly = true;
            this.uri_request.TabIndex = 26;
            // 
            // button_config
            // 
            this.button_config.Location = new System.Drawing.Point(60, 52);
            this.button_config.Name = "button_config";
            this.button_config.Size = new System.Drawing.Size(106, 22);
            this.button_config.TabIndex = 20;
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
            // group_STT
            // 
            this.group_STT.Controls.Add(this.textBox_sttCOM);
            this.group_STT.Controls.Add(this.label_sttServer);
            this.group_STT.Controls.Add(this.richtex_sttServer);
            this.group_STT.Controls.Add(this.label_sttCOM);
            this.group_STT.Location = new System.Drawing.Point(210, 135);
            this.group_STT.Name = "group_STT";
            this.group_STT.Size = new System.Drawing.Size(197, 141);
            this.group_STT.TabIndex = 30;
            this.group_STT.TabStop = false;
            this.group_STT.Text = "TRẠNG THÁI PHẢN HỒI";
            // 
            // textBox_sttCOM
            // 
            this.textBox_sttCOM.Location = new System.Drawing.Point(66, 18);
            this.textBox_sttCOM.Name = "textBox_sttCOM";
            this.textBox_sttCOM.Size = new System.Drawing.Size(106, 20);
            this.textBox_sttCOM.ReadOnly = true;
            this.textBox_sttCOM.TabIndex = 25;
            // 
            // label_sttServer
            // 
            this.label_sttServer.AutoSize = true;
            this.label_sttServer.Location = new System.Drawing.Point(10, 62);
            this.label_sttServer.Name = "label_sttServer";
            this.label_sttServer.Size = new System.Drawing.Size(38, 13);
            this.label_sttServer.TabIndex = 21;
            this.label_sttServer.Text = "Server";
            // 
            // richtex_sttServer
            // 
            this.richtex_sttServer.Location = new System.Drawing.Point(48, 46);
            this.richtex_sttServer.Name = "richtex_sttServer";
            this.richtex_sttServer.ReadOnly = true;
            this.richtex_sttServer.Size = new System.Drawing.Size(143, 89);
            this.richtex_sttServer.TabIndex = 22;
            this.richtex_sttServer.Text = "";
            // 
            // label_sttCOM
            // 
            this.label_sttCOM.AutoSize = true;
            this.label_sttCOM.Location = new System.Drawing.Point(12, 21);
            this.label_sttCOM.Name = "label_sttCOM";
            this.label_sttCOM.Size = new System.Drawing.Size(31, 13);
            this.label_sttCOM.TabIndex = 21;
            this.label_sttCOM.Text = "COM";
            // 
            // serialPortRFID
            // 
            this.serialPortRFID.PortName = "COM4";
            this.serialPortRFID.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortLAB_MANAGER_DataReceived);
            // 
            // button_edit
            // 
            this.button_edit.Location = new System.Drawing.Point(7, 249);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(85, 22);
            this.button_edit.TabIndex = 24;
            this.button_edit.Text = "SỬA MÃ THẺ";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // but_Regis
            // 
            this.but_Regis.Location = new System.Drawing.Point(109, 249);
            this.but_Regis.Name = "but_Regis";
            this.but_Regis.Size = new System.Drawing.Size(85, 22);
            this.but_Regis.TabIndex = 23;
            this.but_Regis.Text = "ĐĂNG KÍ MỚI";
            this.but_Regis.UseVisualStyleBackColor = true;
            this.but_Regis.Click += new System.EventHandler(this.but_Send_Click);
            // 
            // DEVICE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 279);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.but_Regis);
            this.Controls.Add(this.group_STT);
            this.Controls.Add(this.groupBox_Setting);
            this.Controls.Add(this.group_SETTINGS);
            this.Controls.Add(this.group_INFOR);
            this.Name = "DEVICE";
            this.Text = "ĐĂNG KÍ - SỬA RFID THIẾT BỊ";
            this.group_SETTINGS.ResumeLayout(false);
            this.group_SETTINGS.PerformLayout();
            this.group_INFOR.ResumeLayout(false);
            this.group_INFOR.PerformLayout();
            this.groupBox_Setting.ResumeLayout(false);
            this.groupBox_Setting.PerformLayout();
            this.group_STT.ResumeLayout(false);
            this.group_STT.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.ComboBox cmbDataBits;
        private System.Windows.Forms.Button but_OpenPort;
        private System.Windows.Forms.GroupBox group_SETTINGS;
        private System.Windows.Forms.ComboBox cmB_Parity;
        private System.Windows.Forms.Label label_Parity;
        private System.Windows.Forms.ComboBox cmB_Baud;
        private System.Windows.Forms.Label label_Baud;
        private System.Windows.Forms.ComboBox cmB_COMport;
        private System.Windows.Forms.Label label_COMport;
        private System.Windows.Forms.GroupBox group_INFOR;
        private System.Windows.Forms.Label lb_stt;
        private System.Windows.Forms.Label label_DeviceName;
        private System.Windows.Forms.GroupBox groupBox_Setting;
        private System.Windows.Forms.Label label_server;
        private System.Windows.Forms.Button but_reset;
        private System.Windows.Forms.GroupBox group_STT;
        private System.Windows.Forms.Label label_sttServer;
        private System.Windows.Forms.RichTextBox richtex_sttServer;
        private System.Windows.Forms.Label label_sttCOM;
        private System.IO.Ports.SerialPort serialPortRFID;
        private System.Windows.Forms.Label label_att;
        private System.Windows.Forms.Label label_Type;
        private System.Windows.Forms.Label label_RFID;
        private System.Windows.Forms.Button button_config;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button but_Regis;
        private System.Windows.Forms.TextBox textBox_Att;
        private System.Windows.Forms.TextBox textBox_Type;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.TextBox textBox_sttCOM;
        private System.Windows.Forms.TextBox uri_request;
    }
}