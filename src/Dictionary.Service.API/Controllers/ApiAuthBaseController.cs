using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Dictionary.Service.API.Controllers
{
	/// <summary>
	/// Базовый контроллер c поддержкой авторизации
	/// </summary>
	[Authorize]
	public abstract class ApiAuthBaseController : ApiBaseController
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ApiAuthBaseController"/> class.
		/// </summary>
		/// <param name="logger"><see cref="ILogger"/></param>
		protected ApiAuthBaseController(ILogger logger)
			: base(logger)
		{
		}
	}
}
