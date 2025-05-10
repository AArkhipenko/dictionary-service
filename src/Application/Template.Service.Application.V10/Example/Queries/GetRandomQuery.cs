using MediatR;

namespace Template.Service.Application.V10.Example.Queries
{
	/// <summary>
	/// Запрос на получение списка случайных чисел
	/// </summary>
	public class GetRandomQuery : IRequest<IEnumerable<int>>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GetRandomQuery"/> class.
		/// </summary>
		public GetRandomQuery() { }
	}
}
