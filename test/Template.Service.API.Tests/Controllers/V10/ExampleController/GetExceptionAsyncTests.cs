using System.Net;
using Xunit.Abstractions;
using Controller = Template.Service.API.Controllers.V10.ExampleController;

namespace Template.Service.API.Tests.Controllers.V10.ExampleController
{
	/// <summary>
	/// Тесты на метод <see cref="Controller.GetExceptionAsync(CancellationToken)"/>
	/// </summary>
    public class GetExceptionAsyncTests : TestBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GetExceptionAsyncTests"/> class.
		/// </summary>
		/// <param name="testOutputHelper"><see cref="ITestOutputHelper"/></param>
		public GetExceptionAsyncTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

		/// <summary>
		/// В процессе выполнения АПИ было вызвано исключение
		/// </summary>
		/// <returns>BadRequest</returns>
		[Fact]
		public async Task It_returns_BadRequest()
		{
			// Настройки приложения
			var testClient = TestBase.CreateClient(services => { });

			// Выполнение запроса
			var response = await testClient.GetAsync("/examples/v10/exception");

			// Тесты результата
			Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
		}
    }
}
