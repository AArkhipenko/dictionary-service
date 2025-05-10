using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Template.Service.Application.V10.Example.Queries;
using Template.Service.Domain.Core.Logging;

namespace Template.Service.Application.V10.Example.Hadlers
{
	/// <summary>
	/// Выполнение <see cref="GetRandomQuery"/>
	/// </summary>
	internal class GetRandomQueryHandler: LoggerWrapper, IRequestHandler<GetRandomQuery, IEnumerable<int>>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GetRandomQueryHandler"/> class.
		/// </summary>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		public GetRandomQueryHandler(
			ILogger<GetRandomQueryHandler> logger,
			IHttpContextAccessor contextAccessor)
			: base(logger, contextAccessor) { }

		/// <inheritdoc/>
		public Task<IEnumerable<int>> Handle(GetRandomQuery request, CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				var result = Enumerable.Range(1, 5)
					.Select(index => Random.Shared.Next(-20, 55))
					.ToList();
				return Task.FromResult(result.AsEnumerable());
			}
		}
	}
}
