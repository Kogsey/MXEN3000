namespace SerialGUISample
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
			this.components = new System.ComponentModel.Container();
			this.serial = new System.IO.Ports.SerialPort(this.components);
			this.getIOtimer = new System.Windows.Forms.Timer(this.components);
			this.InputBox1 = new System.Windows.Forms.TextBox();
			this.BoxSendDuty1 = new System.Windows.Forms.NumericUpDown();
			this.Send1 = new System.Windows.Forms.Button();
			this.Send2 = new System.Windows.Forms.Button();
			this.Get1 = new System.Windows.Forms.Button();
			this.Get2 = new System.Windows.Forms.Button();
			this.statusBox = new System.Windows.Forms.TextBox();
			this.InputBox2 = new System.Windows.Forms.TextBox();
			this.BoxSendDuty2 = new System.Windows.Forms.NumericUpDown();
			this.AutoMeasureButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.BoxSendDuty1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxSendDuty2)).BeginInit();
			this.SuspendLayout();
			// 
			// serial
			// 
			this.serial.PortName = "COM5";
			// 
			// getIOtimer
			// 
			this.getIOtimer.Enabled = true;
			this.getIOtimer.Interval = 10;
			this.getIOtimer.Tick += new System.EventHandler(this.GetIOtimer_Tick);
			// 
			// InputBox1
			// 
			this.InputBox1.Location = new System.Drawing.Point(12, 67);
			this.InputBox1.Name = "InputBox1";
			this.InputBox1.Size = new System.Drawing.Size(126, 20);
			this.InputBox1.TabIndex = 0;
			this.InputBox1.Text = "0";
			// 
			// BoxSendDuty1
			// 
			this.BoxSendDuty1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.BoxSendDuty1.Location = new System.Drawing.Point(12, 12);
			this.BoxSendDuty1.Name = "BoxSendDuty1";
			this.BoxSendDuty1.Size = new System.Drawing.Size(126, 20);
			this.BoxSendDuty1.TabIndex = 3;
			// 
			// Send1
			// 
			this.Send1.Location = new System.Drawing.Point(142, 12);
			this.Send1.Name = "Send1";
			this.Send1.Size = new System.Drawing.Size(75, 20);
			this.Send1.TabIndex = 4;
			this.Send1.Text = "Send Duty 1";
			this.Send1.UseVisualStyleBackColor = true;
			this.Send1.Click += new System.EventHandler(this.Send1_Click);
			// 
			// Send2
			// 
			this.Send2.Location = new System.Drawing.Point(142, 38);
			this.Send2.Name = "Send2";
			this.Send2.Size = new System.Drawing.Size(75, 20);
			this.Send2.TabIndex = 4;
			this.Send2.Text = "Send Duty 2";
			this.Send2.UseVisualStyleBackColor = true;
			this.Send2.Click += new System.EventHandler(this.Send2_Click);
			// 
			// Get1
			// 
			this.Get1.Location = new System.Drawing.Point(142, 67);
			this.Get1.Name = "Get1";
			this.Get1.Size = new System.Drawing.Size(75, 20);
			this.Get1.TabIndex = 4;
			this.Get1.Text = "Request 1";
			this.Get1.UseVisualStyleBackColor = true;
			this.Get1.Click += new System.EventHandler(this.Get1_Click);
			// 
			// Get2
			// 
			this.Get2.Location = new System.Drawing.Point(142, 94);
			this.Get2.Name = "Get2";
			this.Get2.Size = new System.Drawing.Size(75, 20);
			this.Get2.TabIndex = 4;
			this.Get2.Text = "Request 2";
			this.Get2.UseVisualStyleBackColor = true;
			this.Get2.Click += new System.EventHandler(this.Get2_Click);
			// 
			// statusBox
			// 
			this.statusBox.Location = new System.Drawing.Point(12, 348);
			this.statusBox.Multiline = true;
			this.statusBox.Name = "statusBox";
			this.statusBox.Size = new System.Drawing.Size(531, 135);
			this.statusBox.TabIndex = 5;
			// 
			// InputBox2
			// 
			this.InputBox2.Location = new System.Drawing.Point(12, 94);
			this.InputBox2.Name = "InputBox2";
			this.InputBox2.Size = new System.Drawing.Size(126, 20);
			this.InputBox2.TabIndex = 0;
			this.InputBox2.Text = "0";
			// 
			// BoxSendDuty2
			// 
			this.BoxSendDuty2.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.BoxSendDuty2.Location = new System.Drawing.Point(12, 38);
			this.BoxSendDuty2.Name = "BoxSendDuty2";
			this.BoxSendDuty2.Size = new System.Drawing.Size(126, 20);
			this.BoxSendDuty2.TabIndex = 3;
			// 
			// AutoMeasureButton
			// 
			this.AutoMeasureButton.Location = new System.Drawing.Point(12, 319);
			this.AutoMeasureButton.Name = "AutoMeasureButton";
			this.AutoMeasureButton.Size = new System.Drawing.Size(126, 23);
			this.AutoMeasureButton.TabIndex = 6;
			this.AutoMeasureButton.Text = "Run Auto Routine";
			this.AutoMeasureButton.UseVisualStyleBackColor = true;
			this.AutoMeasureButton.Click += new System.EventHandler(this.AutoMeasureButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(555, 495);
			this.Controls.Add(this.AutoMeasureButton);
			this.Controls.Add(this.statusBox);
			this.Controls.Add(this.Get2);
			this.Controls.Add(this.Get1);
			this.Controls.Add(this.Send2);
			this.Controls.Add(this.Send1);
			this.Controls.Add(this.BoxSendDuty2);
			this.Controls.Add(this.BoxSendDuty1);
			this.Controls.Add(this.InputBox2);
			this.Controls.Add(this.InputBox1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.BoxSendDuty1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BoxSendDuty2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer getIOtimer;
        private System.Windows.Forms.TextBox InputBox1;
        private System.Windows.Forms.NumericUpDown BoxSendDuty1;
		private System.IO.Ports.SerialPort serial;
        private System.Windows.Forms.Button Send1;
        private System.Windows.Forms.Button Send2;
        private System.Windows.Forms.Button Get1;
        private System.Windows.Forms.Button Get2;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.TextBox InputBox2;
        private System.Windows.Forms.NumericUpDown BoxSendDuty2;
		private System.Windows.Forms.Button AutoMeasureButton;
	}
}

