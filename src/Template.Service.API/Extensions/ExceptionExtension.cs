using Template.Service.API.Exceptions;

namespace Template.Service.API.Extensions
{
	/// <summary>
	/// Методы расширения для обработки исключений
	/// </summary>
	public static class ExceptionExtension
	{
		/// <summary>
		/// Использование прослойки обработки исключений
		/// </summary>
		/// <param name="builder"><see cref="IApplicationBuilder"/></param>
		/// <returns><see cref="IApplicationBuilder"/></returns>
		public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<ExceptionMiddleware>();
		}
	}
}
