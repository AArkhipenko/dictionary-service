using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dictionary.Service.Infrastructure.Database.Tables
{
	/// <summary>
	/// Модель записи таблицы public.active_substance_types
	/// </summary>
	internal sealed class ActiveSubstanceType
	{
		/// <summary>
		/// ИД
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Название
		/// </summary>
		public string Name { get; set; } = string.Empty;

		/// <summary>
		/// Код
		/// </summary>
		public string Code { get; set; } = string.Empty;

		/// <summary>
		/// Конфигурирование словаря
		/// </summary>
		/// <param name="builder"><see cref="ModelBuilder"/></param>
		public static void Configure(ModelBuilder builder)
			=> Configure(builder.Entity<ActiveSubstanceType>());

		/// <summary>
		/// Конфигурирование словаря
		/// </summary>
		/// <param name="builder"><see cref="EntityTypeBuilder"/></param>
		private static void Configure(EntityTypeBuilder<ActiveSubstanceType> builder)
		{
			builder.ToTable("active_substance_types", "public")
				.HasKey(k => k.Id);

			builder
				.Property<int>(p => p.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property<string>(p => p.Name)
				.HasColumnName("name");

			builder
				.Property<string>(p => p.Code)
				.HasColumnName("code");
		}
	}
}
