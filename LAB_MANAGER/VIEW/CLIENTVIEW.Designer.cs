namespace LAB_MANAGER
{
    partial class CLIENTVIEW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CLIENTVIEW));
            this.button_Detail = new System.Windows.Forms.Button();
            this.but_Try = new System.Windows.Forms.Button();
            this.button_Connect = new System.Windows.Forms.Button();
            this.button_BORROW_RETURN = new System.Windows.Forms.Button();
            this.button_DEVICE = new System.Windows.Forms.Button();
            this.button_USER = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Detail
            // 
            this.button_Detail.BackColor = System.Drawing.SystemColors.Control;
            this.button_Detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_Detail.Image = global::LAB_MANAGER.Properties.Resources.about;
            this.button_Detail.Location = new System.Drawing.Point(454, 14);
            this.button_Detail.Name = "button_Detail";
            this.button_Detail.Size = new System.Drawing.Size(211, 154);
            this.button_Detail.TabIndex = 27;
            this.button_Detail.Text = "CHI TIẾT PHẦN MỀM";
            this.button_Detail.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Detail.UseVisualStyleBackColor = false;
            this.button_Detail.Click += new System.EventHandler(this.button_Detail_Click);
            // 
            // but_Try
            // 
            this.but_Try.BackColor = System.Drawing.SystemColors.Control;
            this.but_Try.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.but_Try.Image = ((System.Drawing.Image)(resources.GetObject("but_Try.Image")));
            this.but_Try.Location = new System.Drawing.Point(454, 176);
            this.but_Try.Name = "but_Try";
            this.but_Try.Size = new System.Drawing.Size(211, 154);
            this.but_Try.TabIndex = 26;
            this.but_Try.Text = "Try";
            this.but_Try.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.but_Try.UseVisualStyleBackColor = false;
            this.but_Try.Click += new System.EventHandler(this.but_Try_Click);
            // 
            // button_Connect
            // 
            this.button_Connect.BackColor = System.Drawing.SystemColors.Control;
            this.button_Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_Connect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_Connect.Image = global::LAB_MANAGER.Properties.Resources.but_detail;
            this.button_Connect.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_Connect.Location = new System.Drawing.Point(237, 176);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(211, 154);
            this.button_Connect.TabIndex = 5;
            this.button_Connect.Text = "KIỂM TRA SERVER";
            this.button_Connect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_Connect.UseVisualStyleBackColor = false;
            this.button_Connect.Click += new System.EventHandler(this.button_Test_Click);
            // 
            // button_BORROW_RETURN
            // 
            this.button_BORROW_RETURN.BackColor = System.Drawing.SystemColors.Control;
            this.button_BORROW_RETURN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_BORROW_RETURN.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_BORROW_RETURN.Image = ((System.Drawing.Image)(resources.GetObject("button_BORROW_RETURN.Image")));
            this.button_BORROW_RETURN.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_BORROW_RETURN.Location = new System.Drawing.Point(16, 176);
            this.button_BORROW_RETURN.Name = "button_BORROW_RETURN";
            this.button_BORROW_RETURN.Size = new System.Drawing.Size(211, 154);
            this.button_BORROW_RETURN.TabIndex = 2;
            this.button_BORROW_RETURN.Text = "MƯỢN/TRẢ THIẾT BỊ";
            this.button_BORROW_RETURN.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_BORROW_RETURN.UseVisualStyleBackColor = false;
            this.button_BORROW_RETURN.Click += new System.EventHandler(this.button_BORROW_RETURN_Click);
            // 
            // button_DEVICE
            // 
            this.button_DEVICE.BackColor = System.Drawing.SystemColors.Control;
            this.button_DEVICE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_DEVICE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_DEVICE.Image = ((System.Drawing.Image)(resources.GetObject("button_DEVICE.Image")));
            this.button_DEVICE.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_DEVICE.Location = new System.Drawing.Point(237, 13);
            this.button_DEVICE.Name = "button_DEVICE";
            this.button_DEVICE.Size = new System.Drawing.Size(211, 155);
            this.button_DEVICE.TabIndex = 1;
            this.button_DEVICE.Text = "QUẢN LÝ THIẾT BỊ";
            this.button_DEVICE.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_DEVICE.UseVisualStyleBackColor = false;
            this.button_DEVICE.Click += new System.EventHandler(this.button_DEVICE_Click);
            // 
            // button_USER
            // 
            this.button_USER.BackColor = System.Drawing.SystemColors.Control;
            this.button_USER.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_USER.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_USER.Image = ((System.Drawing.Image)(resources.GetObject("button_USER.Image")));
            this.button_USER.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button_USER.Location = new System.Drawing.Point(16, 14);
            this.button_USER.Name = "button_USER";
            this.button_USER.Size = new System.Drawing.Size(211, 155);
            this.button_USER.TabIndex = 0;
            this.button_USER.Text = "QUẢN LÝ NGƯỜI DÙNG";
            this.button_USER.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button_USER.UseVisualStyleBackColor = false;
            this.button_USER.Click += new System.EventHandler(this.button_USER_Click);
            // 
            // CLIENTVIEW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(685, 342);
            this.Controls.Add(this.button_Detail);
            this.Controls.Add(this.but_Try);
            this.Controls.Add(this.button_Connect);
            this.Controls.Add(this.button_BORROW_RETURN);
            this.Controls.Add(this.button_DEVICE);
            this.Controls.Add(this.button_USER);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CLIENTVIEW";
            this.Text = "QUẢN LÝ THẺ RFID - PHÒNG THÍ NGHIỆM KỸ THUẬT MÁY TÍNH v1.0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CLIENTVIEW_FormClosing);
            this.Load += new System.EventHandler(this.CLIENTVIEW_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_USER;
        private System.Windows.Forms.Button button_DEVICE;
        private System.Windows.Forms.Button button_BORROW_RETURN;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.Button but_Try;
        private System.Windows.Forms.Button button_Detail;



    }
}