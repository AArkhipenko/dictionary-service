namespace Dictionary.Service.Domain.Models
{
	/// <summary>
	/// Элемент словаря
	/// </summary>
    public class Element
    {
		/// <summary>
		/// ИД записи
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Наименование
		/// </summary>
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Код
		/// </summary>
		public string Code { get; set; } = string.Empty;

		/// <summary>
		/// Полное наименование
		/// </summary>
		public string? FullName { get; set; }
	}
}
