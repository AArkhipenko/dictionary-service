using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Service.Domain.Core.Logging
{
	/// <summary>
	/// Модель раздела логирования
	/// </summary>
	public class ScopeModel
	{
		/// <summary>
		/// ID запроса (для отслеживания цепочки вызовов)
		/// </summary>
		public Guid RequestId { get; set; }

		/// <summary>
		/// Название класса, из которого был выполнен вызов
		/// </summary>
		public string ClassName { get; set; } = string.Empty;

		/// <summary>
		/// Название метода, из которого был выполнен вызов
		/// </summary>
		public string MethodName { get; set; } = string.Empty;
	}
}
