namespace SerialGUISample
{
	public enum LogLevel
	{
		VERBOSE,
		INFO,
		WARN,
		ERROR,

		GUI,
	}

	public delegate void LogDelegate(LogLevel level, string format, params object[] arg);
}