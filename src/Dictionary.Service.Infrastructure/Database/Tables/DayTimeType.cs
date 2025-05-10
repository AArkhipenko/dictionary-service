using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dictionary.Service.Infrastructure.Database.Tables
{
	/// <summary>
	/// Модель записи таблицы public.day_time_types
	/// </summary>
	internal sealed class DayTimeType
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
		/// Код
		/// </summary>
		public TimeOnly Time { get; set; }

		/// <summary>
		/// Конфигурирование словаря
		/// </summary>
		/// <param name="builder"><see cref="ModelBuilder"/></param>
		public static void Configure(ModelBuilder builder)
			=> Configure(builder.Entity<DayTimeType>());

		/// <summary>
		/// Конфигурирование словаря
		/// </summary>
		/// <param name="builder"><see cref="EntityTypeBuilder"/></param>
		private static void Configure(EntityTypeBuilder<DayTimeType> builder)
		{
			builder.ToTable("day_time_types", "public")
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

			builder
				.Property<TimeOnly>(p => p.Time)
				.HasColumnName("time");
		}
	}
}
