using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;

namespace SerialGUISample.Hardware
{
	public class BoardComms
	{
		public byte[] SendPorts { get; } = new byte[2] { 2, 3 };
		public byte[] ReadPorts { get; } = new byte[2] { 0, 1 };

		private IEnumerable<byte> AllPorts
			=> SendPorts.Concat(ReadPorts);

		private readonly byte?[] recievedData = new byte?[2];
		private IReadOnlyList<byte?> RecievedData => recievedData;

		private bool TryGetSendPortIndex(byte port, out byte index)
		{
			int indexInt = SendPorts.GetIndex(port);
			if (indexInt < 0 || indexInt > byte.MaxValue)
			{
				index = default;
				return false;
			}

			index = (byte)indexInt;
			return true;
		}

		private bool TryGetReadPortIndex(byte port, out byte index)
		{
			int indexInt = ReadPorts.GetIndex(port);
			if (indexInt < 0 || indexInt > byte.MaxValue)
			{
				index = default;
				return false;
			}

			index = (byte)indexInt;
			return true;
		}

		private void SetReadByPort(byte port, byte value, out byte index)
		{
			if (TryGetReadPortIndex(port, out index))
				recievedData[index] = value;
			else
				Log(LogLevel.WARN, "Invalid recieve port {0}.", port);
		}

		public bool IsUsedPort(byte port)
			=> AllPorts.Contains(port);

		protected SerialPort Serial { get; }
		protected LogDelegate Log { get; }

		public BoardComms(bool runSerial, SerialPort serial, LogDelegate log)
		{
			Log = log;
			Serial = serial;
			Serial.ReceivedBytesThreshold = 4;
			Serial.DataReceived += OnSerialRecieve;

			if (runSerial)
				TryStartSerial();
		}

		public void TryStartSerial()
		{
			if (!Serial.IsOpen)                                  // Check if the serial has been connected.
			{
				try
				{
					Serial.Open();                               //Try to connect to the serial.
				}
				catch
				{
					Log(LogLevel.ERROR, "Failed to connect.");     //If the serial does not connect return an error.
				}
			}
		}

		public void Send(byte sendIndex, byte data)
		{
			byte port = SendPorts[sendIndex];
			Debug.Assert(IsUsedPort(port));
			SerialSend(port, data);
		}

		public void RequestRead(byte readIndex)
		{
			byte port = ReadPorts[readIndex];
			Debug.Assert(IsUsedPort(port));
			SerialSend(port, 0);
		}

		// Send a four byte message to the Arduino via serial.
		protected byte[] Outputs { get; } = new byte[4];

		private void SerialSend(byte port, byte data)
		{
			Outputs[0] = MathUtils.START;    //Set the first byte to the start value that indicates the beginning of the message.
			Outputs[1] = port;     //Set the second byte to represent the port where, Input 1 = 0, Input 2 = 1, Output 1 = 2 & Output 2 = 3. This could be enumerated to make writing code simpler... (see Arduino driver)
			Outputs[2] = data;  //Set the third byte to the value to be assigned to the port. This is only necessary for outputs, however it is best to assign a consistent value such as 0 for input ports.
			Outputs[3] = (byte)(MathUtils.START + port + data); //Calculate the checksum byte, the same calculation is performed on the Arduino side to confirm the message was received correctly.

			if (Serial.IsOpen)
			{
				Serial.Write(Outputs, 0, 4);         //Send all four bytes to the IO card.
			}
		}

		public void SendOutVoltage(byte sendIndex, double voltage)
		{
			Console.WriteLine("Votlage: {0}", voltage);
			voltage = MathUtils.Clamp(voltage, -15f, 15f); // clamp voltage
			Console.WriteLine("Clamped: {0}", voltage);
			double dutyVal = (voltage + 15) / 30; // Convert to 01 duty value
			SendDutyFactor(sendIndex, dutyVal);
		}

		private const double RAMP_MIN = 2.76;
		private const double RAMP_MAX = 12;

		private static double DutyByteMin => MathUtils.AmpVoltToByte(RAMP_MIN);
		private static double DutyByteMax => MathUtils.AmpVoltToByte(RAMP_MAX);

		/// <summary> Sets the motor speed based on duty cycle </summary>
		/// <param name="Port"> Port to set. </param>
		/// <param name="dutyCycle"> Factor is between 0 and 1 inclusive. </param>
		public void SendDutyFactor(byte sendIndex, double dutyCycle)
		{
			Debug.Assert(dutyCycle >= 0.0 && dutyCycle <= 1.0);

			dutyCycle = MathUtils.Clamp(dutyCycle, 0.0, 1.0); // clamp
			Log(LogLevel.VERBOSE, "Duty: {0}%", dutyCycle * 100);
			byte byteVal = (byte)MathUtils.RangeMap(dutyCycle, 0, 1, DutyByteMin, DutyByteMax);
			Log(LogLevel.VERBOSE, "Expected Voltage After Amp: {0}", MathUtils.RangeMap(dutyCycle, 0, 1, RAMP_MIN, RAMP_MAX));
			Log(LogLevel.VERBOSE, "Byte: {0}", byteVal);
			byte reversed = MathUtils.ReverseBits(byteVal); // Reverse to fix wiring direction
			Log(LogLevel.VERBOSE, "Reversed Byte: {0}", reversed);

			Send(sendIndex, reversed);
		}

		private void OnSerialRecieve(object sender, SerialDataReceivedEventArgs e)
		{
			Debug.Assert(Serial.IsOpen);
			Debug.Assert(Serial.BytesToRead >= 4);
			int maxUpdates = 4;
			while (Serial.BytesToRead >= 4 && maxUpdates > 0)
			{
				maxUpdates--;
				(byte, byte)? read = SerialRead();
				if (read.HasValue)
				{
					(byte port, byte value) = read.Value;
					SetReadByPort(port, value, out byte index);
					OnSerialRead(port, value);
					//polledUpdates.Add((index, value));
				}
			}
		}

		public delegate void SerialReadDelegate(byte readIndex, byte value);

		public event SerialReadDelegate OnSerialRead = delegate
		{
		};

		private (byte port, byte value)? SerialRead()
		{
			if (Serial.IsOpen)
			{
				byte startByte = (byte)Serial.ReadByte(); //Read the first byte of the package.

				if (startByte == MathUtils.START) //Check that the first byte is in fact the start byte.
				{
					//statusBox.Text = "Start Accepted";

					//Read the rest of the package.
					byte portByte = (byte)Serial.ReadByte();
					byte dataByte = (byte)Serial.ReadByte();
					byte checksumByte = (byte)Serial.ReadByte();

					//Calculate the checksum.
					byte checkSum = (byte)(startByte + portByte + dataByte);

					//Check that the calculated check sum matches the checksum sent with the message.
					if (checksumByte == checkSum)
					{
						Log(LogLevel.VERBOSE, "Serial Read. " +
							"Start: {0}, Port: {1}, Data: {2}, Checksum: {3}, Calculated Checksum: {4}",
							startByte, portByte, dataByte, checksumByte, checkSum);
						return (portByte, dataByte);
					}

					Log(LogLevel.WARN, "Invalid serial read. Checksum didn't match");
				}

				Log(LogLevel.WARN, "startByte was {0} instead of the start byte.", startByte);
			}

			return (default, default);
		}
	}
}