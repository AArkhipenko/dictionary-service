using Dictionary.Service.Domain.Models;

namespace Dictionary.Service.Domain.Repositories
{
	/// <summary>
	/// Репозитория для работы с элементами справочников
	/// </summary>
    public interface IElementRepository
    {
		/// <summary>
		/// Получение списка лекарственных средств
		/// </summary>
		/// <param name="cancellationToken"><see cref="CancellationToken"/></param>
		/// <returns>Список лекарственных средств</returns>
		Task<IEnumerable<Element>> GetMedicamentTypeList(CancellationToken cancellationToken);
    }
}
