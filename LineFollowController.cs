using SerialGUISample.Hardware;

namespace SerialGUISample
{
	public class LineFollowController : Controller
	{
		public Sensor leftSense;
		public Sensor rightSense;

		public override bool ControlLockout => true;

		public LineFollowController(BoardComms commsUtil, LogDelegate log) : base(commsUtil, log)
		{
			leftSense = new Sensor(commsUtil, log, 0);
			rightSense = new Sensor(commsUtil, log, 1);
		}

		public override void Update()
		{
			base.Update();
			leftSense.Update();
			rightSense.Update();
		}
	}
}