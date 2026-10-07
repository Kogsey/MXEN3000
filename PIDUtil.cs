using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialGUISample
{
	public class PIDUtil
	{
		public float P { get; private set; }
		public float I { get; private set; }
		public float D { get; private set; }

		public float Kp { get; set; }
		public float Ki { get; set; }
		public float Kd { get; set; }

		private float LastError { get; set; }

		public float CalcPID(float error)
		{
			P = error;
			I = I + error;
			D = error - LastError;

			float result = Kp * P + Ki * I + Kd * D;
			LastError = error;
			return result;
		}
	}
}