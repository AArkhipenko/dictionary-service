using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Dictionary.Service.Application.Example.Queries;
using AArkhipenko.Core.Logging;

namespace Dictionary.Service.Application.Example.Hadlers
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
		public GetRandomQueryHandler(ILogger<GetRandomQueryHandler> logger)
			: base(logger) { }

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
