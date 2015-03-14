namespace LAB_MANAGER.CONTROL
{
    partial class RFIDUser
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
            this.group_SETTINGS = new System.Windows.Forms.GroupBox();
            this.cmB_Parity = new System.Windows.Forms.ComboBox();
            this.label_Parity = new System.Windows.Forms.Label();
            this.cmB_Baud = new System.Windows.Forms.ComboBox();
            this.label_Baud = new System.Windows.Forms.Label();
            this.cmB_COMport = new System.Windows.Forms.ComboBox();
            this.label_COMport = new System.Windows.Forms.Label();
            this.button_Send = new System.Windows.Forms.Button();
            this.serialPortLAB_MANAGER = new System.IO.Ports.SerialPort(this.components);
            this.but_OpenPort = new System.Windows.Forms.Button();
            this.group_STT = new System.Windows.Forms.GroupBox();
            this.rictext_sttCOM = new System.Windows.Forms.RichTextBox();
            this.group_INFOR = new System.Windows.Forms.GroupBox();
            this.lb_stt = new System.Windows.Forms.Label();
            this.group_SETTINGS.SuspendLayout();
            this.group_STT.SuspendLayout();
            this.group_INFOR.SuspendLayout();
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
            // group_SETTINGS
            // 
            this.group_SETTINGS.Controls.Add(this.cmB_Parity);
            this.group_SETTINGS.Controls.Add(this.label_Parity);
            this.group_SETTINGS.Controls.Add(this.cmB_Baud);
            this.group_SETTINGS.Controls.Add(this.label_Baud);
            this.group_SETTINGS.Controls.Add(this.cmB_COMport);
            this.group_SETTINGS.Controls.Add(this.label_COMport);
            this.group_SETTINGS.Location = new System.Drawing.Point(12, 12);
            this.group_SETTINGS.Name = "group_SETTINGS";
            this.group_SETTINGS.Size = new System.Drawing.Size(166, 116);
            this.group_SETTINGS.TabIndex = 18;
            this.group_SETTINGS.TabStop = false;
            this.group_SETTINGS.Text = "THIẾT LẬP CỔNG COM";
            // 
            // cmB_Parity
            // 
            this.cmB_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_Parity.FormattingEnabled = true;
            this.cmB_Parity.Location = new System.Drawing.Point(66, 82);
            this.cmB_Parity.Name = "cmB_Parity";
            this.cmB_Parity.Size = new System.Drawing.Size(92, 21);
            this.cmB_Parity.TabIndex = 3;
            // 
            // label_Parity
            // 
            this.label_Parity.AutoSize = true;
            this.label_Parity.Location = new System.Drawing.Point(12, 85);
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
            this.cmB_Baud.Location = new System.Drawing.Point(66, 52);
            this.cmB_Baud.Name = "cmB_Baud";
            this.cmB_Baud.Size = new System.Drawing.Size(92, 21);
            this.cmB_Baud.TabIndex = 11;
            // 
            // label_Baud
            // 
            this.label_Baud.AutoSize = true;
            this.label_Baud.Location = new System.Drawing.Point(12, 55);
            this.label_Baud.Name = "label_Baud";
            this.label_Baud.Size = new System.Drawing.Size(32, 13);
            this.label_Baud.TabIndex = 5;
            this.label_Baud.Text = "Baud";
            // 
            // cmB_COMport
            // 
            this.cmB_COMport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmB_COMport.FormattingEnabled = true;
            this.cmB_COMport.Location = new System.Drawing.Point(66, 21);
            this.cmB_COMport.Name = "cmB_COMport";
            this.cmB_COMport.Size = new System.Drawing.Size(92, 21);
            this.cmB_COMport.TabIndex = 4;
            // 
            // label_COMport
            // 
            this.label_COMport.AutoSize = true;
            this.label_COMport.Location = new System.Drawing.Point(12, 24);
            this.label_COMport.Name = "label_COMport";
            this.label_COMport.Size = new System.Drawing.Size(49, 13);
            this.label_COMport.TabIndex = 1;
            this.label_COMport.Text = "COMport";
            // 
            // button_Send
            // 
            this.button_Send.Location = new System.Drawing.Point(282, 105);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(71, 23);
            this.button_Send.TabIndex = 23;
            this.button_Send.Text = "Send";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_Send_Click);
            // 
            // serialPortLAB_MANAGER
            // 
            this.serialPortLAB_MANAGER.PortName = "COM4";
            this.serialPortLAB_MANAGER.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortLAB_MANAGER_DataReceived);
            // 
            // but_OpenPort
            // 
            this.but_OpenPort.Location = new System.Drawing.Point(185, 105);
            this.but_OpenPort.Name = "but_OpenPort";
            this.but_OpenPort.Size = new System.Drawing.Size(81, 23);
            this.but_OpenPort.TabIndex = 15;
            this.but_OpenPort.Text = "Open Port";
            this.but_OpenPort.UseVisualStyleBackColor = true;
            this.but_OpenPort.Click += new System.EventHandler(this.but_OpenPort_Click);
            // 
            // group_STT
            // 
            this.group_STT.Controls.Add(this.rictext_sttCOM);
            this.group_STT.Location = new System.Drawing.Point(184, 13);
            this.group_STT.Name = "group_STT";
            this.group_STT.Size = new System.Drawing.Size(182, 45);
            this.group_STT.TabIndex = 16;
            this.group_STT.TabStop = false;
            this.group_STT.Text = "TRẠNG THÁI PHẢN HỒI";
            // 
            // rictext_sttCOM
            // 
            this.rictext_sttCOM.Location = new System.Drawing.Point(19, 16);
            this.rictext_sttCOM.Name = "rictext_sttCOM";
            this.rictext_sttCOM.Size = new System.Drawing.Size(145, 23);
            this.rictext_sttCOM.TabIndex = 9;
            this.rictext_sttCOM.Text = "";
            // 
            // group_INFOR
            // 
            this.group_INFOR.Controls.Add(this.lb_stt);
            this.group_INFOR.Location = new System.Drawing.Point(202, 64);
            this.group_INFOR.Name = "group_INFOR";
            this.group_INFOR.Size = new System.Drawing.Size(144, 37);
            this.group_INFOR.TabIndex = 14;
            this.group_INFOR.TabStop = false;
            this.group_INFOR.Text = "THÔNG TIN THẺ RFID";
            // 
            // lb_stt
            // 
            this.lb_stt.AutoSize = true;
            this.lb_stt.Location = new System.Drawing.Point(16, 17);
            this.lb_stt.Name = "lb_stt";
            this.lb_stt.Size = new System.Drawing.Size(62, 13);
            this.lb_stt.TabIndex = 11;
            this.lb_stt.Text = "RFID_code";
            // 
            // RFIDUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 140);
            this.Controls.Add(this.but_OpenPort);
            this.Controls.Add(this.group_SETTINGS);
            this.Controls.Add(this.group_STT);
            this.Controls.Add(this.button_Send);
            this.Controls.Add(this.group_INFOR);
            this.Name = "RFIDUser";
            this.Text = "RFID NGƯỜI DÙNG";
            this.group_SETTINGS.ResumeLayout(false);
            this.group_SETTINGS.PerformLayout();
            this.group_STT.ResumeLayout(false);
            this.group_INFOR.ResumeLayout(false);
            this.group_INFOR.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.ComboBox cmbDataBits;
        private System.Windows.Forms.GroupBox group_SETTINGS;
        private System.Windows.Forms.ComboBox cmB_Parity;
        private System.Windows.Forms.Label label_Parity;
        private System.Windows.Forms.ComboBox cmB_Baud;
        private System.Windows.Forms.Label label_Baud;
        private System.Windows.Forms.ComboBox cmB_COMport;
        private System.Windows.Forms.Label label_COMport;
        private System.Windows.Forms.Button button_Send;
        private System.IO.Ports.SerialPort serialPortLAB_MANAGER;
        private System.Windows.Forms.Button but_OpenPort;
        private System.Windows.Forms.GroupBox group_STT;
        private System.Windows.Forms.RichTextBox rictext_sttCOM;
        private System.Windows.Forms.GroupBox group_INFOR;
        private System.Windows.Forms.Label lb_stt;
    }
}