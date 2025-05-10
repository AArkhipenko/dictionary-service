namespace Template.Service.API.Settings
{
	/// <summary>
	/// Найстройки для конфигурирования работы с keycloak
	/// </summary>
	public class KeycloakSettings
	{
		/// <summary>
		/// Адрес авторизации
		/// </summary>
		public string Authority { get; set; }

		/// <summary>
		/// Адрес валидации токена
		/// </summary>
		public string MetadataAddress { get; set; }

		/// <summary>
		/// Признак необходимости валидации https запросов
		/// </summary>
		public bool IsRequireHttpsMetadata { get; set; }

		/// <summary>
		/// Признак необходимости проверки издателя токена
		/// </summary>
		public bool IsValidateIssuer { get; set; }

		/// <summary>
		/// Список допустимых издателей токенов
		/// </summary>
		public string[]? ValidIssuers { get; set; }

		/// <summary>
		/// Признак необходимости проверки потребителя токена
		/// </summary>
		public bool IsValidateAudience { get; set; }

		/// <summary>
		/// Список допустимых потребителей токена
		/// </summary>
		public string[]? ValidAudiences { get; set; }

		/// <summary>
		/// <inheritdoc cref="KeycloakRequirementSettings" path="/summary"/>
		/// </summary>
		public KeycloakRequirementSettings RequirementSettings { get; set; }
	}
}
