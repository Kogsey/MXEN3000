using SerialGUISample.Hardware;

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

		public float CurrentError;
		public float errorAccumulateRate = 0.01f;
		public float Base = 0.5f;

		public override void Update()
		{
			base.Update();
			LeftSense.Update();
			RightSense.Update();

			bool leftOn = LeftSense.IsOn;

			if (LeftSense.IsOn && !RightSense.IsOn)
				CurrentError -= errorAccumulateRate;
			if (!LeftSense.IsOn && RightSense.IsOn)
				CurrentError += errorAccumulateRate;

			float pid = PID.CalcPID(CurrentError);

			SetTreads(Base - pid, Base + pid);
		}
	}
}