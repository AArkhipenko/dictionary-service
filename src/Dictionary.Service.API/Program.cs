using AArkhipenko.Core;
using AArkhipenko.Logging;
using AArkhipenko.Swagger.Models;
using AArkhipenko.Swagger;
using Dictionary.Service.API.Extensions;
using Dictionary.Service.API.Settings;
using Dictionary.Service.Application.V10;
using System;
using Microsoft.OpenApi.Models;

namespace Dictionary.Service.API
{
	/// <summary>
	/// Входная точка запуска софта. Содержит основные настройки
	/// </summary>
	public class Program
	{
		private readonly static OpenApiInfo[] _versions = new[]
		{
			new OpenApiInfo
			{
				Version = "v10",
				Title = "Dictionary.Service API v1.0"
			}
		};

		/// <summary>
		/// Входная точка приложения
		/// </summary>
		/// <param name="args">список аргументов при запуске приложения</param>
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
			// Методы расширения из nuget-пакетов
			// AArkhipenko.Core
			builder.Services.AddCustomHealthCheck();
			builder.Services.AddVersioning();
			// AArkhipenko.Logging
			if (builder.Environment.IsDevelopment())
			{
				builder.Logging.AddConsoleLogging();
			}
			else
			{
				builder.Logging.AddFileLogging();
			}
			// AArkhipenko.Swagger
			builder.Services.AddCustomSwagger(_versions);

			// Методы расширения проектов
			// Добавление поддержки Mediatr для проекта Dictionary.Service.Application.V10
			builder.Services.AddMediatrV10Extension();
			// Добавление возможности работы с JWT
			builder.Services.AddAuthJwt(builder.Configuration);

			var app = builder.Build();

			// Методы расширения из nuget-пакетов
			// AArkhipenko.Core
			app.UseRequestChainMiddleware();
			app.UseExceptionMiddleware();
			app.UseCustomHealthCheck();
			// AArkhipenko.Logging
			app.UseLoggingMiddleware();
			// AArkhipenko.Swagger
			app.UseCustomSwagger(_versions);

			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}