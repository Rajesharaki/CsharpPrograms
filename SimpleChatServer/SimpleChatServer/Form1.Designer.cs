namespace SimpleChatServer
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textLocalIP = new System.Windows.Forms.TextBox();
            this.textLocalPort = new System.Windows.Forms.TextBox();
            this.textRemotePort = new System.Windows.Forms.TextBox();
            this.textRemoteIP = new System.Windows.Forms.TextBox();
            this.Connect = new System.Windows.Forms.Button();
            this.listmsg = new System.Windows.Forms.ListBox();
            this.textmsg = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textLocalPort);
            this.groupBox1.Controls.Add(this.textLocalIP);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 165);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ME";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textRemoteIP);
            this.groupBox2.Controls.Add(this.textRemotePort);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(466, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 165);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FRIEND";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "HOST";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "HOST";
            // 
            // textLocalIP
            // 
            this.textLocalIP.Location = new System.Drawing.Point(72, 19);
            this.textLocalIP.Name = "textLocalIP";
            this.textLocalIP.Size = new System.Drawing.Size(292, 22);
            this.textLocalIP.TabIndex = 3;
            // 
            // textLocalPort
            // 
            this.textLocalPort.Location = new System.Drawing.Point(72, 86);
            this.textLocalPort.Name = "textLocalPort";
            this.textLocalPort.Size = new System.Drawing.Size(292, 22);
            this.textLocalPort.TabIndex = 4;
            // 
            // textRemotePort
            // 
            this.textRemotePort.Location = new System.Drawing.Point(76, 86);
            this.textRemotePort.Name = "textRemotePort";
            this.textRemotePort.Size = new System.Drawing.Size(292, 22);
            this.textRemotePort.TabIndex = 4;
            // 
            // textRemoteIP
            // 
            this.textRemoteIP.Location = new System.Drawing.Point(76, 17);
            this.textRemoteIP.Name = "textRemoteIP";
            this.textRemoteIP.Size = new System.Drawing.Size(292, 22);
            this.textRemoteIP.TabIndex = 5;
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(985, 77);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(114, 43);
            this.Connect.TabIndex = 2;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // listmsg
            // 
            this.listmsg.FormattingEnabled = true;
            this.listmsg.ItemHeight = 16;
            this.listmsg.Location = new System.Drawing.Point(12, 232);
            this.listmsg.Name = "listmsg";
            this.listmsg.Size = new System.Drawing.Size(1087, 372);
            this.listmsg.TabIndex = 3;
            // 
            // textmsg
            // 
            this.textmsg.Location = new System.Drawing.Point(12, 645);
            this.textmsg.Name = "textmsg";
            this.textmsg.Size = new System.Drawing.Size(928, 22);
            this.textmsg.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(985, 624);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 43);
            this.button1.TabIndex = 5;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 701);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textmsg);
            this.Controls.Add(this.listmsg);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textLocalPort;
        private System.Windows.Forms.TextBox textLocalIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textRemoteIP;
        private System.Windows.Forms.TextBox textRemotePort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.ListBox listmsg;
        private System.Windows.Forms.TextBox textmsg;
        private System.Windows.Forms.Button button1;
    }
}

