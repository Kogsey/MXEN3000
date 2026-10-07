using System;

namespace SerialGUISample.Hardware
{
	public class Sensor
	{
		private readonly BoardComms Comms;
		private readonly LogDelegate Log;

		public byte TrigOn { get; set; } = 128;
		public byte TrigOff { get; set; } = 64;

		public bool IsOn { get; private set; }

		public byte ReadIndex { get; private set; }

		private bool awaiting = false;
		private readonly TimeSpan updateTime = TimeSpan.FromMilliseconds(20);
		private readonly TimeSpan resendTimeout = TimeSpan.FromMilliseconds(100);
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
			RequestTimer();
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

		public void TriggerCheck(byte value)
		{
			//Log(LogLevel.VERBOSE, "Sensor {0} parsing: {1}", this, value);
			if (value < TrigOff && IsOn)
			{
				IsOn = false;
				//Log(LogLevel.VERBOSE, "Sensor state changed to: {0}", IsOn);
			}

			if (value > TrigOn && !IsOn)
			{
				IsOn = true;
				//Log(LogLevel.VERBOSE, "Sensor state changed to: {0}", IsOn);
			}
		}

		private void UpdateMe(byte index, byte value)
		{
			if (ReadIndex == index)
			{
				TriggerCheck(value);
				awaiting = false;
				lastResult = DateTime.Now;
			}
		}

		public override string ToString()
			=> string.Format("{{ On: {0}, Off: {1}, IsTrig: {2} }}", TrigOn, TrigOff, IsOn);
	}
}