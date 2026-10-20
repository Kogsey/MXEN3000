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

			commsUtil = new BoardComms(true, serial, Log);
			commsUtil.OnSerialRead += UpdateBoxes;

			controller = new LineFollowController(commsUtil, Log);
			controller.OnTreadSpeedChanged += UpdateTread;

			PID_P_ValueChanged(null, null);
			PID_I_ValueChanged(null, null);
			PID_D_ValueChanged(null, null);
			Controller_Speed_ValueChanged(null, null);
			SpeedPID_CheckedChanged(null, null);
			PIDSlows_CheckedChanged(null, null);
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

		#region IO

		/// <summary> Voltage </summary>
		/// <param name="sender"> </param>
		/// <param name="e"> </param>
		private void SendLeftTread_Click(object sender, EventArgs e) //Press the button to send the value to Output 1, Arduino Port A.
		{
			controller.SetLeftTread((double)LeftTreadSpeed.Value);
		}

		private void SendRightTread_Click(object sender, EventArgs e)
		{
			controller.SetRightTread((double)RightTreadSpeed.Value);
		}

		private void SendLeftTreadByte_Click(object sender, EventArgs e)
		{
			commsUtil.Send(0, (byte)LeftByteSpeed.Value);
		}

		private void SendRightTreadByte_Click(object sender, EventArgs e)
		{
			commsUtil.Send(1, (byte)RightByteSpeed.Value);
		}

		private void Get1_Click(object sender, EventArgs e) //Press the button to request value from Input 1, Arduino Port F.
		{
			commsUtil.RequestRead(0);  // The value 0 indicates Input 1, ZERO just maintains a fixed value for the discarded data in order to maintain a consistent package format.
		}

		private void Get2_Click(object sender, EventArgs e) //Press the button to request value from Input 1, Arduino Port K.
		{
			commsUtil.RequestRead(1);  // The value 1 indicates Input 2, ZERO maintains a consistent value for the message output.
		}

		#endregion IO

		private void UpdateBoxes(byte port, byte readByte)
		{
			TextBox box = null;
			if (port == commsUtil.ReadPorts[0])
				box = SensorReadLeft;
			if (port == commsUtil.ReadPorts[1])
				box = SensorReadRight;

			if (box != null)
			{
				string msg = string.Format("Read Byte: {0}", readByte);
				box.Text = msg;
				//Log(LogLevel.VERBOSE, msg);
			}
			else
			{
				Log(LogLevel.WARN, "Invalid recieve port read from serial: {0}.", port);
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

		/// <summary> While it is in fact practical to handle the buffer or waiting for events in versions of C# that aren't over a decade old we're not on one of those for some reason. </summary>
		/// <param name="sender"> </param>
		/// <param name="e"> </param>
		private void GetIOtimer_Tick(object sender, EventArgs e)
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

			for (int i = 0; i < 2; i++)
			{
				if (BoardComms.recievedData[i].HasValue)
					UpdateBoxes((byte)i, BoardComms.recievedData[i].Value);
			}
		}

		private void Start(object sender, EventArgs e)
		{
			ControllerEnabled = true;
		}

		private void StopButton_Click(object sender, EventArgs e)
		{
			ControllerEnabled = false;
			controller.SetStopped();
		}

		private void ReversedBitsBox_CheckedChanged(object sender, EventArgs e)
		{
			BoardComms.REVERSED_BITS = ReversedBitsBox.Checked;
		}

		private void PID_P_ValueChanged(object sender, EventArgs e)
		{
			controller.PID.Kp = (float)PID_P.Value;
			Log(LogLevel.REQUESTED, "PID Kp: {0}", controller.PID.Kp);
		}

		private void PID_I_ValueChanged(object sender, EventArgs e)
		{
			controller.PID.Ki = (float)PID_I.Value;
			Log(LogLevel.REQUESTED, "PID Ki: {0}", controller.PID.Ki);
		}

		private void PID_D_ValueChanged(object sender, EventArgs e)
		{
			controller.PID.Kd = (float)PID_D.Value;
			Log(LogLevel.REQUESTED, "PID Kd: {0}", controller.PID.Kd);
		}

		private void Controller_Speed_ValueChanged(object sender, EventArgs e)
		{
			controller.BaseSpeed = (float)Controller_Speed.Value;
			Log(LogLevel.REQUESTED, "Controller Speed: {0}", controller.BaseSpeed);
		}

		private void SpeedPID_CheckedChanged(object sender, EventArgs e)
		{
			controller.PIDUsesSpeed = SpeedPID.Checked;
			Log(LogLevel.REQUESTED, "PID Speed Toggle: {0}", controller.PIDUsesSpeed);
		}

		private void PIDSlows_CheckedChanged(object sender, EventArgs e)
		{
			controller.PIDOnlySlows = PIDSlows.Checked;
			Log(LogLevel.REQUESTED, "PID Slows Toggle: {0}", controller.PIDOnlySlows);
		}
	}
}