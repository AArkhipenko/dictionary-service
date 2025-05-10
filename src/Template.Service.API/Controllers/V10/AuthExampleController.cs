using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Template.Service.Application.V10.Example.Queries;

namespace Template.Service.API.Controllers.V10
{
	/// <summary>
	/// Контроллер-пример
	/// </summary>
    [ApiController]
	[ApiVersion("10", Deprecated = false)]
	[Route("auth-examples/v{version:apiVersion}")]
	public class AuthExampleController : ApiAuthBaseController
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="AuthExampleController"/> class.
		/// </summary>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		/// <exception cref="ArgumentNullException">не задан входной параметр</exception>
		public AuthExampleController(
			ILogger<ExampleController> logger,
			IHttpContextAccessor contextAccessor)
			: base(logger, contextAccessor)
        {
		}

		/// <summary>
		/// Тестовый метод получения данных для пользователя с ролью администратор
		/// </summary>
		/// <param name="cancellationToken"><see cref="CancellationToken"/></param>
		/// <returns>Ничего</returns>
		[HttpGet("for-admin")]
		[Authorize("AdminRole")]
		public Task<IActionResult> GetAdminAsync(CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				return Task.FromResult<IActionResult>(Ok());
			}
		}

		/// <summary>
		/// Тестовый метод получения данных для пользователя с ролью администратор
		/// </summary>
		/// <param name="cancellationToken"><see cref="CancellationToken"/></param>
		/// <returns>Ничего</returns>
		[HttpGet("for-user")]
		[Authorize("UserRole")]
		public Task<IActionResult> GetUserAsync(CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				return Task.FromResult<IActionResult>(Ok());
			}
		}
	}
}