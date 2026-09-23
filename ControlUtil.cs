using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;

namespace SerialGUISample
{
	public class ControlUtil
	{
		public const byte PORT_SEND1 = 2;
		public const byte PORT_SEND2 = 3;

		public const byte PORT_RECIEVE1 = 0;
		public byte? Recieved1 { get; private set; } = 0;
		public const byte PORT_RECIEVE2 = 1;
		public byte? Recieved2 { get; private set; } = 0;

		public byte? GetRecieved(byte PORT)
		{
			switch (PORT)
			{
				case PORT_RECIEVE1:
					return Recieved1;

				case PORT_RECIEVE2:
					return Recieved2;
			}

			log(LogLevel.WARN, "Invalid recieve port {0}.", PORT);
			return default;
		}

		private IEnumerable<byte> AllPorts
		{
			get
			{
				yield return PORT_SEND1;
				yield return PORT_SEND2;
				yield return PORT_RECIEVE1;
				yield return PORT_RECIEVE2;
			}
		}

		private byte PORT_MIN => AllPorts.Min();
		private byte PORT_MAX => AllPorts.Max();

		private readonly SerialPort serial;
		private readonly LogDelegate log;

		public ControlUtil(bool runSerial, SerialPort serial, LogDelegate log)
		{
			this.log = log;
			this.serial = serial;

			if (runSerial == true)
			{
				if (!this.serial.IsOpen)                                  // Check if the serial has been connected.
				{
					try
					{
						this.serial.Open();                               //Try to connect to the serial.
					}
					catch
					{
						this.log(LogLevel.ERROR, "Failed to connect.");     //If the serial does not connect return an error.
					}
				}
			}
		}

		// Send a four byte message to the Arduino via serial.
		private readonly byte[] Outputs = new byte[4];

		public void SendIO(byte PORT, byte DATA)
		{
			Debug.Assert(PORT >= PORT_MIN && PORT <= PORT_MAX);

			Outputs[0] = MathUtils.START;    //Set the first byte to the start value that indicates the beginning of the message.
			Outputs[1] = PORT;     //Set the second byte to represent the port where, Input 1 = 0, Input 2 = 1, Output 1 = 2 & Output 2 = 3. This could be enumerated to make writing code simpler... (see Arduino driver)
			Outputs[2] = DATA;  //Set the third byte to the value to be assigned to the port. This is only necessary for outputs, however it is best to assign a consistent value such as 0 for input ports.
			Outputs[3] = (byte)(MathUtils.START + PORT + DATA); //Calculate the checksum byte, the same calculation is performed on the Arduino side to confirm the message was received correctly.

			if (serial.IsOpen)
			{
				serial.Write(Outputs, 0, 4);         //Send all four bytes to the IO card.
			}
		}

		public void SendOutVoltage(byte PORT, double voltage)
		{
			Console.WriteLine("Votlage: {0}", voltage);
			voltage = MathUtils.Clamp(voltage, -15f, 15f); // clamp voltage
			Console.WriteLine("Clamped: {0}", voltage);
			double dutyVal = (voltage + 15) / 30; // Convert to 01 duty value
			SendDutyFactor(PORT, dutyVal);
		}

		private const double RAMP_MIN = 2.24;
		private const double RAMP_MAX = 12.2;

		private static double DutyByteMin => MathUtils.AmpVoltToByte(RAMP_MIN);
		private static double DutyByteMax => MathUtils.AmpVoltToByte(RAMP_MAX);

		/// <summary> Sets the motor speed based on duty cycle </summary>
		/// <param name="PORT"> Port to set. </param>
		/// <param name="dutyCycle"> Factor is between 0 and 1 inclusive. </param>
		public void SendDutyFactor(byte PORT, double dutyCycle)
		{
			Debug.Assert(dutyCycle >= 0.0 && dutyCycle <= 1.0);

			dutyCycle = MathUtils.Clamp(dutyCycle, 0.0, 1.0); // clamp
			log(LogLevel.VERBOSE, "Duty: {0}%", dutyCycle * 100);
			byte byteVal = (byte)MathUtils.RangeMap(dutyCycle, 0, 1, DutyByteMin, DutyByteMax);
			log(LogLevel.VERBOSE, "Expected Voltage After Amp: {0}", MathUtils.RangeMap(dutyCycle, 0, 1, RAMP_MIN, RAMP_MAX));
			log(LogLevel.VERBOSE, "Byte: {0}", byteVal);
			byte reversed = MathUtils.ReverseBitsWith4Operations(byteVal); // Reverse to fix wiring problems
			log(LogLevel.VERBOSE, "Reversed Byte: {0}", reversed);

			SendIO(PORT, reversed);
		}

		public void RequestSerialRecieve(byte PORT)
			=> SendIO(PORT, MathUtils.ZERO);

		private readonly byte[] Inputs = new byte[4];

		public (byte PORT, byte result)? SerialRecieve()
		{
			if (serial.IsOpen) //Check that a serial connection exists.
			{
				if (serial.BytesToRead >= 4) //Check that the buffer contains a full four byte package.
				{
					//statusBox.Text = "Incoming"; // A status box can be used for debugging code.
					Inputs[0] = (byte)serial.ReadByte(); //Read the first byte of the package.

					if (Inputs[0] == MathUtils.START) //Check that the first byte is in fact the start byte.
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
								case PORT_RECIEVE1: //Save the data to a variable and place in the textbox.
													//statusBox.Text = "Input1";
									Recieved1 = Inputs[2];
									return (PORT_RECIEVE1, Inputs[2]);

								case PORT_RECIEVE2: //Save the data to a variable and place in the textbox.
													//statusBox.Text = "Input2";
									Recieved2 = Inputs[2];
									return (PORT_RECIEVE2, Inputs[2]);
							}
						}
					}
					else
					{
						log(LogLevel.WARN, "Inputs[0] was {0} instead of the start byte.", Inputs[0]);
					}
				}
			}

			return default;
		}
	}
}