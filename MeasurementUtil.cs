using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialGUISample
{
	internal enum AutoMeasureState
	{
		Idle,
		AwaitingChange,
		AwaitingMeasureRequest,
		AwaitingMeasure,
	}

	internal class MeasurementUtil
	{
		private const int changeWaitCount = 1;
		private const int requestWaitCount = 1;
		private const int measureWaitCount = 5;
		private readonly LogDelegate log;

		public MeasurementUtil(LogDelegate log)
		{
			this.log = log;
		}

		public void TickMeasure(ControlUtil controlUtil)
		{
			switch (measureState)
			{
				case AutoMeasureState.Idle:
					break;

				case AutoMeasureState.AwaitingChange:
					if (waitTimer >= changeWaitCount)
					{
						byte currentSendByte = sendBytes[currentByte];
						currentSendByte = MathUtils.ReverseBitsWith4Operations(currentSendByte);
						controlUtil.SendIO(sendPort, currentSendByte);
						waitTimer = 0;
						measureState = AutoMeasureState.AwaitingMeasureRequest;
					}
					else
					{
						waitTimer++;
					}
					break;

				case AutoMeasureState.AwaitingMeasureRequest:
					if (waitTimer >= requestWaitCount)
					{
						controlUtil.RequestSerialRecieve(recievePort);
						waitTimer = 0;
						measureState = AutoMeasureState.AwaitingMeasure;
					}
					else
					{
						waitTimer++;
					}
					break;

				case AutoMeasureState.AwaitingMeasure:
					if (waitTimer >= measureWaitCount)
					{
						waitTimer = 0;
						currentByte++;
						if (currentByte >= sendBytes.Length)
						{
							measureState = AutoMeasureState.Idle;
						}
						else
						{
							log(LogLevel.REQUESTED, "{0}, {1},", sendBytes[currentByte], controlUtil.GetRecieved(recievePort));
							measureState = AutoMeasureState.AwaitingChange;
						}
					}
					else
					{
						waitTimer++;
					}
					break;
			}
		}

		private AutoMeasureState measureState = AutoMeasureState.Idle;
		private byte[] sendBytes;
		private int currentByte;

		private int waitTimer = 0;
		private byte sendPort;
		private byte recievePort;

		public void RunAutoMeasure(IEnumerable<byte> sendBytesEnumerable, byte sendPort, byte recievePort)
		{
			sendBytes = sendBytesEnumerable.ToArray();
			measureState = AutoMeasureState.AwaitingChange;
			waitTimer = 0;
			this.sendPort = sendPort;
			this.recievePort = recievePort;
		}
	}
}