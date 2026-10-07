using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialGUISample
{
	internal class PIDUtil
	{
		public float P { get; private set; }
		public float I { get; private set; }
		public float D { get; private set; }

		public float Kp { get; private set; }
		public float Ki { get; private set; }
		public float Kd { get; private set; }

		private float LastError { get; set; }

		public float UpdatePID(float error, float lastError)
		{
			P = error;
			I = I + error;
			D = error - lastError;

			float result = Kp * P + Ki * I + Kd * D;
			LastError = lastError;
			return result;
		}
	}
}