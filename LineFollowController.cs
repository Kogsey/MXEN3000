using SerialGUISample.Hardware;
using System;
using System.Drawing.Text;

namespace SerialGUISample
{
	public class LineFollowController : Controller
	{
		public Sensor LeftSense { get; }
		public Sensor RightSense { get; }
		public PIDUtil PID { get; } = new PIDUtil();

		public LineFollowController(BoardComms commsUtil, LogDelegate log) : base(commsUtil, log)
		{
			LeftSense = new Sensor(commsUtil, log, 1);
			RightSense = new Sensor(commsUtil, log, 0);
		}

		public override double DirectionToDuty(double direction)
			=> base.DirectionToDuty(MathUtils.RangeMap(direction, -1.0, 1.0, -1, 1));

		public bool PIDUsesSpeed;
		public bool PIDOnlySlows;
		public double CurrentError;
		public double timeMultiplier = 0.001;
		public double BaseSpeed = 0;
		public double MaxPIDAdjust => BaseSpeed;
		public double MaxError = 1;

		private DateTime lastTimeUpdate = DateTime.Now;
		private readonly int discardMaxMillis = 200;

		public override void SetStarted()
		{
			base.SetStarted();
			lastTimeUpdate = DateTime.Now;
			CurrentError = 0;
		}

		public override void Update()
		{
			base.Update();
			LeftSense.Update();
			RightSense.Update();

			bool leftHigh = LeftSense.IsHigh;
			bool rightHigh = RightSense.IsHigh;
			DateTime now = DateTime.Now;
			TimeSpan diff = now - lastTimeUpdate;
			//lastTimeUpdate = now;

			//if (diff.Milliseconds > discardMaxMillis)
			//	return;

			bool BANGBANG = true;
			double slowSpeed = -BaseSpeed;
			if (BANGBANG)
			{
				if (leftHigh && !rightHigh)
					SetTreads(slowSpeed, BaseSpeed);
				else if (!leftHigh && rightHigh)
					SetTreads(BaseSpeed, slowSpeed);
				else if (!leftHigh && !rightHigh)
					SetTreads(0, 0);
				else
					SetTreads(BaseSpeed, BaseSpeed);
			}
			else
			{
				if (leftHigh && !rightHigh)
					CurrentError += timeMultiplier * diff.TotalMilliseconds;
				else if (!leftHigh && rightHigh)
					CurrentError -= timeMultiplier * diff.TotalMilliseconds;
				else if (!leftHigh && !rightHigh)
				{
					SetTreads(0, 0);
					lastTimeUpdate = now;
					return;
				}
				else
				{
					CurrentError = 0;
					lastTimeUpdate = now;
				}

				CurrentError = MathUtils.Clamp(CurrentError, -MaxError, MaxError);

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
}