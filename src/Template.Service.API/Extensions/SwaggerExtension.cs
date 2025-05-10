using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace Template.Service.API.Extensions
{
	/// <summary>
	/// Методы расширения для использования Swagger
	/// </summary>
	public static class SwaggerExtension
	{
		/// <summary>
		/// Добавления настроек для работы с Swagger
		/// </summary>
		/// <param name="services"><see cref="IServiceCollection"/></param>
		/// <returns><see cref="IServiceCollection"/></returns>
		public static IServiceCollection AddSwaggerExtension(this IServiceCollection services)
		{
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v10", new OpenApiInfo
				{
					Version = "v10",
					Title = $"Template.Service API v1.0",
				});
				options.AddSecurityDefinition("BearerAuth", new OpenApiSecurityScheme()
				{
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					Scheme = JwtBearerDefaults.AuthenticationScheme,
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "JWT Authorization header \"Authorization: Bearer {token}\"",
				});
				options.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "BearerAuth"
							}
						},
						new string[] {}
					}
				});
			});

			return services;
		}

		/// <summary>
		/// Включение использования Swagger
		/// </summary>
		/// <param name="app"><see cref="IApplicationBuilder"/></param>
		/// <param name="isDevelopment">признак режима разработки</param>
		/// <returns><see cref="IApplicationBuilder"/></returns>
		public static IApplicationBuilder UseSwaggerExtension(this IApplicationBuilder app, bool isDevelopment)
		{
			if (isDevelopment)
			{
				app.UseSwagger();
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("v10/swagger.json", $"Template.Service API v1.0");
					c.SwaggerEndpoint("v11/swagger.json", $"Template.Service API v1.1");
				});
			}

			return app;
		}
	}
}
