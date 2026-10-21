using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialGUISample
{
	public class PIDUtil
	{
		public double P { get; private set; }
		public double I { get; private set; }
		public double D { get; private set; }

		public double Kp { get; set; }
		public double Ki { get; set; }
		public double Kd { get; set; }

		private double LastError { get; set; }

		public double CalcPID(double error, double speedMult = 1f)
		{
			P = error;
			I = I + error;
			D = error - LastError;

			double result = (Kp * P + Ki * I + Kd * D) * speedMult;
			LastError = error;
			return result;
		}
	}
}