using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using Template.Service.Domain.Core.Logging;

namespace Template.Service.API.Controllers
{
	/// <summary>
	/// Базовый контроллер для всех контроллеров
	/// Реализует <see cref="ILoggerWrapper"/>
	/// </summary>
	public abstract class ApiBaseController : ControllerBase, ILoggerWrapper
    {
        private readonly LoggerWrapper _loggerWrapper;

		/// <summary>
		/// Initializes a new instance of the <see cref="ApiBaseController"/> class.
		/// </summary>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		public ApiBaseController(
			ILogger logger,
			IHttpContextAccessor contextAccessor)
        {
            this._loggerWrapper = new LoggerWrapper(logger, contextAccessor);
        }

        /// <inheritdoc />
        public ILogger Logger { get => this._loggerWrapper.Logger; }

		/// <inheritdoc />
		[ApiExplorerSettings(IgnoreApi = true)]
		public LoggerWrapperScope BeginLoggingScope([CallerMemberName] string? myCallerName = null, string? callerClassName = null)
            => this._loggerWrapper.BeginLoggingScope(myCallerName, callerClassName ?? this.GetType().Name);
    }
}
