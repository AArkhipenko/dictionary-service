using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Template.Service.Application.V10.Example.Queries;
using Template.Service.Domain.Core.Exceptions;
using Template.Service.Domain.Core.Logging;

namespace Template.Service.Application.V10.Example.Hadlers
{
	/// <summary>
	/// Выполнение <see cref="GetExceptionQuery"/>
	/// </summary>
	internal class GetExceptionQueryHandler : LoggerWrapper, IRequestHandler<GetExceptionQuery, Unit>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GetExceptionQueryHandler"/> class.
		/// </summary>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		public GetExceptionQueryHandler(
			ILogger<GetExceptionQueryHandler> logger,
			IHttpContextAccessor contextAccessor)
			: base(logger, contextAccessor) { }

		/// <inheritdoc/>
		public Task<Unit> Handle(GetExceptionQuery request, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				throw new BadRequestException("Проверка обработки исключений");
				return Task.FromResult(Unit.Value);
			}
		}
	}
}
