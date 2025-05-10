using AArkhipenko.Core.Logging;
using Dictionary.Service.Application.Dictionary.V10.Queries;
using Dictionary.Service.Domain.Models;
using Dictionary.Service.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Dictionary.Service.Application.Dictionary.V10.Handlers
{
	/// <summary>
	/// Выполнение запроса <see cref="GetMedicamentTypeListQuery"/>
	/// </summary>
	internal class GetMedicamentTypeListHandler : LoggerWrapper, IRequestHandler<GetMedicamentTypeListQuery, IEnumerable<Element>>
	{
		private readonly IElementRepository _objectRepository;
		/// <summary>
		/// Initializes a new instance of the <see cref="GetMedicamentTypeListHandler"/> class.
		/// </summary>
		/// <param name="objectRepository"><see cref="IElementRepository"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		public GetMedicamentTypeListHandler(
			IElementRepository objectRepository,
			ILogger<GetMedicamentTypeListHandler> logger)
			: base(logger)
		{
			_objectRepository = objectRepository ?? throw new ArgumentNullException(nameof(objectRepository));
		}

		/// <inheritdoc/>
		public Task<IEnumerable<Element>> Handle(GetMedicamentTypeListQuery request, CancellationToken cancellationToken)
		{
			using (_ = BeginLoggingScope())
			{
				return _objectRepository.GetMedicamentTypeList(cancellationToken);
			}
		}
	}
}
