using Newtonsoft.Json;

namespace Template.Service.API.Logging
{
	/// <summary>
	/// Логер для записи в файл
	/// </summary>
	internal class FileLogger : CustomLoggerBase
	{
		private readonly string _filePath;
		static object _lock = new object();

		/// <summary>
		/// Initializes a new instance of the <see cref="FileLogger"/> class.
		/// </summary>
		/// <param name="filePath">путь к файлу для записи лога</param>
		public FileLogger(string filePath)
			: base (Formatting.None)
		{
			this._filePath = filePath;
		}

		/// <inheritdoc/>
		public override void Log<TState>(
			LogLevel logLevel,
			EventId eventId,
			TState state,
			Exception? exception,
			Func<TState, Exception?, string> formatter)
		{
			var text = base.FormatMessage(logLevel, formatter(state, exception), exception);
			lock (_lock)
			{
				File.AppendAllText(this._filePath, text + Environment.NewLine);
			}
		}
	}
}
