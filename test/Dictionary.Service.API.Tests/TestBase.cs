using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Xunit.Abstractions;

namespace Dictionary.Service.API.Tests
{
	/// <summary>
	/// Базовый тестовый класс
	/// </summary>
	public class TestBase
	{
		private ITestOutputHelper _testOutputHelper;

		/// <summary>
		/// Initializes a new instance of the <see cref="TestBase"/> class.
		/// </summary>
		/// <param name="testOutputHelper"><see cref="ITestOutputHelper"/></param>
		public TestBase(ITestOutputHelper testOutputHelper)
		{
			this._testOutputHelper = testOutputHelper;
		}

		/// <summary>
		/// Получение логера для тестов
		/// </summary>
		public ITestOutputHelper TestOutputHelper { get { return _testOutputHelper; } }

		/// <summary>
		/// Создание тестового http-клиента для проверки АПИ
		/// </summary>
		/// <param name="configureServices">метод настройки DI</param>
		/// <returns><see cref="HttpClient"/></returns>
		public static HttpClient CreateClient(Action<IServiceCollection> configureServices)
		{
			var server = new WebApplicationFactory<Program>()
				.WithWebHostBuilder(builder =>
				{
					builder.ConfigureServices(configureServices);
				});
			var client = server.CreateClient();
			return client;
		}

		/// <summary>
		/// Создание тестового http-клиента с обходом JWT для проверки АПИ 
		/// </summary>
		/// <param name="configureServices">метод настройки DI</param>
		/// <returns><see cref="HttpClient"/></returns>
		public static HttpClient CreateAuthClient(Action<IServiceCollection> configureServices)
		{
			var configuration = new ConfigurationBuilder()
				.AddEnvironmentVariables()
				.AddJsonFile("appsettings.Test.json")
				.Build();

			var server = new WebApplicationFactory<Program>()
				.WithWebHostBuilder(builder =>
				{

					builder.UseConfiguration(configuration);
					builder.ConfigureServices(configureServices);
				});
			var client = server.CreateClient();
			return client;
		}
	}
}
