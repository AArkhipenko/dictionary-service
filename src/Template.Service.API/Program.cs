using Template.Service.API.Extensions;
using Template.Service.API.Settings;
using Template.Service.Application.V10;

using DomainConsts = Template.Service.Domain.Core.Consts;

namespace Template.Service.API
{
	/// <summary>
	/// Входная точка запуска софта. Содержит основные настройки
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Входная точка приложения
		/// </summary>
		/// <param name="args">список аргументов при запуске приложения</param>
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Добавление поддержки Mediatr для проекта Template.Service.Application.V10
			builder.Services.AddMediatrV10Extension();
			// Add services to the container
			builder.Services.AddControllers();
			// Добавление версионирования
			builder.Services.AddVersionExtension();
			// Добавление работы со Swagger
			builder.Services.AddSwaggerExtension();
			// Добавление IHttpContextAccessor в DI
			builder.Services.AddHttpContextAccessor();
			// Добавление контроля работоспособности сервиса
			builder.Services.AddHealthChecks();
			// Добавление возможности работы с JWT
			builder.Services.AddAuthJwt(builder.Configuration);

			// Добавление работы с логером
			builder.Logging.AddLoggingExtension(builder.Environment.IsDevelopment());

			var app = builder.Build();

			app.Use(async (context, next) =>
			{
				// Добавление в заголовок запроса RequestId, если его нет
				if (!context.Request.Headers.TryGetValue(DomainConsts.RequestIdKey, out var requestId))
				{
					context.Request.Headers.Add(DomainConsts.RequestIdKey, Guid.NewGuid().ToString());
				}
				// Замена заголовка запроса, если это не гуид
				else if (!Guid.TryParse(requestId, out var requestId1))
				{
					context.Request.Headers.Remove(DomainConsts.RequestIdKey);
					context.Request.Headers.Add(DomainConsts.RequestIdKey, Guid.NewGuid().ToString());
				}

				await next.Invoke();
			});

			// Использование прослойки обработки исключений
			app.UseExceptionMiddleware();
			// Использование Swagger
			app.UseSwaggerExtension(builder.Environment.IsDevelopment());
			// Configure the HTTP request pipeline
			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();
			// АПИ контроля жизнеспособности приложения
			app.UseHealthChecks("/ping");
			app.MapControllers();

			app.Run();
		}
	}
}