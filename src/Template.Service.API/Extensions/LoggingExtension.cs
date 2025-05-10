using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Template.Service.API.Logging;

namespace Template.Service.API.Extensions
{
	/// <summary>
	/// Методы расширешения для настройки логирования в приложении
	/// </summary>
	public static class LoggingExtension
	{
		/// <summary>
		/// Добавления настроект логирования
		/// </summary>
		/// <param name="builder"><see cref="ILoggingBuilder"/></param>
		/// <param name="isDevelopment">признак режима разработки</param>
		/// <returns><see cref="ILoggingBuilder"/></returns>
		public static ILoggingBuilder AddLoggingExtension(this ILoggingBuilder builder, bool isDevelopment)
		{
			// Удаление всех провайдеров
			builder.ClearProviders();

			if (isDevelopment)
			{
				// Добавление провайдера логирования в консоль
				builder.AddProvider(new JsonConsoleLoggerProvider());
			}
			else
			{
				// Добавление провайдера логирования в файл
				var filePath = "./output.log";
				if(File.Exists(filePath))
				{
					File.Delete(filePath);
				}

				builder.AddProvider(new FileLoggerProvider(filePath));
			}

			return builder;
		}
	}
}
