namespace LAB_MANAGER.VIEW
{
    partial class trydemo
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
            this.but_try1 = new System.Windows.Forms.Button();
            this.button_try2 = new System.Windows.Forms.Button();
            this.button_try3 = new System.Windows.Forms.Button();
            this.button_try4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // but_try1
            // 
            this.but_try1.Location = new System.Drawing.Point(23, 12);
            this.but_try1.Name = "but_try1";
            this.but_try1.Size = new System.Drawing.Size(115, 23);
            this.but_try1.TabIndex = 6;
            this.but_try1.Text = "Demothread1";
            this.but_try1.UseVisualStyleBackColor = true;
            this.but_try1.Click += new System.EventHandler(this.but_try1_Click);
            // 
            // button_try2
            // 
            this.button_try2.Location = new System.Drawing.Point(23, 54);
            this.button_try2.Name = "button_try2";
            this.button_try2.Size = new System.Drawing.Size(115, 23);
            this.button_try2.TabIndex = 7;
            this.button_try2.Text = "ThreadSynchorizing";
            this.button_try2.UseVisualStyleBackColor = true;
            this.button_try2.Click += new System.EventHandler(this.button_try2_Click);
            // 
            // button_try3
            // 
            this.button_try3.Location = new System.Drawing.Point(23, 94);
            this.button_try3.Name = "button_try3";
            this.button_try3.Size = new System.Drawing.Size(115, 23);
            this.button_try3.TabIndex = 8;
            this.button_try3.Text = "Thread Pool";
            this.button_try3.UseVisualStyleBackColor = true;
            this.button_try3.Click += new System.EventHandler(this.button_try3_Click);
            // 
            // button_try4
            // 
            this.button_try4.Location = new System.Drawing.Point(23, 133);
            this.button_try4.Name = "button_try4";
            this.button_try4.Size = new System.Drawing.Size(115, 23);
            this.button_try4.TabIndex = 9;
            this.button_try4.Text = "Mutex";
            this.button_try4.UseVisualStyleBackColor = true;
            this.button_try4.Click += new System.EventHandler(this.button_try4_Click);
            // 
            // trydemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button_try4);
            this.Controls.Add(this.button_try3);
            this.Controls.Add(this.button_try2);
            this.Controls.Add(this.but_try1);
            this.Name = "trydemo";
            this.Text = "trydemo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button but_try1;
        private System.Windows.Forms.Button button_try2;
        private System.Windows.Forms.Button button_try3;
        private System.Windows.Forms.Button button_try4;
    }
}