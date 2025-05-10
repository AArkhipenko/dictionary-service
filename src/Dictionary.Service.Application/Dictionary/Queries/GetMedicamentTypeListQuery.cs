using Dictionary.Service.Domain.Models;
using MediatR;

namespace Dictionary.Service.Application.Dictionary.Queries
{
	/// <summary>
	/// Запрос на получение списка лекарственных средств
	/// </summary>
    public class GetMedicamentTypeListQuery: IRequest<IEnumerable<Element>>
    {
    }
}
