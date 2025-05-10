namespace Template.Service.API.Settings
{
	/// <summary>
	/// Раздел с настройками для авторизации
	/// </summary>
	public class KeycloakRequirementSettings
	{
		/// <summary>
		/// Наименование сервиса, к которому у пользователя должен быть доступ
		/// </summary>
		public string Service { get; set; }

		/// <summary>
		/// Наименование роли администратора в текущем сервисе
		/// </summary>
		public string AdminRole { get; set; }

		/// <summary>
		/// Наименование роли пользователя в текущем сервисе
		/// </summary>
		public string UserRole { get; set; }
	}
}
