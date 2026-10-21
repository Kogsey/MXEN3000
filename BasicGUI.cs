// Curtin University Mechatronics Engineering Serial I/O Card - Sample GUI Code

using SerialGUISample.Hardware;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SerialGUISample
{
	public partial class MXEN300 : Form
	{
		private const LogLevel LOG_LEVEL = LogLevel.VERBOSE;

		private readonly BoardComms commsUtil;
		private readonly LineFollowController controller;

		public MXEN300()
		{
			// Initialize required for form controls.
			InitializeComponent();

			commsUtil = new BoardComms(serial, Log);
			commsUtil.OnSerialRead += UpdateReadBoxes;

			controller = new LineFollowController(commsUtil, Log);
			controller.OnTreadSpeedChanged += UpdateTread;

			PID_P_ValueChanged(null, null);
			PID_I_ValueChanged(null, null);
			PID_D_ValueChanged(null, null);
			Controller_Speed_ValueChanged(null, null);
			SpeedPID_CheckedChanged(null, null);
			PIDSlows_CheckedChanged(null, null);

			LeftDeadZones_ValueChanged(null, null);
			RightDeadZones_ValueChanged(null, null);
			ReversedBitsBox_CheckedChanged(null, null);
			LeftSenseThresh_ValueChanged(null, null);
			RightSenseThresh_ValueChanged(null, null);
		}

		private readonly List<string> statusBoxUpdate = new List<string>();

		private void Log(LogLevel level, string msg, params object[] arg)
		{
			if (level >= LOG_LEVEL)
			{
				string formatMsg = string.Format(msg, arg);
				string finalMsg = string.Format("{0}: {1}", level, formatMsg);
				Console.WriteLine(finalMsg);
				lock (statusBoxUpdate)
				{
					statusBoxUpdate.Add(finalMsg + "\r\n");
					//statusBox.AppendText(finalMsg + "\r\n");
				}
			}
		}

		private void UpdateReadBoxes(byte readIndex, byte readByte)
		{
			TextBox box = null;
			if (readIndex == 0)
				box = SensorReadLeft;
			if (readIndex == 1)
				box = SensorReadRight;

			if (box != null)
			{
				string msg = string.Format("Read Byte: {0}", readByte);
				box.Text = msg;
				//Log(LogLevel.VERBOSE, msg);
			}
			else
			{
				Log(LogLevel.WARN, "Invalid recieve read from serial read index: {0}.", readIndex);
			}
		}

		private void UpdateTread(byte sendIndex, double treadSpeed)
		{
			NumericUpDown box = null;
			if (sendIndex == 0)
				box = LeftTreadSpeed;
			if (sendIndex == 1)
				box = RightTreadSpeed;

			if (box != null)
			{
				box.Value = (decimal)treadSpeed;
			}
			else
			{
				Log(LogLevel.WARN, "Invalid recieve port read from serial: {0}.", sendIndex);
			}
		}

		private bool ControllerEnabled { get => ControllerEnableCheck.Checked; set => ControllerEnableCheck.Checked = value; }

		private void UpdateLoop(object sender, EventArgs e)
		{
			commsUtil.Update();

			if (ControllerEnabled)
				controller.Update();

			lock (statusBoxUpdate)
			{
				foreach (string log in statusBoxUpdate)
				{
					statusBox.AppendText(log);
				}

				statusBoxUpdate.Clear();
			}

			UpdateUI();
		}

		private void UpdateUI()
		{
			SerialOpenBox.Checked = commsUtil.SerialOpen;

			for (byte i = 0; i < 2; i++)
			{
				if (BoardComms.recievedData[i].HasValue)
					UpdateReadBoxes(i, BoardComms.recievedData[i].Value);
			}
		}

		#region IO

		private void SendLeftTread_Click(object sender, EventArgs e)
		{
			controller.SetLeftTread((double)LeftTreadSpeed.Value);
			Log(LogLevel.GUI, "Sent left tread speed: {0}", (double)LeftTreadSpeed.Value);
		}

		private void SendRightTread_Click(object sender, EventArgs e)
		{
			controller.SetRightTread((double)RightTreadSpeed.Value);
			Log(LogLevel.GUI, "Sent right tread speed: {0}", (double)RightTreadSpeed.Value);
		}

		private void SendLeftTreadByte_Click(object sender, EventArgs e)
		{
			commsUtil.Send(0, (byte)LeftByteSpeed.Value);
			Log(LogLevel.GUI, "Sent left tread byte: {0}", (byte)LeftByteSpeed.Value);
		}

		private void SendRightTreadByte_Click(object sender, EventArgs e)
		{
			commsUtil.Send(1, (byte)RightByteSpeed.Value);
			Log(LogLevel.GUI, "Sent right tread byte: {0}", (byte)RightByteSpeed.Value);
		}

		private void LeftRequestRead_Click(object sender, EventArgs e)
		{
			commsUtil.RequestRead(0);
		}

		private void RightRequestRead_Click(object sender, EventArgs e)
		{
			commsUtil.RequestRead(1);
		}

		private void StartButton_Click(object sender, EventArgs e)
		{
			ControllerEnabled = true;
			controller.SetStarted();
			Log(LogLevel.GUI, "Started");
		}

		private void StopButton_Click(object sender, EventArgs e)
		{
			controller.SetStopped();
			ControllerEnabled = false;
			Log(LogLevel.GUI, "Stopped");
		}

		private void ReversedBitsBox_CheckedChanged(object sender, EventArgs e)
		{
			commsUtil.ReverseSendBits = ReversedBitsBox.Checked;
			Log(LogLevel.GUI, "Reversed Bits Check: {0}", commsUtil.ReverseSendBits);
		}

		private void PID_P_ValueChanged(object sender, EventArgs e)
		{
			controller.PID.Kp = (double)PID_P.Value;
			Log(LogLevel.GUI, "PID Kp: {0}", controller.PID.Kp);
		}

		private void PID_I_ValueChanged(object sender, EventArgs e)
		{
			controller.PID.Ki = (double)PID_I.Value;
			Log(LogLevel.GUI, "PID Ki: {0}", controller.PID.Ki);
		}

		private void PID_D_ValueChanged(object sender, EventArgs e)
		{
			controller.PID.Kd = (double)PID_D.Value;
			Log(LogLevel.GUI, "PID Kd: {0}", controller.PID.Kd);
		}

		private void Controller_Speed_ValueChanged(object sender, EventArgs e)
		{
			controller.BaseSpeed = (double)Controller_Speed.Value;
			Log(LogLevel.GUI, "Controller Speed: {0}", controller.BaseSpeed);
		}

		private void SpeedPID_CheckedChanged(object sender, EventArgs e)
		{
			controller.PIDUsesSpeed = SpeedPID.Checked;
			Log(LogLevel.GUI, "PID Speed Toggle: {0}", controller.PIDUsesSpeed);
		}

		private void PIDSlows_CheckedChanged(object sender, EventArgs e)
		{
			controller.PIDOnlySlows = PIDSlows.Checked;
			Log(LogLevel.GUI, "PID Slows Toggle: {0}", controller.PIDOnlySlows);
		}

		private void LeftDeadZones_ValueChanged(object sender, EventArgs e)
		{
			controller.LeftDeadZones = ((double)LeftDeadLow.Value, (double)LeftDeadZero.Value, (double)LeftDeadHigh.Value);
			Log(LogLevel.GUI, "Updated left dead zones: {0}", controller.LeftDeadZones);
		}

		private void RightDeadZones_ValueChanged(object sender, EventArgs e)
		{
			controller.RightDeadZones = ((double)RightDeadLow.Value, (double)RightDeadZero.Value, (double)RightDeadHigh.Value);
			Log(LogLevel.GUI, "Updated right dead zones: {0}", controller.RightDeadZones);
		}

		#endregion IO

		private void RightSenseThresh_ValueChanged(object sender, EventArgs e)
		{
			controller.RightSense.TrigHigh = controller.RightSense.TrigLow = (byte)RightSenseThresh.Value;
			Log(LogLevel.GUI, "Updated right sensor threshold: {0}", controller.RightSense.TrigHigh);
		}

		private void LeftSenseThresh_ValueChanged(object sender, EventArgs e)
		{
			controller.LeftSense.TrigHigh = controller.LeftSense.TrigLow = (byte)LeftSenseThresh.Value;
			Log(LogLevel.GUI, "Updated left sensor threshold: {0}", controller.LeftSense.TrigHigh);
		}
	}
}