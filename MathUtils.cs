using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialGUISample
{
	internal static class MathUtils
	{
		public const byte START = 255;
		public const byte ZERO = 0;

		public const float Vref = 15;

		public static double InvLerp(double t, double min, double max)
		{
			return (t - min) / (max - min);
		}

		public static double Lerp(double t, double min, double max)
		{
			return (1 - t) * min + t * max;
		}

		public static double Clamp(double val, double min, double max)
		{
			if (val < min)
				val = min;
			if (val > max)
				val = max;

			return val;
		}

		public static double RangeMap(double x, double xmin, double xmax, double ymin, double ymax)
		{
			if (xmin == 0.0 && xmax == 1.0)
				return Lerp(x, ymin, ymax);
			if (ymin == 0.0 && ymax == 1.0)
				return InvLerp(x, xmin, xmax);
			return (x - xmin) / (xmax - xmin) * (ymax - ymin) + ymin;
		}

		/// <summary> Convert voltage after the DAC + op amp to bytes </summary>
		/// <param name="voltage"> </param>
		/// <returns> </returns>
		public static double AmpVoltToByte(double voltage)
			=> MathUtils.RangeMap(voltage, 0, 15.0, 0, 255.0);

		public static byte ReverseBitsWith4Operations(byte b)
			=> (byte)(((b * 0x80200802ul) & 0x0884422110ul) * 0x0101010101ul >> 32);
	}
}