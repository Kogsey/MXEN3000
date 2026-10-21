using System;

namespace SerialGUISample.Hardware
{
	public class Sensor
	{
		private readonly BoardComms Comms;
		private readonly LogDelegate Log;

		public byte Trig { get; set; } = 240;
		//public byte TrigLow { get; set; } = 240;

		public bool IsHigh
		{
			get => BoardComms.recievedData[ReadIndex].HasValue ? TriggerCheck(BoardComms.recievedData[ReadIndex].Value) : false;
			set { }
		}

		public byte ReadIndex { get; private set; }

		private bool awaiting = false;
		private readonly TimeSpan updateTime = TimeSpan.FromMilliseconds(100);
		private readonly TimeSpan resendTimeout = TimeSpan.FromMilliseconds(500);
		private DateTime lastResult = DateTime.Now;

		public Sensor(BoardComms comms, LogDelegate log, byte readIndex)
		{
			Log = log;
			ReadIndex = readIndex;
			Comms = comms;
			Comms.OnSerialRead += UpdateMe;
		}

		public void Update()
		{
			//RequestTimer();
			TimeSpan sinceLastResult = (DateTime.Now - lastResult);
			Comms.RequestRead(ReadIndex);

			if (BoardComms.recievedData[ReadIndex].HasValue)
				UpdateMe(ReadIndex, BoardComms.recievedData[ReadIndex].Value);
		}

		private void RequestTimer()
		{
			TimeSpan sinceLastResult = (DateTime.Now - lastResult);
			if (!awaiting && sinceLastResult >= updateTime)
			{
				Comms.RequestRead(ReadIndex);
				awaiting = true;
			}
			else if (awaiting && sinceLastResult >= resendTimeout)
			{
				lastResult = DateTime.Now;
				Comms.RequestRead(ReadIndex);
				Log(LogLevel.WARN, "Resend timeout hit. {0}", sinceLastResult);
			}
		}

		private void UpdateMe(byte readIndex, byte value)
		{
			if (ReadIndex == readIndex)
			{
				TriggerCheck(value);
				awaiting = false;
				lastResult = DateTime.Now;
			}
		}

		public bool TriggerCheck(byte value)
		{
			bool val = false;
			if (value < Trig)
				val = false;
			if (value > Trig)
				val = true;

			return val;
		}

		public override string ToString()
			=> string.Format("{{ On: {0}, Off: {1}, IsTrig: {2} }}", Trig, IsHigh);
	}
}