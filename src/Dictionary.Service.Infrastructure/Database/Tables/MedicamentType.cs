using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dictionary.Service.Infrastructure.Database.Tables
{
	/// <summary>
	/// Модель записи таблицы public.medicament_types
	/// </summary>
	internal sealed class MedicamentType
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
		/// ИД активного вещества
		/// </summary>
		public int? ActiveSubstanceTypeId { get; set; }

		/// <summary>
		/// ИД активного вещества
		/// </summary>
		public ActiveSubstanceType? ActiveSubstanceType { get; set; }

		/// <summary>
		/// Дозировка активного вещества
		/// </summary>
		public string? Dosage { get; set; }

		/// <summary>
		/// Конфигурирование словаря
		/// </summary>
		/// <param name="builder"><see cref="ModelBuilder"/></param>
		public static void Configure(ModelBuilder builder)
			=> Configure(builder.Entity<MedicamentType>());

		/// <summary>
		/// Конфигурирование словаря
		/// </summary>
		/// <param name="builder"><see cref="EntityTypeBuilder"/></param>
		private static void Configure(EntityTypeBuilder<MedicamentType> builder)
		{
			builder.ToTable("medicament_types", "public")
				.HasKey(k => k.Id);

			builder
				.Property<int>(p => p.Id)
				.HasColumnName("id")
				.ValueGeneratedOnAdd();

			builder
				.Property<string>(p => p.Name)
				.HasColumnName("name")
				.IsRequired();

			builder
				.Property<string>(p => p.Code)
				.HasColumnName("code")
				.IsRequired();

			builder
				.Property<int?>(p => p.ActiveSubstanceTypeId)
				.HasColumnName("active_substance_type_id");

			builder
				.HasOne(x => x.ActiveSubstanceType)
				.WithOne()
				.HasForeignKey<MedicamentType>(x => x.ActiveSubstanceTypeId);

			builder
				.Property<string?>(p => p.Dosage)
				.HasColumnName("dosage");
		}
	}
}
