using SerialGUISample.Hardware;
using System;

namespace SerialGUISample
{
	public class Controller
	{
		protected BoardComms CommsUtil { get; }
		protected LogDelegate Log { get; }
		private byte LeftSend => 0;
		private byte RightSend => 1;
		public virtual bool ControlLockout { get; protected set; } = false;
		public Controller(BoardComms commsUtil, LogDelegate log)
		{
			CommsUtil = commsUtil;
			Log = log;
		}

		#region Actual Control

		public virtual double DirectionToDuty(double direction)
		{
			double duty = MathUtils.RangeMap(direction, -1.0, 1.0, 0.0, 1.0);
			return MathUtils.Clamp(duty, 0.0, 1.0);
		}

		protected virtual void SetTread(byte sendIndex, double direction)
		{
			if (!ControlLockout)
			{
				Log(LogLevel.VERBOSE, "Passed direction to: {0} with value {1}", sendIndex, direction);
				double duty = DirectionToDuty(direction);
				CommsUtil.SendDutyFactor(sendIndex, duty);
				OnTreadSpeedChanged(sendIndex, direction);
			}
			else
			{
				Log(LogLevel.REQUESTED, "Controls locked. Ignoring command to send {0} to index {1}", direction, sendIndex);
			}
		}

		public event Action<byte, double> OnTreadSpeedChanged = delegate
		{ };
		public event Action<byte, byte> OnSensorReadChanged = delegate
		{ };

		/// <summary> Controls the motor for the left tread. </summary>
		/// <param name="direction"> A value between -1.0 and 1.0. -1.0 is backwards 1.0 is forwards. </param>
		public virtual void SetLeftTread(double direction)
			=> SetTread(LeftSend, direction);

		/// <summary> Controls the motor for the left tread. </summary>
		/// <param name="direction"> A value between -1.0 and 1.0. -1.0 is backwards 1.0 is forwards. </param>
		public virtual void SetRightTread(double direction)
			=> SetTread(RightSend, direction);

		public virtual void SetTreads(double leftDir, double rightDir)
		{
			SetLeftTread(leftDir);
			SetRightTread(rightDir);
		}

		public virtual void SetStopped()
			=> SetTreads(0, 0);

		/// <summary> </summary>
		/// <param name="turn"> A value between -1.0 and 1.0. -1.0 is left 1.0 is right. </param>
		public virtual void SetTurning(double turn)
		{
			SetTreads(turn, -turn);
		}

		#endregion Actual Control

		public virtual void Update()
		{
		}
	}
}