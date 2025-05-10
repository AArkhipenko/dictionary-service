using System.Net;
using Xunit.Abstractions;
using Controller = Template.Service.API.Controllers.V10.ExampleController;

namespace Template.Service.API.Tests.Controllers.V10.ExampleController
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
			var testClient = CreateClient(services => { });

			// Выполнение запроса
			var response = await testClient.GetAsync("/examples/v10");

			// Тесты результата
			Assert.Equal(HttpStatusCode.OK, response.StatusCode);

			var content = await response.ReadAsJsonAsync<IEnumerable<int>>();

			Assert.NotNull(content);
			Assert.NotEmpty(content);
		}
    }
}
