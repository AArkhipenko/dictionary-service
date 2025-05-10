using Dictionary.Service.Domain.Models;
using MediatR;

namespace Dictionary.Service.Application.Dictionary.V10.Queries
{
	/// <summary>
	/// Запрос на получение списка пользовательского представления времени суток
	/// </summary>
	public class GetDayTimeTypeListQuery : IRequest<List<Element>>
    {
    }
}
