namespace SerialGUISample
{
    partial class MXEN300
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
			this.ControllerEnableCheck = new System.Windows.Forms.CheckBox();
			this.SendRightTreadByte = new System.Windows.Forms.Button();
			this.SendLeftTreadByte = new System.Windows.Forms.Button();
			this.SpeedPID = new System.Windows.Forms.CheckBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.Controller_Speed = new System.Windows.Forms.NumericUpDown();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.PIDSlows = new System.Windows.Forms.CheckBox();
			this.SerialOpenBox = new System.Windows.Forms.CheckBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.LeftDeadLow = new System.Windows.Forms.NumericUpDown();
			this.LeftDeadZero = new System.Windows.Forms.NumericUpDown();
			this.LeftDeadHigh = new System.Windows.Forms.NumericUpDown();
			this.RightDeadHigh = new System.Windows.Forms.NumericUpDown();
			this.RightDeadZero = new System.Windows.Forms.NumericUpDown();
			this.RightDeadLow = new System.Windows.Forms.NumericUpDown();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.RightSenseThresh = new System.Windows.Forms.NumericUpDown();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.LeftSenseThresh = new System.Windows.Forms.NumericUpDown();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.SerialPort = new System.Windows.Forms.TextBox();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.DeadZoneCheck = new System.Windows.Forms.CheckBox();
			this.Debug = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.LeftTreadSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RightTreadSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PID_P)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PID_I)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PID_D)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RightByteSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftByteSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Controller_Speed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftDeadLow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftDeadZero)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftDeadHigh)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RightDeadHigh)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RightDeadZero)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RightDeadLow)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RightSenseThresh)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftSenseThresh)).BeginInit();
			this.SuspendLayout();
			// 
			// serial
			// 
			this.serial.BaudRate = 115200;
			this.serial.PortName = "COM5";
			// 
			// getIOtimer
			// 
			this.getIOtimer.Enabled = true;
			this.getIOtimer.Interval = 10;
			this.getIOtimer.Tick += new System.EventHandler(this.UpdateLoop);
			// 
			// statusBox
			// 
			this.statusBox.Location = new System.Drawing.Point(12, 279);
			this.statusBox.Multiline = true;
			this.statusBox.Name = "statusBox";
			this.statusBox.Size = new System.Drawing.Size(531, 204);
			this.statusBox.TabIndex = 5;
			this.statusBox.TabStop = false;
			// 
			// AutoMeasureButton
			// 
			this.AutoMeasureButton.Location = new System.Drawing.Point(12, 146);
			this.AutoMeasureButton.Name = "AutoMeasureButton";
			this.AutoMeasureButton.Size = new System.Drawing.Size(126, 23);
			this.AutoMeasureButton.TabIndex = 8;
			this.AutoMeasureButton.Text = "Start";
			this.AutoMeasureButton.UseVisualStyleBackColor = true;
			this.AutoMeasureButton.Click += new System.EventHandler(this.StartButton_Click);
			// 
			// SensorReadLeft
			// 
			this.SensorReadLeft.Location = new System.Drawing.Point(12, 93);
			this.SensorReadLeft.Name = "SensorReadLeft";
			this.SensorReadLeft.Size = new System.Drawing.Size(126, 20);
			this.SensorReadLeft.TabIndex = 4;
			this.SensorReadLeft.Text = "0";
			// 
			// SensorReadRight
			// 
			this.SensorReadRight.Location = new System.Drawing.Point(12, 120);
			this.SensorReadRight.Name = "SensorReadRight";
			this.SensorReadRight.Size = new System.Drawing.Size(126, 20);
			this.SensorReadRight.TabIndex = 6;
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
			this.LeftTreadSpeed.Location = new System.Drawing.Point(12, 38);
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
			this.LeftTreadSpeed.TabIndex = 0;
			// 
			// SendLeftTreadMotor
			// 
			this.SendLeftTreadMotor.Location = new System.Drawing.Point(142, 38);
			this.SendLeftTreadMotor.Name = "SendLeftTreadMotor";
			this.SendLeftTreadMotor.Size = new System.Drawing.Size(75, 20);
			this.SendLeftTreadMotor.TabIndex = 1;
			this.SendLeftTreadMotor.Text = "Set Left Tread";
			this.SendLeftTreadMotor.UseVisualStyleBackColor = true;
			this.SendLeftTreadMotor.Click += new System.EventHandler(this.SendLeftTread_Click);
			// 
			// Get1
			// 
			this.Get1.Location = new System.Drawing.Point(142, 93);
			this.Get1.Name = "Get1";
			this.Get1.Size = new System.Drawing.Size(75, 20);
			this.Get1.TabIndex = 5;
			this.Get1.Text = "Request 1";
			this.Get1.UseVisualStyleBackColor = true;
			this.Get1.Click += new System.EventHandler(this.LeftRequestRead_Click);
			// 
			// Get2
			// 
			this.Get2.Location = new System.Drawing.Point(142, 120);
			this.Get2.Name = "Get2";
			this.Get2.Size = new System.Drawing.Size(75, 20);
			this.Get2.TabIndex = 7;
			this.Get2.Text = "Request 2";
			this.Get2.UseVisualStyleBackColor = true;
			this.Get2.Click += new System.EventHandler(this.RightRequestRead_Click);
			// 
			// SendRightTreadMotor
			// 
			this.SendRightTreadMotor.Location = new System.Drawing.Point(142, 64);
			this.SendRightTreadMotor.Name = "SendRightTreadMotor";
			this.SendRightTreadMotor.Size = new System.Drawing.Size(75, 20);
			this.SendRightTreadMotor.TabIndex = 3;
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
			this.RightTreadSpeed.Location = new System.Drawing.Point(12, 64);
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
			this.RightTreadSpeed.TabIndex = 2;
			// 
			// StopButton
			// 
			this.StopButton.Location = new System.Drawing.Point(142, 146);
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
			this.ReversedBitsBox.Checked = true;
			this.ReversedBitsBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ReversedBitsBox.Location = new System.Drawing.Point(549, 329);
			this.ReversedBitsBox.Name = "ReversedBitsBox";
			this.ReversedBitsBox.Size = new System.Drawing.Size(92, 17);
			this.ReversedBitsBox.TabIndex = 32;
			this.ReversedBitsBox.Text = "Reversed Bits";
			this.ReversedBitsBox.UseVisualStyleBackColor = true;
			this.ReversedBitsBox.CheckedChanged += new System.EventHandler(this.ReversedBitsBox_CheckedChanged);
			// 
			// PID_P
			// 
			this.PID_P.DecimalPlaces = 2;
			this.PID_P.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			this.PID_P.Location = new System.Drawing.Point(12, 175);
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
			this.PID_P.TabIndex = 10;
			this.PID_P.Value = new decimal(new int[] {
            21,
            0,
            0,
            65536});
			this.PID_P.ValueChanged += new System.EventHandler(this.PID_P_ValueChanged);
			// 
			// PID_I
			// 
			this.PID_I.DecimalPlaces = 2;
			this.PID_I.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			this.PID_I.Location = new System.Drawing.Point(12, 201);
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
			this.PID_I.TabIndex = 11;
			this.PID_I.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.PID_I.ValueChanged += new System.EventHandler(this.PID_I_ValueChanged);
			// 
			// PID_D
			// 
			this.PID_D.DecimalPlaces = 2;
			this.PID_D.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
			this.PID_D.Location = new System.Drawing.Point(12, 227);
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
			this.PID_D.TabIndex = 12;
			this.PID_D.ValueChanged += new System.EventHandler(this.PID_D_ValueChanged);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(126, 20);
			this.textBox1.TabIndex = 14;
			this.textBox1.TabStop = false;
			this.textBox1.Text = "Motor Speed";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(223, 12);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(126, 20);
			this.textBox2.TabIndex = 17;
			this.textBox2.TabStop = false;
			this.textBox2.Text = "Raw Byte";
			// 
			// RightByteSpeed
			// 
			this.RightByteSpeed.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.RightByteSpeed.Location = new System.Drawing.Point(223, 64);
			this.RightByteSpeed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.RightByteSpeed.Name = "RightByteSpeed";
			this.RightByteSpeed.Size = new System.Drawing.Size(126, 20);
			this.RightByteSpeed.TabIndex = 19;
			// 
			// LeftByteSpeed
			// 
			this.LeftByteSpeed.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
			this.LeftByteSpeed.Location = new System.Drawing.Point(223, 38);
			this.LeftByteSpeed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.LeftByteSpeed.Name = "LeftByteSpeed";
			this.LeftByteSpeed.Size = new System.Drawing.Size(126, 20);
			this.LeftByteSpeed.TabIndex = 17;
			// 
			// ControllerEnableCheck
			// 
			this.ControllerEnableCheck.AutoSize = true;
			this.ControllerEnableCheck.Location = new System.Drawing.Point(223, 150);
			this.ControllerEnableCheck.Name = "ControllerEnableCheck";
			this.ControllerEnableCheck.Size = new System.Drawing.Size(112, 17);
			this.ControllerEnableCheck.TabIndex = 14;
			this.ControllerEnableCheck.Text = "Controller Enabled";
			this.ControllerEnableCheck.UseVisualStyleBackColor = true;
			// 
			// SendRightTreadByte
			// 
			this.SendRightTreadByte.Location = new System.Drawing.Point(355, 64);
			this.SendRightTreadByte.Name = "SendRightTreadByte";
			this.SendRightTreadByte.Size = new System.Drawing.Size(75, 20);
			this.SendRightTreadByte.TabIndex = 20;
			this.SendRightTreadByte.Text = "Set Right Tread";
			this.SendRightTreadByte.UseVisualStyleBackColor = true;
			this.SendRightTreadByte.Click += new System.EventHandler(this.SendRightTreadByte_Click);
			// 
			// SendLeftTreadByte
			// 
			this.SendLeftTreadByte.Location = new System.Drawing.Point(355, 38);
			this.SendLeftTreadByte.Name = "SendLeftTreadByte";
			this.SendLeftTreadByte.Size = new System.Drawing.Size(75, 20);
			this.SendLeftTreadByte.TabIndex = 18;
			this.SendLeftTreadByte.Text = "Set Left Tread";
			this.SendLeftTreadByte.UseVisualStyleBackColor = true;
			this.SendLeftTreadByte.Click += new System.EventHandler(this.SendLeftTreadByte_Click);
			// 
			// SpeedPID
			// 
			this.SpeedPID.AutoSize = true;
			this.SpeedPID.Location = new System.Drawing.Point(223, 178);
			this.SpeedPID.Name = "SpeedPID";
			this.SpeedPID.Size = new System.Drawing.Size(105, 17);
			this.SpeedPID.TabIndex = 15;
			this.SpeedPID.Text = "PID Uses Speed";
			this.SpeedPID.UseVisualStyleBackColor = true;
			this.SpeedPID.CheckedChanged += new System.EventHandler(this.SpeedPID_CheckedChanged);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(144, 175);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(73, 20);
			this.textBox3.TabIndex = 22;
			this.textBox3.TabStop = false;
			this.textBox3.Text = "P";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(144, 200);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(73, 20);
			this.textBox4.TabIndex = 23;
			this.textBox4.TabStop = false;
			this.textBox4.Text = "I";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(144, 226);
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(73, 20);
			this.textBox5.TabIndex = 24;
			this.textBox5.TabStop = false;
			this.textBox5.Text = "D";
			// 
			// Controller_Speed
			// 
			this.Controller_Speed.DecimalPlaces = 2;
			this.Controller_Speed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.Controller_Speed.Location = new System.Drawing.Point(12, 253);
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
			this.Controller_Speed.TabIndex = 13;
			this.Controller_Speed.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.Controller_Speed.ValueChanged += new System.EventHandler(this.Controller_Speed_ValueChanged);
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(144, 253);
			this.textBox6.Name = "textBox6";
			this.textBox6.ReadOnly = true;
			this.textBox6.Size = new System.Drawing.Size(73, 20);
			this.textBox6.TabIndex = 26;
			this.textBox6.TabStop = false;
			this.textBox6.Text = "Speed";
			// 
			// PIDSlows
			// 
			this.PIDSlows.AutoSize = true;
			this.PIDSlows.Checked = true;
			this.PIDSlows.CheckState = System.Windows.Forms.CheckState.Checked;
			this.PIDSlows.Location = new System.Drawing.Point(223, 204);
			this.PIDSlows.Name = "PIDSlows";
			this.PIDSlows.Size = new System.Drawing.Size(99, 17);
			this.PIDSlows.TabIndex = 16;
			this.PIDSlows.Text = "PID Only Slows";
			this.PIDSlows.UseVisualStyleBackColor = true;
			this.PIDSlows.CheckedChanged += new System.EventHandler(this.PIDSlows_CheckedChanged);
			// 
			// SerialOpenBox
			// 
			this.SerialOpenBox.AutoSize = true;
			this.SerialOpenBox.Location = new System.Drawing.Point(549, 303);
			this.SerialOpenBox.Name = "SerialOpenBox";
			this.SerialOpenBox.Size = new System.Drawing.Size(92, 17);
			this.SerialOpenBox.TabIndex = 31;
			this.SerialOpenBox.Text = "Is Serial Open";
			this.SerialOpenBox.UseVisualStyleBackColor = true;
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(549, 12);
			this.textBox9.Name = "textBox9";
			this.textBox9.ReadOnly = true;
			this.textBox9.Size = new System.Drawing.Size(126, 20);
			this.textBox9.TabIndex = 33;
			this.textBox9.TabStop = false;
			this.textBox9.Text = "Left Dead Zones";
			// 
			// LeftDeadLow
			// 
			this.LeftDeadLow.DecimalPlaces = 2;
			this.LeftDeadLow.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.LeftDeadLow.Location = new System.Drawing.Point(549, 38);
			this.LeftDeadLow.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			this.LeftDeadLow.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
			this.LeftDeadLow.Name = "LeftDeadLow";
			this.LeftDeadLow.Size = new System.Drawing.Size(126, 20);
			this.LeftDeadLow.TabIndex = 23;
			this.LeftDeadLow.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147418112});
			this.LeftDeadLow.ValueChanged += new System.EventHandler(this.LeftDeadZones_ValueChanged);
			// 
			// LeftDeadZero
			// 
			this.LeftDeadZero.DecimalPlaces = 2;
			this.LeftDeadZero.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.LeftDeadZero.Location = new System.Drawing.Point(549, 64);
			this.LeftDeadZero.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			this.LeftDeadZero.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
			this.LeftDeadZero.Name = "LeftDeadZero";
			this.LeftDeadZero.Size = new System.Drawing.Size(126, 20);
			this.LeftDeadZero.TabIndex = 25;
			this.LeftDeadZero.ValueChanged += new System.EventHandler(this.LeftDeadZones_ValueChanged);
			// 
			// LeftDeadHigh
			// 
			this.LeftDeadHigh.DecimalPlaces = 2;
			this.LeftDeadHigh.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.LeftDeadHigh.Location = new System.Drawing.Point(549, 90);
			this.LeftDeadHigh.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			this.LeftDeadHigh.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
			this.LeftDeadHigh.Name = "LeftDeadHigh";
			this.LeftDeadHigh.Size = new System.Drawing.Size(126, 20);
			this.LeftDeadHigh.TabIndex = 27;
			this.LeftDeadHigh.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.LeftDeadHigh.ValueChanged += new System.EventHandler(this.LeftDeadZones_ValueChanged);
			// 
			// RightDeadHigh
			// 
			this.RightDeadHigh.DecimalPlaces = 2;
			this.RightDeadHigh.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.RightDeadHigh.Location = new System.Drawing.Point(681, 90);
			this.RightDeadHigh.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			this.RightDeadHigh.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
			this.RightDeadHigh.Name = "RightDeadHigh";
			this.RightDeadHigh.Size = new System.Drawing.Size(126, 20);
			this.RightDeadHigh.TabIndex = 28;
			this.RightDeadHigh.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.RightDeadHigh.ValueChanged += new System.EventHandler(this.RightDeadZones_ValueChanged);
			// 
			// RightDeadZero
			// 
			this.RightDeadZero.DecimalPlaces = 2;
			this.RightDeadZero.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.RightDeadZero.Location = new System.Drawing.Point(681, 64);
			this.RightDeadZero.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			this.RightDeadZero.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
			this.RightDeadZero.Name = "RightDeadZero";
			this.RightDeadZero.Size = new System.Drawing.Size(126, 20);
			this.RightDeadZero.TabIndex = 26;
			this.RightDeadZero.ValueChanged += new System.EventHandler(this.RightDeadZones_ValueChanged);
			// 
			// RightDeadLow
			// 
			this.RightDeadLow.DecimalPlaces = 2;
			this.RightDeadLow.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.RightDeadLow.Location = new System.Drawing.Point(681, 38);
			this.RightDeadLow.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
			this.RightDeadLow.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147418112});
			this.RightDeadLow.Name = "RightDeadLow";
			this.RightDeadLow.Size = new System.Drawing.Size(126, 20);
			this.RightDeadLow.TabIndex = 24;
			this.RightDeadLow.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147418112});
			this.RightDeadLow.ValueChanged += new System.EventHandler(this.RightDeadZones_ValueChanged);
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(681, 12);
			this.textBox10.Name = "textBox10";
			this.textBox10.ReadOnly = true;
			this.textBox10.Size = new System.Drawing.Size(126, 20);
			this.textBox10.TabIndex = 37;
			this.textBox10.TabStop = false;
			this.textBox10.Text = "Right Dead Zones";
			// 
			// RightSenseThresh
			// 
			this.RightSenseThresh.Location = new System.Drawing.Point(681, 142);
			this.RightSenseThresh.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.RightSenseThresh.Name = "RightSenseThresh";
			this.RightSenseThresh.Size = new System.Drawing.Size(126, 20);
			this.RightSenseThresh.TabIndex = 30;
			this.RightSenseThresh.Value = new decimal(new int[] {
            215,
            0,
            0,
            0});
			this.RightSenseThresh.ValueChanged += new System.EventHandler(this.RightSenseThresh_ValueChanged);
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(681, 116);
			this.textBox7.Name = "textBox7";
			this.textBox7.ReadOnly = true;
			this.textBox7.Size = new System.Drawing.Size(126, 20);
			this.textBox7.TabIndex = 41;
			this.textBox7.TabStop = false;
			this.textBox7.Text = "Right Sensor Threshold";
			// 
			// LeftSenseThresh
			// 
			this.LeftSenseThresh.Location = new System.Drawing.Point(549, 142);
			this.LeftSenseThresh.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.LeftSenseThresh.Name = "LeftSenseThresh";
			this.LeftSenseThresh.Size = new System.Drawing.Size(126, 20);
			this.LeftSenseThresh.TabIndex = 29;
			this.LeftSenseThresh.Value = new decimal(new int[] {
            215,
            0,
            0,
            0});
			this.LeftSenseThresh.ValueChanged += new System.EventHandler(this.LeftSenseThresh_ValueChanged);
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(549, 116);
			this.textBox8.Name = "textBox8";
			this.textBox8.ReadOnly = true;
			this.textBox8.Size = new System.Drawing.Size(126, 20);
			this.textBox8.TabIndex = 40;
			this.textBox8.TabStop = false;
			this.textBox8.Text = "Left Sensor Threshold";
			// 
			// SerialPort
			// 
			this.SerialPort.Location = new System.Drawing.Point(549, 194);
			this.SerialPort.Name = "SerialPort";
			this.SerialPort.Size = new System.Drawing.Size(126, 20);
			this.SerialPort.TabIndex = 42;
			this.SerialPort.TextChanged += new System.EventHandler(this.SerialPort_TextChanged);
			// 
			// textBox12
			// 
			this.textBox12.Location = new System.Drawing.Point(681, 194);
			this.textBox12.Name = "textBox12";
			this.textBox12.ReadOnly = true;
			this.textBox12.Size = new System.Drawing.Size(126, 20);
			this.textBox12.TabIndex = 43;
			this.textBox12.TabStop = false;
			this.textBox12.Text = "Serial Port";
			// 
			// DeadZoneCheck
			// 
			this.DeadZoneCheck.AutoSize = true;
			this.DeadZoneCheck.Location = new System.Drawing.Point(436, 12);
			this.DeadZoneCheck.Name = "DeadZoneCheck";
			this.DeadZoneCheck.Size = new System.Drawing.Size(107, 17);
			this.DeadZoneCheck.TabIndex = 44;
			this.DeadZoneCheck.Text = "Use Dead Zones";
			this.DeadZoneCheck.UseVisualStyleBackColor = true;
			this.DeadZoneCheck.CheckedChanged += new System.EventHandler(this.DeadZoneCheck_CheckedChanged);
			// 
			// Debug
			// 
			this.Debug.Location = new System.Drawing.Point(355, 204);
			this.Debug.Name = "Debug";
			this.Debug.Size = new System.Drawing.Size(126, 20);
			this.Debug.TabIndex = 45;
			// 
			// MXEN300
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(866, 495);
			this.Controls.Add(this.Debug);
			this.Controls.Add(this.DeadZoneCheck);
			this.Controls.Add(this.textBox12);
			this.Controls.Add(this.SerialPort);
			this.Controls.Add(this.RightSenseThresh);
			this.Controls.Add(this.textBox7);
			this.Controls.Add(this.LeftSenseThresh);
			this.Controls.Add(this.textBox8);
			this.Controls.Add(this.RightDeadHigh);
			this.Controls.Add(this.RightDeadZero);
			this.Controls.Add(this.RightDeadLow);
			this.Controls.Add(this.textBox10);
			this.Controls.Add(this.LeftDeadHigh);
			this.Controls.Add(this.LeftDeadZero);
			this.Controls.Add(this.LeftDeadLow);
			this.Controls.Add(this.textBox9);
			this.Controls.Add(this.SerialOpenBox);
			this.Controls.Add(this.PIDSlows);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.Controller_Speed);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.SpeedPID);
			this.Controls.Add(this.SendRightTreadByte);
			this.Controls.Add(this.SendLeftTreadByte);
			this.Controls.Add(this.ControllerEnableCheck);
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
			this.Name = "MXEN300";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.LeftTreadSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RightTreadSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PID_P)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PID_I)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PID_D)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RightByteSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftByteSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Controller_Speed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftDeadLow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftDeadZero)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftDeadHigh)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RightDeadHigh)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RightDeadZero)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RightDeadLow)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RightSenseThresh)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LeftSenseThresh)).EndInit();
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
		private System.Windows.Forms.CheckBox ControllerEnableCheck;
		private System.Windows.Forms.Button SendRightTreadByte;
		private System.Windows.Forms.Button SendLeftTreadByte;
		private System.Windows.Forms.CheckBox SpeedPID;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.NumericUpDown Controller_Speed;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.CheckBox PIDSlows;
		private System.Windows.Forms.CheckBox SerialOpenBox;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.NumericUpDown LeftDeadLow;
		private System.Windows.Forms.NumericUpDown LeftDeadZero;
		private System.Windows.Forms.NumericUpDown LeftDeadHigh;
		private System.Windows.Forms.NumericUpDown RightDeadHigh;
		private System.Windows.Forms.NumericUpDown RightDeadZero;
		private System.Windows.Forms.NumericUpDown RightDeadLow;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.NumericUpDown RightSenseThresh;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.NumericUpDown LeftSenseThresh;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TextBox SerialPort;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.CheckBox DeadZoneCheck;
		private System.Windows.Forms.TextBox Debug;
	}
}

