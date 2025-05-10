using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AArkhipenko.Keycloak;

namespace Dictionary.Service.Infrastructure
{
	/// <summary>
	/// Методы расширешения уровня Infrastructure
	/// </summary>
	public static class InfrastructureExtension
	{
		/// <summary>
		/// Добавление всех расширений с уровня Infrastructure
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <param name="configuration"><see cref="IConfiguration"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
			=> services
			.AddDbContext(configuration)
			.AddRepositories()
			.AddKeycloakAuth(configuration);

		/// <summary>
		/// Добавление контекста БД
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			return services;
		}

		/// <summary>
		/// Добавление репозиториев
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		private static IServiceCollection AddRepositories(this IServiceCollection services)
			=> services;
	}
}
