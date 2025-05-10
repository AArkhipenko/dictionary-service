using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Template.Service.Domain.Core.Logging
{
	/// <summary>
	/// Реализация <see cref="ILoggerWrapper" />
	/// </summary>
    public class LoggerWrapper: ILoggerWrapper
	{
		private readonly ILogger _logger;
		private readonly IHttpContextAccessor _contextAccessor;

		/// <summary>
		/// Initializes a new instance of the <see cref="LoggerWrapper"/> class.
		/// </summary>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		/// <exception cref="ArgumentNullException">не задан входной параметр</exception>
		public LoggerWrapper(
			ILogger logger,
			IHttpContextAccessor contextAccessor)
		{
			this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
			this._contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
		}

		/// <inheritdoc/>
		public ILogger Logger { get => this._logger; }

		/// <inheritdoc/>
		public LoggerWrapperScope BeginLoggingScope([CallerMemberName] string? callerMethodName = null, string? callerClassName = null)
		{
			var isSuccess = this._contextAccessor.HttpContext.Request.Headers.TryGetValue(Consts.RequestIdKey, out var requestId);
			var scopeModel = new ScopeModel
			{
				RequestId = isSuccess ? Guid.Parse(requestId) : Guid.Empty,
				ClassName = callerClassName ?? this.GetType().Name,
				MethodName = callerMethodName ?? "unknown",
			};

			return new LoggerWrapperScope(this._logger, scopeModel);
		}
	}
}
