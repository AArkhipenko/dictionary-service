using AArkhipenko.Core.Logging;
using Dictionary.Service.Application.Dictionary.V10.Queries;
using Dictionary.Service.Domain.Models;
using Dictionary.Service.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dictionary.Service.Application.Dictionary.V10.Handlers
{
	/// <summary>
	/// Выполнение запроса <see cref="GetDayTimeTypeListQuery"/>
	/// </summary>
	internal class GetDayTimeTypeListHandler : LoggerWrapper, IRequestHandler<GetDayTimeTypeListQuery, List<Element>>
	{
		private readonly IElementRepository _objectRepository;
		/// <summary>
		/// Initializes a new instance of the <see cref="GetDayTimeTypeListHandler"/> class.
		/// </summary>
		/// <param name="objectRepository"><see cref="IElementRepository"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		public GetDayTimeTypeListHandler(
			IElementRepository objectRepository,
			ILogger<GetDayTimeTypeListHandler> logger)
			: base(logger)
		{
			_objectRepository = objectRepository ?? throw new ArgumentNullException(nameof(objectRepository));
		}

		/// <inheritdoc/>
		public Task<List<Element>> Handle(GetDayTimeTypeListQuery request, CancellationToken cancellationToken)
		{
			using (_ = BeginLoggingScope())
			{
				return _objectRepository.GetDayTimeTypeList(cancellationToken);
			}
		}
	}
}
