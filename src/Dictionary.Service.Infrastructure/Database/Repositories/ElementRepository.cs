using AArkhipenko.Core.Logging;
using Dictionary.Service.Domain.Models;
using Dictionary.Service.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Dictionary.Service.Infrastructure.Database.Repositories
{
	/// <inheritdoc cref="IElementRepository"/>
	internal class ElementRepository : LoggerWrapper, IElementRepository
	{
		private readonly DictionaryContext _context;

		/// <summary>
		/// Initializes a new instance of the <see cref="ElementRepository"/> class.
		/// </summary>
		/// <param name="context"><see cref="DictionaryContext"/></param>
		/// <param name="logger"><see cref="ILogger"/></param>
		public ElementRepository(
			DictionaryContext context,
			ILogger<ElementRepository> logger)
			: base(logger)
		{
			this._context = context ?? throw new ArgumentNullException(nameof(context));
		}

		/// <inheritdoc/>
		public async Task<IEnumerable<Element>> GetMedicamentTypeList(CancellationToken cancellationToken)
		{
			var list = await this._context.MedicamentTypes
				.Select(x => new
				{
					Id = x.Id,
					Name = x.Name,
					Code = x.Code,
					Dosage = x.Dosage,
					ActiveSubstanceName = x.ActiveSubstanceTypeId.HasValue ? x.ActiveSubstanceType.Name : null
				})
				.ToListAsync(cancellationToken);

			return list.Select(x =>
			{
				var fullNameBuilder = new StringBuilder(x.Name);
				if (!string.IsNullOrEmpty(x.Dosage) ||
					!string.IsNullOrEmpty(x.ActiveSubstanceName))
				{
					fullNameBuilder.Append(" (");
					if (!string.IsNullOrEmpty(x.Dosage))
					{
						fullNameBuilder.Append(x.Dosage);
					}

					if (!string.IsNullOrEmpty(x.Dosage) &&
						!string.IsNullOrEmpty(x.ActiveSubstanceName))
					{
						fullNameBuilder.Append(" ");
					}

					if (!string.IsNullOrEmpty(x.ActiveSubstanceName))
					{
						fullNameBuilder.Append(x.ActiveSubstanceName);
					}

					fullNameBuilder.Append(")");
				}

				return new Element
				{
					Id = x.Id,
					Name = x.Name,
					Code = x.Code,
					FullName = fullNameBuilder.ToString()
				};
			});
		}

		/// <inheritdoc/>
		public Task<List<Element>> GetDayTimeTypeList(CancellationToken cancellationToken)
		{
			return this._context.DayTimeTypes
				.Select(x => new Element
				{
					Id = x.Id,
					Name = x.Name,
					Code = x.Code,
					FullName = $"{x.Name} ({x.Time.ToString("HH:mm")})"
				})
				.ToListAsync(cancellationToken);
		}
	}
}
