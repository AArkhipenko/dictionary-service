using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace Template.Service.API.Authority
{
	/// <summary>
	/// Обработка <see cref="RoleAccessPolicy"/>
	/// </summary>
	public class RoleAccessHandler : AuthorizationHandler<RoleAccessPolicy>
	{
		/// <inheritdoc />
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleAccessPolicy requirement)
		{
			try
			{
				var claim = context.User.Claims.Where(claim => claim.Type == "resource_access").FirstOrDefault();
				if (claim == null)
				{
					throw new Exception("Не найден раздел resource_access");
				}

				var services = JsonConvert.DeserializeObject<IDictionary<string, ResourceInnerModel>>(claim.Value);
				if (services is null ||
					!services.TryGetValue(requirement.ServiceName, out var resourceInnerModel))
				{
					throw new Exception("Нет доступа к сервису");
				}

				if (!resourceInnerModel.Roles.Contains(requirement.RoleName))
				{
					throw new Exception("Пользователь не имеет необходимых ролей");
				}

				context.Succeed(requirement);
			}
			catch (Exception ex)
			{
				var reasone = new AuthorizationFailureReason(this, ex.Message);
				context.Fail();
			}

			return Task.CompletedTask;
		}
	}
}
