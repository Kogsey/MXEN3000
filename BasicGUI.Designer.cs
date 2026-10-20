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
			this.statusBox = new System.Windows.Forms.TextBox();
			this.AutoMeasureButton = new System.Windows.Forms.Button();
			this.SensorReadLeft = new System.Windows.Forms.TextBox();
			this.SensorReadRight = new System.Windows.Forms.TextBox();
			this.LeftTreadSpeed = new System.Windows.Forms.NumericUpDown();
			this.SendLeftTreadMotor = new System.Windows.Forms.Button();
			this.Get1 = new System.Windows.Forms.Button();
			this.Get2 = new System.Windows.Forms.Button();
			this.SendRightTreadMotor = new System.Windows.Forms.Button();
			this.RightTreadSpeed = new System.Windows.Forms.NumericUpDown();
			this.StopButton = new System.Windows.Forms.Button();
			this.ReversedBitsBox = new System.Windows.Forms.CheckBox();
			this.PID_P = new System.Windows.Forms.NumericUpDown();
			this.PID_I = new System.Windows.Forms.NumericUpDown();
			this.PID_D = new System.Windows.Forms.NumericUpDown();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.RightByteSpeed = new System.Windows.Forms.NumericUpDown();
			this.LeftByteSpeed = new System.Windows.Forms.NumericUpDown();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.SendRightTreadByte = new System.Windows.Forms.Button();
			this.SendLeftTreadByte = new System.Windows.Forms.Button();
			this.SpeedPID = new System.Windows.Forms.CheckBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.Controller_Speed = new System.Windows.Forms.NumericUpDown();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.PIDSlows = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.LeftTreadSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RightTreadSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PID_P)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PID_I)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PID_D)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RightByteSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftByteSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Controller_Speed)).BeginInit();
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
			// statusBox
			// 
			this.statusBox.Location = new System.Drawing.Point(12, 348);
			this.statusBox.Multiline = true;
			this.statusBox.Name = "statusBox";
			this.statusBox.Size = new System.Drawing.Size(531, 135);
			this.statusBox.TabIndex = 5;
			// 
			// AutoMeasureButton
			// 
			this.AutoMeasureButton.Location = new System.Drawing.Point(14, 146);
			this.AutoMeasureButton.Name = "AutoMeasureButton";
			this.AutoMeasureButton.Size = new System.Drawing.Size(126, 23);
			this.AutoMeasureButton.TabIndex = 6;
			this.AutoMeasureButton.Text = "Start";
			this.AutoMeasureButton.UseVisualStyleBackColor = true;
			this.AutoMeasureButton.Click += new System.EventHandler(this.Start);
			// 
			// SensorReadLeft
			// 
			this.SensorReadLeft.Location = new System.Drawing.Point(14, 93);
			this.SensorReadLeft.Name = "SensorReadLeft";
			this.SensorReadLeft.Size = new System.Drawing.Size(126, 20);
			this.SensorReadLeft.TabIndex = 0;
			this.SensorReadLeft.Text = "0";
			// 
			// SensorReadRight
			// 
			this.SensorReadRight.Location = new System.Drawing.Point(14, 120);
			this.SensorReadRight.Name = "SensorReadRight";
			this.SensorReadRight.Size = new System.Drawing.Size(126, 20);
			this.SensorReadRight.TabIndex = 0;
			this.SensorReadRight.Text = "0";
			// 
			// LeftTreadSpeed
			// 
			this.LeftTreadSpeed.DecimalPlaces = 1;
			this.LeftTreadSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.LeftTreadSpeed.Location = new System.Drawing.Point(14, 38);
			this.LeftTreadSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			this.LeftTreadSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
			this.LeftTreadSpeed.Name = "LeftTreadSpeed";
			this.LeftTreadSpeed.Size = new System.Drawing.Size(126, 20);
			this.LeftTreadSpeed.TabIndex = 3;
			// 
			// SendLeftTreadMotor
			// 
			this.SendLeftTreadMotor.Location = new System.Drawing.Point(144, 38);
			this.SendLeftTreadMotor.Name = "SendLeftTreadMotor";
			this.SendLeftTreadMotor.Size = new System.Drawing.Size(75, 20);
			this.SendLeftTreadMotor.TabIndex = 4;
			this.SendLeftTreadMotor.Text = "Set Left Tread";
			this.SendLeftTreadMotor.UseVisualStyleBackColor = true;
			this.SendLeftTreadMotor.Click += new System.EventHandler(this.SendLeftTread_Click);
			// 
			// Get1
			// 
			this.Get1.Location = new System.Drawing.Point(144, 93);
			this.Get1.Name = "Get1";
			this.Get1.Size = new System.Drawing.Size(75, 20);
			this.Get1.TabIndex = 4;
			this.Get1.Text = "Request 1";
			this.Get1.UseVisualStyleBackColor = true;
			this.Get1.Click += new System.EventHandler(this.Get1_Click);
			// 
			// Get2
			// 
			this.Get2.Location = new System.Drawing.Point(144, 120);
			this.Get2.Name = "Get2";
			this.Get2.Size = new System.Drawing.Size(75, 20);
			this.Get2.TabIndex = 4;
			this.Get2.Text = "Request 2";
			this.Get2.UseVisualStyleBackColor = true;
			this.Get2.Click += new System.EventHandler(this.Get2_Click);
			// 
			// SendRightTreadMotor
			// 
			this.SendRightTreadMotor.Location = new System.Drawing.Point(144, 64);
			this.SendRightTreadMotor.Name = "SendRightTreadMotor";
			this.SendRightTreadMotor.Size = new System.Drawing.Size(75, 20);
			this.SendRightTreadMotor.TabIndex = 8;
			this.SendRightTreadMotor.Text = "Set Right Tread";
			this.SendRightTreadMotor.UseVisualStyleBackColor = true;
			this.SendRightTreadMotor.Click += new System.EventHandler(this.SendRightTread_Click);
			// 
			// RightTreadSpeed
			// 
			this.RightTreadSpeed.DecimalPlaces = 1;
			this.RightTreadSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.RightTreadSpeed.Location = new System.Drawing.Point(14, 64);
			this.RightTreadSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			this.RightTreadSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
			this.RightTreadSpeed.Name = "RightTreadSpeed";
			this.RightTreadSpeed.Size = new System.Drawing.Size(126, 20);
			this.RightTreadSpeed.TabIndex = 7;
			// 
			// StopButton
			// 
			this.StopButton.Location = new System.Drawing.Point(144, 146);
			this.StopButton.Name = "StopButton";
			this.StopButton.Size = new System.Drawing.Size(75, 23);
			this.StopButton.TabIndex = 9;
			this.StopButton.Text = "Stop";
			this.StopButton.UseVisualStyleBackColor = true;
			this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
			// 
			// ReversedBitsBox
			// 
			this.ReversedBitsBox.AutoSize = true;
			this.ReversedBitsBox.Location = new System.Drawing.Point(451, 12);
			this.ReversedBitsBox.Name = "ReversedBitsBox";
			this.ReversedBitsBox.Size = new System.Drawing.Size(92, 17);
			this.ReversedBitsBox.TabIndex = 10;
			this.ReversedBitsBox.Text = "Reversed Bits";
			this.ReversedBitsBox.UseVisualStyleBackColor = true;
			this.ReversedBitsBox.CheckedChanged += new System.EventHandler(this.ReversedBitsBox_CheckedChanged);
			// 
			// PID_P
			// 
			this.PID_P.DecimalPlaces = 1;
			this.PID_P.Location = new System.Drawing.Point(14, 175);
			this.PID_P.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.PID_P.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
			this.PID_P.Name = "PID_P";
			this.PID_P.Size = new System.Drawing.Size(126, 20);
			this.PID_P.TabIndex = 11;
			this.PID_P.ValueChanged += new System.EventHandler(this.PID_P_ValueChanged);
			// 
			// PID_I
			// 
			this.PID_I.DecimalPlaces = 1;
			this.PID_I.Location = new System.Drawing.Point(14, 201);
			this.PID_I.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.PID_I.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
			this.PID_I.Name = "PID_I";
			this.PID_I.Size = new System.Drawing.Size(126, 20);
			this.PID_I.TabIndex = 12;
			this.PID_I.ValueChanged += new System.EventHandler(this.PID_I_ValueChanged);
			// 
			// PID_D
			// 
			this.PID_D.DecimalPlaces = 1;
			this.PID_D.Location = new System.Drawing.Point(14, 227);
			this.PID_D.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.PID_D.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
			this.PID_D.Name = "PID_D";
			this.PID_D.Size = new System.Drawing.Size(126, 20);
			this.PID_D.TabIndex = 13;
			this.PID_D.ValueChanged += new System.EventHandler(this.PID_D_ValueChanged);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(14, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(126, 20);
			this.textBox1.TabIndex = 14;
			this.textBox1.Text = "Motor Speed";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(225, 12);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(126, 20);
			this.textBox2.TabIndex = 17;
			this.textBox2.Text = "Raw Byte";
			// 
			// RightByteSpeed
			// 
			this.RightByteSpeed.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.RightByteSpeed.Location = new System.Drawing.Point(225, 64);
			this.RightByteSpeed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.RightByteSpeed.Name = "RightByteSpeed";
			this.RightByteSpeed.Size = new System.Drawing.Size(126, 20);
			this.RightByteSpeed.TabIndex = 16;
			// 
			// LeftByteSpeed
			// 
			this.LeftByteSpeed.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.LeftByteSpeed.Location = new System.Drawing.Point(225, 38);
			this.LeftByteSpeed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.LeftByteSpeed.Name = "LeftByteSpeed";
			this.LeftByteSpeed.Size = new System.Drawing.Size(126, 20);
			this.LeftByteSpeed.TabIndex = 15;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(225, 150);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(112, 17);
			this.checkBox1.TabIndex = 18;
			this.checkBox1.Text = "Controller Enabled";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// SendRightTreadByte
			// 
			this.SendRightTreadByte.Location = new System.Drawing.Point(357, 64);
			this.SendRightTreadByte.Name = "SendRightTreadByte";
			this.SendRightTreadByte.Size = new System.Drawing.Size(75, 20);
			this.SendRightTreadByte.TabIndex = 20;
			this.SendRightTreadByte.Text = "Set Right Tread";
			this.SendRightTreadByte.UseVisualStyleBackColor = true;
			this.SendRightTreadByte.Click += new System.EventHandler(this.SendRightTreadByte_Click);
			// 
			// SendLeftTreadByte
			// 
			this.SendLeftTreadByte.Location = new System.Drawing.Point(357, 38);
			this.SendLeftTreadByte.Name = "SendLeftTreadByte";
			this.SendLeftTreadByte.Size = new System.Drawing.Size(75, 20);
			this.SendLeftTreadByte.TabIndex = 19;
			this.SendLeftTreadByte.Text = "Set Left Tread";
			this.SendLeftTreadByte.UseVisualStyleBackColor = true;
			this.SendLeftTreadByte.Click += new System.EventHandler(this.SendLeftTreadByte_Click);
			// 
			// SpeedPID
			// 
			this.SpeedPID.AutoSize = true;
			this.SpeedPID.Location = new System.Drawing.Point(225, 178);
			this.SpeedPID.Name = "SpeedPID";
			this.SpeedPID.Size = new System.Drawing.Size(105, 17);
			this.SpeedPID.TabIndex = 21;
			this.SpeedPID.Text = "PID Uses Speed";
			this.SpeedPID.UseVisualStyleBackColor = true;
			this.SpeedPID.CheckedChanged += new System.EventHandler(this.SpeedPID_CheckedChanged);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(146, 175);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(73, 20);
			this.textBox3.TabIndex = 22;
			this.textBox3.Text = "P";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(146, 200);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(73, 20);
			this.textBox4.TabIndex = 23;
			this.textBox4.Text = "I";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(146, 226);
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(73, 20);
			this.textBox5.TabIndex = 24;
			this.textBox5.Text = "D";
			// 
			// Controller_Speed
			// 
			this.Controller_Speed.DecimalPlaces = 1;
			this.Controller_Speed.Location = new System.Drawing.Point(14, 253);
			this.Controller_Speed.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.Controller_Speed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.Controller_Speed.Name = "Controller_Speed";
			this.Controller_Speed.Size = new System.Drawing.Size(126, 20);
			this.Controller_Speed.TabIndex = 25;
			this.Controller_Speed.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
			this.Controller_Speed.ValueChanged += new System.EventHandler(this.Controller_Speed_ValueChanged);
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(146, 253);
			this.textBox6.Name = "textBox6";
			this.textBox6.ReadOnly = true;
			this.textBox6.Size = new System.Drawing.Size(73, 20);
			this.textBox6.TabIndex = 26;
			this.textBox6.Text = "Speed";
			// 
			// PIDSlows
			// 
			this.PIDSlows.AutoSize = true;
			this.PIDSlows.Location = new System.Drawing.Point(225, 204);
			this.PIDSlows.Name = "PIDSlows";
			this.PIDSlows.Size = new System.Drawing.Size(99, 17);
			this.PIDSlows.TabIndex = 27;
			this.PIDSlows.Text = "PID Only Slows";
			this.PIDSlows.UseVisualStyleBackColor = true;
			this.PIDSlows.CheckedChanged += new System.EventHandler(this.PIDSlows_CheckedChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(555, 495);
			this.Controls.Add(this.PIDSlows);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.Controller_Speed);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.SpeedPID);
			this.Controls.Add(this.SendRightTreadByte);
			this.Controls.Add(this.SendLeftTreadByte);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.RightByteSpeed);
			this.Controls.Add(this.LeftByteSpeed);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.PID_D);
			this.Controls.Add(this.PID_I);
			this.Controls.Add(this.PID_P);
			this.Controls.Add(this.ReversedBitsBox);
			this.Controls.Add(this.StopButton);
			this.Controls.Add(this.SendRightTreadMotor);
			this.Controls.Add(this.RightTreadSpeed);
			this.Controls.Add(this.AutoMeasureButton);
			this.Controls.Add(this.statusBox);
			this.Controls.Add(this.Get2);
			this.Controls.Add(this.Get1);
			this.Controls.Add(this.SendLeftTreadMotor);
			this.Controls.Add(this.LeftTreadSpeed);
			this.Controls.Add(this.SensorReadRight);
			this.Controls.Add(this.SensorReadLeft);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.LeftTreadSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RightTreadSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PID_P)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PID_I)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PID_D)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RightByteSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftByteSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Controller_Speed)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer getIOtimer;
		private System.IO.Ports.SerialPort serial;
        private System.Windows.Forms.TextBox statusBox;
		private System.Windows.Forms.Button AutoMeasureButton;
		private System.Windows.Forms.TextBox SensorReadLeft;
		private System.Windows.Forms.TextBox SensorReadRight;
		private System.Windows.Forms.NumericUpDown LeftTreadSpeed;
		private System.Windows.Forms.Button SendLeftTreadMotor;
		private System.Windows.Forms.Button Get1;
		private System.Windows.Forms.Button Get2;
		private System.Windows.Forms.Button SendRightTreadMotor;
		private System.Windows.Forms.NumericUpDown RightTreadSpeed;
		private System.Windows.Forms.Button StopButton;
		private System.Windows.Forms.CheckBox ReversedBitsBox;
		private System.Windows.Forms.NumericUpDown PID_P;
		private System.Windows.Forms.NumericUpDown PID_I;
		private System.Windows.Forms.NumericUpDown PID_D;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.NumericUpDown RightByteSpeed;
		private System.Windows.Forms.NumericUpDown LeftByteSpeed;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Button SendRightTreadByte;
		private System.Windows.Forms.Button SendLeftTreadByte;
		private System.Windows.Forms.CheckBox SpeedPID;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.NumericUpDown Controller_Speed;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.CheckBox PIDSlows;
	}
}

