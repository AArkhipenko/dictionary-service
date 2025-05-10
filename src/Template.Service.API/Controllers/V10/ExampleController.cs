using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Service.Application.V10.Example.Queries;

namespace Template.Service.API.Controllers.V10
{
	/// <summary>
	/// Контроллер-пример
	/// </summary>
    [ApiController]
	[ApiVersion("10", Deprecated = false)]
	[Route("examples/v{version:apiVersion}")]
	public class ExampleController : ApiBaseController
    {
		private readonly IMediator _mediator;

		/// <summary>
		/// Initializes a new instance of the <see cref="ExampleController"/> class.
		/// </summary>
		/// <param name="mediator"><see cref="IMediator"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		/// <param name="contextAccessor"><see cref="IHttpContextAccessor"/></param>
		/// <exception cref="ArgumentNullException">не задан входной параметр</exception>
		public ExampleController(
			IMediator mediator,
			ILogger<ExampleController> logger,
			IHttpContextAccessor contextAccessor)
			: base(logger, contextAccessor)
        {
			_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		/// <summary>
		/// Тестовый метод получения данных
		/// </summary>
		/// <param name="cancellationToken"><see cref="CancellationToken"/></param>
		/// <returns>Список случайных чисел</returns>
		[HttpGet]
        public async Task<ActionResult<IEnumerable<int>>> GetAsync(CancellationToken cancellationToken)
        {
			using(_ = base.BeginLoggingScope())
			{
				var result = await this._mediator.Send(new GetRandomQuery(), cancellationToken);
				return Ok(result);
			}
		}

		/// <summary>
		/// Тестовый метод получения данных
		/// </summary>
		/// <param name="cancellationToken"><see cref="CancellationToken"/></param>
		/// <returns>Список случайных чисел</returns>
		[HttpGet("exception")]
		public async Task<IActionResult> GetExceptionAsync(CancellationToken cancellationToken)
		{
			using (_ = base.BeginLoggingScope())
			{
				_ = await this._mediator.Send(new GetExceptionQuery(), cancellationToken);
				return Ok();
			}
		}
	}
}