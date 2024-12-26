using System.Collections.Generic;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Services.Contracts.Preference;

namespace PromoCodeFactory.Core.Services.Abstractions
{
	/// <summary>
	/// Интерфейс сервиса работы с предпочтениями.
	/// </summary>
	public interface IPreferenceService
    {
        /// <summary>
        /// Получить все предпочтения.
        /// </summary>
        /// <returns>Предпочтения</returns>
        Task<IEnumerable<PreferenceDto>> GetAllAsync();
    }
}
