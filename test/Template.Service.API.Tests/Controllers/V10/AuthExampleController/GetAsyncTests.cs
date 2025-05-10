using System.Net;
using Xunit.Abstractions;
using Controller = Template.Service.API.Controllers.V10.AuthExampleController;

namespace Template.Service.API.Tests.Controllers.V10.AuthExampleController
{
	/// <summary>
	/// Тесты на метод <see cref="Controller.GetAsync(CancellationToken)"/>
	/// </summary>
	public class GetAsyncTests : TestBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GetAsyncTests"/> class.
		/// </summary>
		/// <param name="testOutputHelper"><see cref="ITestOutputHelper"/></param>
		public GetAsyncTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

		/// <summary>
		/// Корректное выполнение АПИ
		/// </summary>
		/// <returns>OK</returns>
		[Fact]
		public async Task It_returns_not_empty_list()
		{
			// Настройки приложения
			var testClient = CreateAuthClient(services => { });

			// Выполнение запроса
			var response = await testClient.GetAsync("/auth-examples/v10");

			// Тесты результата
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);
		}
	}
}
