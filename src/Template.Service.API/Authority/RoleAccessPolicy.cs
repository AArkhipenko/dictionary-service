using Microsoft.AspNetCore.Authorization;

namespace Template.Service.API.Authority
{
	/// <summary>
	/// Условие авторизации по роли пользователя
	/// </summary>
	public class RoleAccessPolicy : IAuthorizationRequirement
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="RoleAccessPolicy"/> class.
		/// </summary>
		/// <param name="serviceName"><inheritdoc cref="ServiceName" path="/summary"/></param>
		/// <param name="roleName"><inheritdoc cref="RoleName" path="/summary"/></param>
		public RoleAccessPolicy(string serviceName, string roleName)
		{
			this.ServiceName = serviceName;
			this.RoleName = roleName;
		}

		/// <summary>
		/// Наименование сервиса, к которому должен быть доступ
		/// </summary>
		public string ServiceName { get; }

		/// <summary>
		/// Наименование необходимой роли
		/// </summary>
		public string RoleName { get; }
	}
}
