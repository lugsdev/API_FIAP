
namespace PrimeiraAPI.Logging
{
	public class CustomLogger : ILogger
	{
		private readonly string _loggerName;
		private readonly CustomLoggerProviderConfiguration _loggerConfig;
		public static bool FileLog { get; set; } = false;

        public CustomLogger(string loggerName, CustomLoggerProviderConfiguration loggerConfig)
        {
            _loggerName = loggerName;
			_loggerConfig = loggerConfig;
        }
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
		{
			return null;
		}

		public bool IsEnabled(LogLevel logLevel)
		{
			return true;
		}

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
		{
			string message = $"Log de execução: {logLevel}: {eventId} - {formatter(state, exception)}";

			if (FileLog)
				WriteLogFile(message);
			else
				Console.WriteLine(message);
		}

		private void WriteLogFile(string message)
		{
			string pathFile = Environment.CurrentDirectory + $@"\LOG-{DateTime.Now:yyy-mm-dd}.txt";

			if (!File.Exists(pathFile))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(pathFile));
				File.Create(pathFile).Dispose();
			}

			using StreamWriter stream = new(pathFile, true);
			stream.WriteLine(message);
			stream.Close();
		}
	}
}
