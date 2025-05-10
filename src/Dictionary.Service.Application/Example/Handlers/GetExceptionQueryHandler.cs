using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Dictionary.Service.Application.V10.Example.Queries;
using AArkhipenko.Core.Logging;
using AArkhipenko.Core.Exceptions;

namespace Dictionary.Service.Application.V10.Example.Hadlers
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
		public GetExceptionQueryHandler(ILogger<GetExceptionQueryHandler> logger)
			: base(logger) { }

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
