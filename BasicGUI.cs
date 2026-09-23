// Curtin University Mechatronics Engineering Serial I/O Card - Sample GUI Code

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SerialGUISample
{
	public partial class Form1 : Form
	{
		private const LogLevel LOG_LEVEL = LogLevel.VERBOSE;

		private readonly ControlUtil controlUtil;
		private readonly MeasurementUtil measurementUtil;

		public Form1()
		{
			// Initialize required for form controls.
			InitializeComponent();

			controlUtil = new ControlUtil(true, serial, Log);
			measurementUtil = new MeasurementUtil(Log);
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
			controlUtil.SendDutyFactor(ControlUtil.PORT_SEND1, (double)(BoxSendDuty1.Value / 100));
		}

		/// <summary> Duty Cycle </summary>
		/// <param name="sender"> </param>
		/// <param name="e"> </param>
		private void Send2_Click(object sender, EventArgs e) //Press the button to send the value to Output 2, Arduino Port C.
		{
			controlUtil.SendDutyFactor(ControlUtil.PORT_SEND2, (double)(BoxSendDuty2.Value / 100));
		}

		private void Get1_Click(object sender, EventArgs e) //Press the button to request value from Input 1, Arduino Port F.
		{
			controlUtil.RequestSerialRecieve(ControlUtil.PORT_RECIEVE1);  // The value 0 indicates Input 1, ZERO just maintains a fixed value for the discarded data in order to maintain a consistent package format.
		}

		private void Get2_Click(object sender, EventArgs e) //Press the button to request value from Input 1, Arduino Port K.
		{
			controlUtil.RequestSerialRecieve(ControlUtil.PORT_RECIEVE2);  // The value 1 indicates Input 2, ZERO maintains a consistent value for the message output.
		}

		#endregion IO

		private void GetIOtimer_Tick(object sender, EventArgs e) //It is best to continuously check for incoming data as handling the buffer or waiting for event is not practical in C#.
		{
			(byte port, byte result)? pair = controlUtil.SerialRecieve();
			if (pair.HasValue)
			{
				(byte readPort, byte readByte) = pair.Value;
				TextBox box = null;
				switch (readPort)
				{
					case ControlUtil.PORT_RECIEVE1:
						box = InputBox1;
						break;

					case ControlUtil.PORT_RECIEVE2:
						box = InputBox2;
						break;
				}

				if (box != null)
				{
					string msg = string.Format("Read Byte: {0}", readByte);
					box.Text = msg;
					Log(LogLevel.VERBOSE, msg);
				}
				else
				{
					Log(LogLevel.WARN, "Invalid recieve port read from serial: {0}.", readPort);
				}
			}
			measurementUtil.TickMeasure(controlUtil);
		}

		private IEnumerable<byte> SendBytesGen
		{
			get
			{
				for (double volt = 0.0; volt <= 15.0; volt += 0.2)
				{
					yield return (byte)MathUtils.AmpVoltToByte(volt);
				}
			}
		}

		private void AutoMeasureButton_Click(object sender, EventArgs e)
		{
			measurementUtil.RunAutoMeasure(SendBytesGen, ControlUtil.PORT_SEND1, ControlUtil.PORT_RECIEVE1);
		}
	}
}