// Curtin University Mechatronics Engineering Serial I/O Card - Sample GUI Code

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SerialGUISample
{
	public partial class Form1 : Form
	{
		// Declare variables to store inputs and outputs.
		private bool runSerial = true;

		private bool byteRead = false;
		private int Input1 = 0;
		private int Input2 = 0;

		private byte[] Outputs = new byte[4];
		private byte[] Inputs = new byte[4];

		private const byte START = 255;
		private const byte ZERO = 0;

		private const float Vref = 15;

		public Form1()
		{
			// Initialize required for form controls.
			InitializeComponent();

			// Establish connection with serial
			if (runSerial == true)
			{
				if (!serial.IsOpen)                                  // Check if the serial has been connected.
				{
					try
					{
						serial.Open();                               //Try to connect to the serial.
					}
					catch
					{
						statusBox.Enabled = false;
						statusBox.Text = "ERROR: Failed to connect.";     //If the serial does not connect return an error.
					}
				}
			}
		}

		#region IO

		// Send a four byte message to the Arduino via serial.
		private void SendIO(byte PORT, byte DATA)
		{
			Outputs[0] = START;    //Set the first byte to the start value that indicates the beginning of the message.
			Outputs[1] = PORT;     //Set the second byte to represent the port where, Input 1 = 0, Input 2 = 1, Output 1 = 2 & Output 2 = 3. This could be enumerated to make writing code simpler... (see Arduino driver)
			Outputs[2] = DATA;  //Set the third byte to the value to be assigned to the port. This is only necessary for outputs, however it is best to assign a consistent value such as 0 for input ports.
			Outputs[3] = (byte)(START + PORT + DATA); //Calculate the checksum byte, the same calculation is performed on the Arduino side to confirm the message was received correctly.

			if (serial.IsOpen)
			{
				serial.Write(Outputs, 0, 4);         //Send all four bytes to the IO card.
			}
		}

		/// <summary> Voltage </summary>
		/// <param name="sender"> </param>
		/// <param name="e"> </param>
		private void Send1_Click(object sender, EventArgs e) //Press the button to send the value to Output 1, Arduino Port A.
		{
			SendOutVoltage((double)OutputBox1.Value);
		}

		/// <summary> Duty Cycle </summary>
		/// <param name="sender"> </param>
		/// <param name="e"> </param>
		private void Send2_Click(object sender, EventArgs e) //Press the button to send the value to Output 2, Arduino Port C.
		{
			double duty = (double)OutputBox2.Value;
			double duty01 = duty / 100;
			SendDuty01(duty01);

			//SendIO(3, (byte)OutputBox2.Value); // The value 3 indicates Output2, value for output set in OutputBox1.
		}

		private void Get1_Click(object sender, EventArgs e) //Press the button to request value from Input 1, Arduino Port F.
		{
			SendIO(0, ZERO);  // The value 0 indicates Input 1, ZERO just maintains a fixed value for the discarded data in order to maintain a consistent package format.
		}

		private void Get2_Click(object sender, EventArgs e) //Press the button to request value from Input 1, Arduino Port K.
		{
			SendIO(1, ZERO);  // The value 1 indicates Input 2, ZERO maintains a consistent value for the message output.
		}

		#endregion IO

		#region Math

		private static double Lerp(double t, double v0, double v1)
		{
			return (1 - t) * v0 + t * v1;
		}

		private static double Clamp(double val, double min, double max)
		{
			if (val < min)
				val = min;
			if (val > max)
				val = max;

			return val;
		}

		/// <summary> Convert voltage after the DAC + op amp to bytes </summary>
		/// <param name="voltage"> </param>
		/// <returns> </returns>
		private static double AmpVoltToByte(double voltage)
			=> RangeMap(voltage, 0, 15.0, 0, 255.0);

		private static double RangeMap(double x, double xmin, double xmax, double ymin, double ymax)
			=> (x - xmin) / (xmax - xmin) * (ymax - ymin) + ymin;

		public static byte ReverseBitsWith4Operations(byte b)
			=> (byte)(((b * 0x80200802ul) & 0x0884422110ul) * 0x0101010101ul >> 32);

		#endregion Math

		private void SendOutVoltage(double voltage)
		{
			Console.WriteLine("Votlage: {0}", voltage);
			voltage = Clamp(voltage, -15f, 15f); // clamp voltage
			Console.WriteLine("Clamped: {0}", voltage);
			double dutyVal = (voltage + 15) / 30; // Convert to 01 duty value
			SendDuty01(dutyVal);
		}

		private const double RAMP_MIN = 2.24;
		private const double RAMP_MAX = 12.2;

		private static double DutyByteMin => AmpVoltToByte(RAMP_MIN);
		private static double DutyByteMax => AmpVoltToByte(RAMP_MAX);

		private void SendDuty01(double dutyCycle)
		{
			dutyCycle = Clamp(dutyCycle, 0.0, 1.0); // clamp
			Console.WriteLine("Duty: {0}%", dutyCycle * 100);
			byte byteVal = (byte)RangeMap(dutyCycle, 0, 1, DutyByteMin, DutyByteMax);
			Console.WriteLine("Expected Voltage After Amp: {0}", RangeMap(dutyCycle, 0, 1, RAMP_MIN, RAMP_MAX));
			//byte byteVal = (byte)Lerp(dutyCycle, 0, 255); // Convert to byte
			Console.WriteLine("Byte: {0}", byteVal);
			byte reversed = ReverseBitsWith4Operations(byteVal); // Reverse to fix wiring problems
			Console.WriteLine("Reversed Byte: {0}", reversed);

			SendIO(2, reversed);
		}

		private void GetIOtimer_Tick(object sender, EventArgs e) //It is best to continuously check for incoming data as handling the buffer or waiting for event is not practical in C#.
		{
			if (serial.IsOpen) //Check that a serial connection exists.
			{
				if (serial.BytesToRead >= 4) //Check that the buffer contains a full four byte package.
				{
					//statusBox.Text = "Incoming"; // A status box can be used for debugging code.
					Inputs[0] = (byte)serial.ReadByte(); //Read the first byte of the package.

					if (Inputs[0] == START) //Check that the first byte is in fact the start byte.
					{
						//statusBox.Text = "Start Accepted";

						//Read the rest of the package.
						Inputs[1] = (byte)serial.ReadByte();
						Inputs[2] = (byte)serial.ReadByte();
						Inputs[3] = (byte)serial.ReadByte();

						//Calculate the checksum.
						byte checkSum = (byte)(Inputs[0] + Inputs[1] + Inputs[2]);

						//Check that the calculated check sum matches the checksum sent with the message.
						if (Inputs[3] == checkSum)
						{
							//statusBox.Text = "CheckSum Accepted";

							//Check which port the incoming data is associated with.
							switch (Inputs[1])
							{
								case 0: //Save the data to a variable and place in the textbox.
										//statusBox.Text = "Input1";
									Input1 = Inputs[2];
									InputBox1.Text = Input1.ToString();
									break;

								case 1: //Save the data to a variable and place in the textbox.
										//statusBox.Text = "Input2";
									Input2 = Inputs[2];
									InputBox2.Text = Input2.ToString();
									break;
							}
						}
					}
				}
			}

			switch (measureState)
			{
				case AutoMeasureState.Idle:
					break;

				case AutoMeasureState.AwaitingChange:
					if (waitCounts >= changeWaitCount)
					{
						byte currentSendByte = sendBytes[currentByte];
						currentSendByte = ReverseBitsWith4Operations(currentSendByte);
						SendIO(2, currentSendByte);
						waitCounts = 0;
						measureState = AutoMeasureState.AwaitingMeasureRequest;
					}
					else
					{
						waitCounts++;
					}
					break;

				case AutoMeasureState.AwaitingMeasureRequest:
					if (waitCounts >= requestWaitCount)
					{
						SendIO(0, ZERO);
						waitCounts = 0;
						measureState = AutoMeasureState.AwaitingMeasure;
					}
					else
					{
						waitCounts++;
					}
					break;

				case AutoMeasureState.AwaitingMeasure:
					if (waitCounts >= measureWaitCount)
					{
						Console.WriteLine("{0}, {1},", sendBytes[currentByte], Input1);

						waitCounts = 0;
						currentByte++;
						if (currentByte >= sendBytes.Length)
						{
							measureState = AutoMeasureState.Idle;
						}
						else
						{
							measureState = AutoMeasureState.AwaitingChange;
						}
					}
					else
					{
						waitCounts++;
					}
					break;
			}
		}

		private IEnumerable<byte> SendBytesGen
		{
			get
			{
				for (double volt = 0.0; volt <= 15.0; volt += 0.2)
				{
					yield return (byte)AmpVoltToByte(volt);
				}
			}
		}

		private AutoMeasureState measureState = AutoMeasureState.Idle;
		private byte[] sendBytes;
		private int currentByte;

		private enum AutoMeasureState
		{
			Idle,
			AwaitingChange,
			AwaitingMeasureRequest,
			AwaitingMeasure,
		}

		private int waitCounts = 0;
		private const int changeWaitCount = 1;
		private const int requestWaitCount = 1;
		private const int measureWaitCount = 5;

		private void RunAutoMeasure()
		{
			sendBytes = SendBytesGen.ToArray();
			measureState = AutoMeasureState.AwaitingChange;
			waitCounts = 0;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			RunAutoMeasure();
		}
	}
}