using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialGUISample
{
	public enum LogLevel
	{
		VERBOSE,
		INFO,
		WARN,
		ERROR,

		REQUESTED,
	}

	public delegate void LogDelegate(LogLevel level, string format, params object[] arg);
}