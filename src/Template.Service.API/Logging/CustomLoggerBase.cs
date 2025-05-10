using MediatR.NotificationPublishers;
using Newtonsoft.Json;
using System;
using Template.Service.Domain.Core.Logging;

namespace Template.Service.API.Logging
{
	/// <summary>
	/// База класс кастомного логера
	/// </summary>
	internal abstract class CustomLoggerBase : ILogger, IDisposable
	{
		private ScopeModel? _scopeModel = null;
		private readonly Formatting _jsonFormatting;

		/// <summary>
		/// Initializes a new instance of the <see cref="CustomLoggerBase"/> class.
		/// </summary>
		/// <param name="jsonFormatting"><see cref="Formatting"/></param>
		public CustomLoggerBase(Formatting jsonFormatting)
		{
			this._jsonFormatting = jsonFormatting;
		}

		/// <inheritdoc/>
		public bool IsEnabled(LogLevel logLevel) => true;

		/// <inheritdoc/>
		public IDisposable BeginScope<TState>(TState scopeModel)
		{
			if (scopeModel is not null && scopeModel is ScopeModel)
			{
				this._scopeModel = scopeModel as ScopeModel;
			}
			return this;
		}

		/// <inheritdoc/>
		public abstract void Log<TState>(
			LogLevel logLevel,
			EventId eventId,
			TState state,
			Exception? exception,
			Func<TState, Exception?, string> formatter);

		/// <inheritdoc/>
		public void Dispose() { }

		/// <summary>
		/// Формирование отформатированного сообщения для лога
		/// </summary>
		/// <param name="logLevel">уровень логирования</param>
		/// <param name="message">сообщение для лога</param>
		/// <param name="exception">выброшенное исключение</param>
		/// <returns>строка json</returns>
		protected string FormatMessage(LogLevel logLevel, string message, Exception? exception)
		{
			var logEntry = new LogEntry
			{
				Timestamp = DateTime.UtcNow,
				LogLevel = logLevel.ToString(),
				RequestId = this._scopeModel is null ? Guid.Empty : this._scopeModel.RequestId,
				Scope = this._scopeModel is null ? "unknown" : $"{this._scopeModel.ClassName}.{this._scopeModel.MethodName}",
				Message = message,
				Exception = exception?.ToString()
			};

			return JsonConvert.SerializeObject(logEntry, this._jsonFormatting);
		}

		private class LogEntry
		{
			/// <summary>
			/// Временная метка
			/// </summary>
			public DateTime Timestamp { get; set; }

			/// <summary>
			/// ID запроса (нужен для отслеживания последовательности вызовов)
			/// </summary>
			public Guid RequestId { get; set; }

			/// <summary>
			/// Уровень логирования
			/// </summary>
			public string LogLevel { get; set; } = string.Empty;

			/// <summary>
			/// Раздел логирования
			/// </summary>
			public string Scope { get; set; } = string.Empty;

			/// <summary>
			/// Сообщение для лога
			/// </summary>
			public string Message { get; set; } = string.Empty;

			/// <summary>
			/// Сообщение исключения
			/// </summary>
			public string? Exception { get; set; }
		}
	}
}
