// Curtin University Mechatronics Engineering Serial I/O Card - Sample GUI Code

using SerialGUISample.Hardware;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SerialGUISample
{
	public partial class Form1 : Form
	{
		private const LogLevel LOG_LEVEL = LogLevel.VERBOSE;

		private readonly BoardComms commsUtil;
		private readonly LineFollowController controller;
		//private readonly MeasurementUtil measurementUtil;

		public Form1()
		{
			// Initialize required for form controls.
			InitializeComponent();

			commsUtil = new BoardComms(true, serial, Log);
			commsUtil.OnSerialRead += UpdateBoxes;

			//measurementUtil = new MeasurementUtil(Log);
			controller = new LineFollowController(commsUtil, Log);
			controller.OnTreadSpeedChanged += UpdateTread;
			controller.PID.Kp = (float)PID_P.Value;
			controller.PID.Ki = (float)PID_I.Value;
			controller.PID.Kd = (float)PID_D.Value;
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

		private void Get1_Click(object sender, EventArgs e) //Press the button to request value from Input 1, Arduino Port F.
		{
			//commsUtil.RequestSerialRecieve(commsUtil.PortRecieve1);  // The value 0 indicates Input 1, ZERO just maintains a fixed value for the discarded data in order to maintain a consistent package format.
		}

		private void Get2_Click(object sender, EventArgs e) //Press the button to request value from Input 1, Arduino Port K.
		{
			//commsUtil.RequestSerialRecieve(commsUtil.PortRecieve2);  // The value 1 indicates Input 2, ZERO maintains a consistent value for the message output.
		}

		#endregion IO

		private void UpdateBoxes(byte readIndex, byte readByte)
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
				Log(LogLevel.WARN, "Invalid recieve port read from serial: {0}.", readIndex);
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

		private static bool enabled = false;

		/// <summary> While it is in fact practical to handle the buffer or waiting for events in versions of C# that aren't over a decade old we're not on one of those for some reason. </summary>
		/// <param name="sender"> </param>
		/// <param name="e"> </param>
		private void GetIOtimer_Tick(object sender, EventArgs e)
		{
			commsUtil.Update();

			if (enabled)
				controller.Update();

			lock (statusBoxUpdate)
			{
				foreach (string log in statusBoxUpdate)
				{
					statusBox.AppendText(log);
				}

				statusBoxUpdate.Clear();
			}
		}

		/*private IEnumerable<byte> SendBytesGen
		{
			get
			{
				for (double volt = 0.0; volt <= 15.0; volt += 0.2)
				{
					yield return (byte)MathUtils.AmpVoltToByte(volt);
				}
			}
		}*/

		private void Start(object sender, EventArgs e)
		{
			enabled = true;
			//measurementUtil.RunAutoMeasure(SendBytesGen, commsUtil.SendPorts[0], commsUtil.ReadPorts[0]);
		}

		private void StopButton_Click(object sender, EventArgs e)
		{
			enabled = false;
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
	}
}