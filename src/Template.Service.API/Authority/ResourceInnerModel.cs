namespace Template.Service.API.Authority
{
	/// <summary>
	/// Модель внутренностей раздела resource_access
	/// </summary>
	public class ResourceInnerModel
	{
		/// <summary>
		/// Роли пользователя в рамках 
		/// </summary>
		public IEnumerable<string> Roles { get; set; } = Enumerable.Empty<string>();
	}
}
