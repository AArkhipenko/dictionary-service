using Asp.Versioning;

namespace Template.Service.API.Extensions
{
	/// <summary>
	/// Методы расширешения для версионирования АПИ
	/// </summary>
	public static class VersionExtension
	{
		/// <summary>
		/// Добавления настроект версионирования АПИ
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		public static IServiceCollection AddVersionExtension(this IServiceCollection services)
		{
			var apiVersioningBuilder = services.AddApiVersioning(o =>
			{
				o.AssumeDefaultVersionWhenUnspecified = true;
				o.DefaultApiVersion = new ApiVersion(1, 0);
				o.ReportApiVersions = true;
				// Версия указана в строку запроса
				o.ApiVersionReader = new UrlSegmentApiVersionReader();
			});
			apiVersioningBuilder.AddApiExplorer(options =>
			{
				options.GroupNameFormat = "'v'VVV";
				options.SubstituteApiVersionInUrl = true;
			});

			return services;
		}
	}
}
