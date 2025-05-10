using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Template.Service.API.Settings;
using Xunit.Abstractions;

namespace Template.Service.API.Tests
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

			var jwtTokenSettings = configuration.GetSection("JwtTokenSettings").Get<KeycloakSettings>();
			if (jwtTokenSettings is null)
			{
				throw new Exception("Не найдена секция настройки JWT");
			}

			var server = new WebApplicationFactory<Program>()
				.WithWebHostBuilder(builder =>
				{

					builder.UseConfiguration(configuration);
					builder.ConfigureServices(configureServices);
				});
			var client = server.CreateClient();

			var fakeJwtToken = GenerateFakeToken(jwtTokenSettings);
			client.DefaultRequestHeaders.Add("Authorization", $"Bearer {fakeJwtToken}");
			return client;
		}

		/// <summary>
		/// Генерация не настоящего JWT-токена
		/// </summary>
		/// <param name="jwtTokenSettings"><inheritdoc cref="KeycloakSettings" path="/summary"/></param>
		/// <returns>JWT-токен</returns>
		private static string GenerateFakeToken(KeycloakSettings jwtTokenSettings)
		{

			var claims = new List<Claim>() {
				new Claim(JwtRegisteredClaimNames.NameId, "FakeUserId"),
				new Claim(JwtRegisteredClaimNames.UniqueName, "FakeUniqueUser"),
			};

			var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecriteKeySecriteKeySecriteKeySecriteKeySecriteKey"));
			var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

			var tokeOptions = new JwtSecurityToken(
				issuer: "Issuer",
				audience: "Audience",
				claims: claims,
				expires: DateTime.UtcNow.AddHours(24),
				signingCredentials: signinCredentials
			);

			return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
		}
	}
}
