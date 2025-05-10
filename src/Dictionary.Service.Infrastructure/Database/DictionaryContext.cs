using Dictionary.Service.Infrastructure.Database.Tables;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Dictionary.Service.Infrastructure.Database
{
	/// <summary>
	/// Контекст БД словарей
	/// </summary>
	internal class DictionaryContext : DbContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DictionaryContext"/> class.
		/// </summary>
		/// <param name="option"><see cref="DbContextOptions"/></param>
		public DictionaryContext(DbContextOptions option)
			: base(option)
		{
		}

		/// <summary>
		/// Словарь активных веществ
		/// </summary>
		public DbSet<ActiveSubstanceType> ActiveSubstanceTypes { get; set; }

		/// <summary>
		/// Словарь лекарственных средств
		/// </summary>
		public DbSet<MedicamentType> MedicamentTypes { get; set; }

		/// <inheritdoc/>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			ActiveSubstanceType.Configure(modelBuilder);
			MedicamentType.Configure(modelBuilder);
		}
	}
}
