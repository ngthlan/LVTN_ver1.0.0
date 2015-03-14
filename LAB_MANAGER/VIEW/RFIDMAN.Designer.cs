namespace LAB_MANAGER.VIEW
{
    partial class RFIDMAN
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /*protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }*/

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.group_INFOR = new System.Windows.Forms.GroupBox();
            this.lb_stt = new System.Windows.Forms.Label();
            this.but_OpenPort = new System.Windows.Forms.Button();
            this.group_SETTINGS = new System.Windows.Forms.GroupBox();
            this.cmB_Parity = new System.Windows.Forms.ComboBox();
            this.label_Parity = new System.Windows.Forms.Label();
            this.cmB_Baud = new System.Windows.Forms.ComboBox();
            this.label_Baud = new System.Windows.Forms.Label();
            this.cmB_COMport = new System.Windows.Forms.ComboBox();
            this.label_COMport = new System.Windows.Forms.Label();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.serialPortRFID = new System.IO.Ports.SerialPort(this.components);
            this.timer1_DL = new System.Windows.Forms.Timer(this.components);
            this.group_STT = new System.Windows.Forms.GroupBox();
            this.textBox_sttCOM = new System.Windows.Forms.TextBox();
            this.label_sttServer = new System.Windows.Forms.Label();
            this.richtex_sttServer = new System.Windows.Forms.RichTextBox();
            this.label_sttCOM = new System.Windows.Forms.Label();
            this.groupBox_Setting = new System.Windows.Forms.GroupBox();
            this.uri_request = new System.Windows.Forms.TextBox();
            this.button_config = new System.Windows.Forms.Button();
            this.label_server = new System.Windows.Forms.Label();
            this.group_INFOR.SuspendLayout();
            this.group_SETTINGS.SuspendLayout();
            this.group_STT.SuspendLayout();
            this.groupBox_Setting.SuspendLayout();
            this.SuspendLayout();
            // 
            // group_INFOR
            // 
            this.group_INFOR.Controls.Add(this.lb_stt);
            this.group_INFOR.Location = new System.Drawing.Point(13, 11);
            this.group_INFOR.Name = "group_INFOR";
            this.group_INFOR.Size = new System.Drawing.Size(186, 50);
            this.group_INFOR.TabIndex = 2;
            this.group_INFOR.TabStop = false;
            this.group_INFOR.Text = "THÔNG TIN THẺ RFID";
            this.group_INFOR.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lb_stt
            // 
            this.lb_stt.AutoSize = true;
            this.lb_stt.Location = new System.Drawing.Point(56, 24);
            this.lb_stt.Name = "lb_stt";
            this.lb_stt.Size = new System.Drawing.Size(62, 13);
            this.lb_stt.TabIndex = 11;
            this.lb_stt.Text = "RFID_code";
            this.lb_stt.Click += new System.EventHandler(this.label2_Click);
            // 
            // but_OpenPort
            // 
            this.but_OpenPort.Location = new System.Drawing.Point(88, 115);
            this.but_OpenPort.Name = "but_OpenPort";
            this.but_OpenPort.Size = new System.Drawing.Size(71, 23);
            this.but_OpenPort.TabIndex = 5;
            this.but_OpenPort.Text = "Open Port";
            this.but_OpenPort.UseVisualStyleBackColor = true;
            this.but_OpenPort.Click += new System.EventHandler(this.but_OpenPort_Click);
            // 
            // group_SETTINGS
            // 
            this.group_SETTINGS.Controls.Add(this.but_OpenPort);
            this.group_SETTINGS.Controls.Add(this.cmB_Parity);
            this.group_SETTINGS.Controls.Add(this.label_Parity);
            this.group_SETTINGS.Controls.Add(this.cmB_Baud);
            this.group_SETTINGS.Controls.Add(this.label_Baud);
            this.group_SETTINGS.Controls.Add(this.cmB_COMport);
            this.group_SETTINGS.Controls.Add(this.label_COMport);
            this.group_SETTINGS.Location = new System.Drawing.Point(12, 67);
            this.group_SETTINGS.Name = "group_SETTINGS";
            this.group_SETTINGS.Size = new System.Drawing.Size(187, 150);
            this.group_SETTINGS.TabIndex = 3;
            this.group_SETTINGS.TabStop = false;
            this.group_SETTINGS.Text = "THIẾT LẬP CỔNG COM";
            // 
            // cmB_Parity
            // 
            this.cmB_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_Parity.FormattingEnabled = true;
            this.cmB_Parity.Location = new System.Drawing.Point(80, 81);
            this.cmB_Parity.Name = "cmB_Parity";
            this.cmB_Parity.Size = new System.Drawing.Size(92, 21);
            this.cmB_Parity.TabIndex = 3;
            this.cmB_Parity.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label_Parity
            // 
            this.label_Parity.AutoSize = true;
            this.label_Parity.Location = new System.Drawing.Point(15, 84);
            this.label_Parity.Name = "label_Parity";
            this.label_Parity.Size = new System.Drawing.Size(33, 13);
            this.label_Parity.TabIndex = 7;
            this.label_Parity.Text = "Parity";
            this.label_Parity.Click += new System.EventHandler(this.label3_Click);
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
            this.cmB_Baud.Location = new System.Drawing.Point(80, 51);
            this.cmB_Baud.Name = "cmB_Baud";
            this.cmB_Baud.Size = new System.Drawing.Size(92, 21);
            this.cmB_Baud.TabIndex = 11;
            this.cmB_Baud.SelectedIndexChanged += new System.EventHandler(this.cmB_Baud_SelectedIndexChanged);
            // 
            // label_Baud
            // 
            this.label_Baud.AutoSize = true;
            this.label_Baud.Location = new System.Drawing.Point(15, 54);
            this.label_Baud.Name = "label_Baud";
            this.label_Baud.Size = new System.Drawing.Size(32, 13);
            this.label_Baud.TabIndex = 5;
            this.label_Baud.Text = "Baud";
            // 
            // cmB_COMport
            // 
            this.cmB_COMport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_COMport.FormattingEnabled = true;
            this.cmB_COMport.Location = new System.Drawing.Point(80, 22);
            this.cmB_COMport.Name = "cmB_COMport";
            this.cmB_COMport.Size = new System.Drawing.Size(92, 21);
            this.cmB_COMport.TabIndex = 4;
            this.cmB_COMport.SelectedIndexChanged += new System.EventHandler(this.cmB_COMport_SelectedIndexChanged);
            // 
            // label_COMport
            // 
            this.label_COMport.AutoSize = true;
            this.label_COMport.Location = new System.Drawing.Point(15, 25);
            this.label_COMport.Name = "label_COMport";
            this.label_COMport.Size = new System.Drawing.Size(49, 13);
            this.label_COMport.TabIndex = 1;
            this.label_COMport.Text = "COMport";
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.Location = new System.Drawing.Point(33, 0);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(121, 21);
            this.cmbStopBits.TabIndex = 0;
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.Location = new System.Drawing.Point(33, 0);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(121, 21);
            this.cmbDataBits.TabIndex = 0;
            // 
            // serialPortRFID
            // 
            this.serialPortRFID.PortName = "COM4";
            this.serialPortRFID.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortLAB_MANAGER_DataReceived);
            // 
            // timer1_DL
            // 
            this.timer1_DL.Interval = 1000;
            // 
            // group_STT
            // 
            this.group_STT.Controls.Add(this.textBox_sttCOM);
            this.group_STT.Controls.Add(this.label_sttServer);
            this.group_STT.Controls.Add(this.richtex_sttServer);
            this.group_STT.Controls.Add(this.label_sttCOM);
            this.group_STT.Location = new System.Drawing.Point(205, 99);
            this.group_STT.Name = "group_STT";
            this.group_STT.Size = new System.Drawing.Size(198, 118);
            this.group_STT.TabIndex = 12;
            this.group_STT.TabStop = false;
            this.group_STT.Text = "TRẠNG THÁI PHẢN HỒI";
            this.group_STT.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // textBox_sttCOM
            // 
            this.textBox_sttCOM.Location = new System.Drawing.Point(63, 19);
            this.textBox_sttCOM.Name = "textBox_sttCOM";
            this.textBox_sttCOM.Size = new System.Drawing.Size(106, 20);
            this.textBox_sttCOM.TabIndex = 26;
            // 
            // label_sttServer
            // 
            this.label_sttServer.AutoSize = true;
            this.label_sttServer.Location = new System.Drawing.Point(10, 56);
            this.label_sttServer.Name = "label_sttServer";
            this.label_sttServer.Size = new System.Drawing.Size(38, 13);
            this.label_sttServer.TabIndex = 21;
            this.label_sttServer.Text = "Server";
            // 
            // richtex_sttServer
            // 
            this.richtex_sttServer.Location = new System.Drawing.Point(57, 50);
            this.richtex_sttServer.Name = "richtex_sttServer";
            this.richtex_sttServer.ReadOnly = true;
            this.richtex_sttServer.Size = new System.Drawing.Size(124, 60);
            this.richtex_sttServer.TabIndex = 22;
            this.richtex_sttServer.Text = "";
            // 
            // label_sttCOM
            // 
            this.label_sttCOM.AutoSize = true;
            this.label_sttCOM.Location = new System.Drawing.Point(12, 22);
            this.label_sttCOM.Name = "label_sttCOM";
            this.label_sttCOM.Size = new System.Drawing.Size(31, 13);
            this.label_sttCOM.TabIndex = 21;
            this.label_sttCOM.Text = "COM";
            // 
            // groupBox_Setting
            // 
            this.groupBox_Setting.Controls.Add(this.uri_request);
            this.groupBox_Setting.Controls.Add(this.button_config);
            this.groupBox_Setting.Controls.Add(this.label_server);
            this.groupBox_Setting.Location = new System.Drawing.Point(205, 10);
            this.groupBox_Setting.Name = "groupBox_Setting";
            this.groupBox_Setting.Size = new System.Drawing.Size(198, 84);
            this.groupBox_Setting.TabIndex = 30;
            this.groupBox_Setting.TabStop = false;
            this.groupBox_Setting.Text = "THIẾT LẬP MÁY CHỦ";
            // 
            // uri_request
            // 
            this.uri_request.Location = new System.Drawing.Point(50, 23);
            this.uri_request.Name = "uri_request";
            this.uri_request.Size = new System.Drawing.Size(136, 20);
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
            // RFIDMAN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 227);
            this.Controls.Add(this.groupBox_Setting);
            this.Controls.Add(this.group_STT);
            this.Controls.Add(this.group_SETTINGS);
            this.Controls.Add(this.group_INFOR);
            this.Name = "RFIDMAN";
            this.Text = "QUẢN LÝ MƯỢN/TRẢ THIẾT BỊ";
            this.Load += new System.EventHandler(this.RFIDMAN_Load);
            this.group_INFOR.ResumeLayout(false);
            this.group_INFOR.PerformLayout();
            this.group_SETTINGS.ResumeLayout(false);
            this.group_SETTINGS.PerformLayout();
            this.group_STT.ResumeLayout(false);
            this.group_STT.PerformLayout();
            this.groupBox_Setting.ResumeLayout(false);
            this.groupBox_Setting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox group_INFOR;
        private System.Windows.Forms.GroupBox group_SETTINGS;
        private System.Windows.Forms.Label label_COMport;
        private System.Windows.Forms.ComboBox cmB_Parity;
        private System.Windows.Forms.Label label_Parity;
        private System.Windows.Forms.ComboBox cmB_Baud;
        private System.Windows.Forms.Label label_Baud;
        private System.Windows.Forms.ComboBox cmB_COMport;
        private System.Windows.Forms.Button but_OpenPort;
        private System.IO.Ports.SerialPort serialPortRFID;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.ComboBox cmbDataBits;
        private System.Windows.Forms.Timer timer1_DL;
        private System.Windows.Forms.Label lb_stt;
        private System.Windows.Forms.GroupBox group_STT;
        private System.Windows.Forms.Label label_sttCOM;
        private System.Windows.Forms.RichTextBox richtex_sttServer;
        private System.Windows.Forms.Label label_sttServer;
        private System.Windows.Forms.GroupBox groupBox_Setting;
        private System.Windows.Forms.Button button_config;
        private System.Windows.Forms.Label label_server;
        private System.Windows.Forms.TextBox uri_request;
        private System.Windows.Forms.TextBox textBox_sttCOM;

    }
}