using SerialGUISample.Hardware;
using System;

namespace SerialGUISample
{
	public class LineFollowController : Controller
	{
		public Sensor LeftSense { get; }
		public Sensor RightSense { get; }
		public PIDUtil PID { get; } = new PIDUtil();

		public LineFollowController(BoardComms commsUtil, LogDelegate log) : base(commsUtil, log)
		{
			LeftSense = new Sensor(commsUtil, log, 0);
			RightSense = new Sensor(commsUtil, log, 1);
		}

		public override double DirectionToDuty(double direction)
			=> base.DirectionToDuty(MathUtils.RangeMap(direction, -1.0, 1.0, -1, 1));

		public bool PIDUsesSpeed;
		public bool PIDOnlySlows;
		public double CurrentError;
		public double timeMultiplier = 0.01f;
		public double BaseSpeed = 0;
		public double MaxPIDAdjust = 0.5f;

		private DateTime lastTimeUpdate = DateTime.Now;
		private readonly int discardMaxMillis = 200;

		public override void SetStarted()
		{
			base.SetStarted();
			lastTimeUpdate = DateTime.Now;
		}

		public override void Update()
		{
			base.Update();
			LeftSense.Update();
			RightSense.Update();

			bool leftOn = LeftSense.IsHigh;
			bool rightOn = RightSense.IsHigh;
			DateTime now = DateTime.Now;
			TimeSpan diff = now - lastTimeUpdate;
			//lastTimeUpdate = now;

			if (diff.Milliseconds > discardMaxMillis)
				return;

			if (lastTimeUpdate == null)
				lastTimeUpdate = DateTime.Now;

			if (leftOn && !rightOn)
				CurrentError -= timeMultiplier * diff.Seconds;
			if (!leftOn && rightOn)
				CurrentError += timeMultiplier * diff.Seconds;
			else
				lastTimeUpdate = now;

			double pid = PIDUsesSpeed ? PID.CalcPID(CurrentError, BaseSpeed) : PID.CalcPID(CurrentError);
			pid = MathUtils.Clamp(pid, -MaxPIDAdjust, MaxPIDAdjust);

			double left = BaseSpeed - pid;
			double right = BaseSpeed + pid;
			if (PIDOnlySlows)
			{
				if (left > BaseSpeed)
					left = BaseSpeed;
				if (right > BaseSpeed)
					right = BaseSpeed;
			}

			SetTreads(left, right);
		}
	}
}