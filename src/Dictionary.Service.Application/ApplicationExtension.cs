using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Service.Application
{
	/// <summary>
	/// Методы расширешения уроdня Application
	/// </summary>
	public static class ApplicationExtension
	{
		/// <summary>
		/// Добавление поддержки Mediatr для текущего проекта
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		public static IServiceCollection AddMediatrExtension(this IServiceCollection services)
		{
			_ = services.AddMediatR(conf =>
				conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

			return services;
		}
	}
}
