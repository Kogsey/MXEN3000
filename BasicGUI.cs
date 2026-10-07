// Curtin University Mechatronics Engineering Serial I/O Card - Sample GUI Code

using SerialGUISample.Hardware;
using System;
using System.Windows.Forms;

namespace SerialGUISample
{
	public partial class Form1 : Form
	{
		private const LogLevel LOG_LEVEL = LogLevel.VERBOSE;

		private readonly BoardComms commsUtil;
		private readonly Controller controller;
		//private readonly MeasurementUtil measurementUtil;

		public Form1()
		{
			// Initialize required for form controls.
			InitializeComponent();

			commsUtil = new BoardComms(true, serial, Log);
			commsUtil.OnSerialRead += UpdateBoxes;

			//measurementUtil = new MeasurementUtil(Log);
			controller = new LineFollowController(commsUtil, Log);
		}

		private void Log(LogLevel level, string msg, params object[] arg)
		{
			if (level >= LOG_LEVEL)
			{
				string formatMsg = string.Format(msg, arg);
				string finalMsg = string.Format("{0}: {1}", level, formatMsg);
				Console.WriteLine(finalMsg);
				statusBox.AppendText(finalMsg + "\r\n");
			}
		}

		#region IO

		/// <summary> Voltage </summary>
		/// <param name="sender"> </param>
		/// <param name="e"> </param>
		private void Send1_Click(object sender, EventArgs e) //Press the button to send the value to Output 1, Arduino Port A.
		{
			commsUtil.SendDutyFactor(0, (double)(BoxSendDuty1.Value / 100));
		}

		/// <summary> Duty Cycle </summary>
		/// <param name="sender"> </param>
		/// <param name="e"> </param>
		private void Send2_Click(object sender, EventArgs e) //Press the button to send the value to Output 2, Arduino Port C.
		{
			commsUtil.SendDutyFactor(0, (double)(BoxSendDuty2.Value / 100));
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
				box = InputBox1;
			if (readIndex == 1)
				box = InputBox2;

			if (box != null)
			{
				string msg = string.Format("Read Byte: {0}", readByte);
				box.Text = msg;
				Log(LogLevel.VERBOSE, msg);
			}
			else
			{
				Log(LogLevel.WARN, "Invalid recieve port read from serial: {0}.", readIndex);
			}
		}

		/// <summary> While it is in fact practical to handle the buffer or waiting for events in versions of C# that aren't over a decade old we're not on one of those for some reason. </summary>
		/// <param name="sender"> </param>
		/// <param name="e"> </param>
		private void GetIOtimer_Tick(object sender, EventArgs e)
		{
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

		private void AutoMeasureButton_Click(object sender, EventArgs e)
		{
			//measurementUtil.RunAutoMeasure(SendBytesGen, commsUtil.SendPorts[0], commsUtil.ReadPorts[0]);
		}
	}
}