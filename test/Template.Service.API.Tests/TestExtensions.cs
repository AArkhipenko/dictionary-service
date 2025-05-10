using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Service.API.Tests
{
	/// <summary>
	/// Методы расширешения для тестирования
	/// </summary>
	public static class TestExtensions
	{
		/// <summary>
		/// Метод расширешния для <see cref="HttpResponseMessage"/>
		///		Парсит результат как json к заданной моделе
		/// </summary>
		/// <typeparam name="TModel">Модель в которую надо распарсить ответ</typeparam>
		/// <param name="response">ответ на http-запрос</param>
		/// <returns>Объект модели</returns>
		public static async Task<TModel> ReadAsJsonAsync<TModel>(this HttpResponseMessage response)
		{
			var contentStr = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<TModel>(contentStr);
			if(result is null)
			{
				throw new Exception("Не возможно распарсить ответ");
			}
			return result;
		}
	}
}
