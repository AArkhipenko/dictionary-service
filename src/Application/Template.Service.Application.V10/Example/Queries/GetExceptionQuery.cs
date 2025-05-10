using MediatR;

namespace Template.Service.Application.V10.Example.Queries
{
	/// <summary>
	/// Запрос для проверки работы прослойки обработки исключений
	/// </summary>
	public class GetExceptionQuery : IRequest<Unit>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GetExceptionQuery"/> class.
		/// </summary>
		public GetExceptionQuery() { }
	}
}
