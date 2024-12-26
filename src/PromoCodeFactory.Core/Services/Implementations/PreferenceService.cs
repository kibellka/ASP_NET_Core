using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.Core.Services.Abstractions;
using PromoCodeFactory.Core.Services.Contracts.Preference;

namespace PromoCodeFactory.Core.Services.Implementations
{
    /// <summary>
    /// Сервис для работы с предпочтениями.
    /// </summary>
    public class PreferenceService : IPreferenceService
    {
        private readonly IRepository<Preference> _preferenceRepository;

        public PreferenceService(IRepository<Preference> preferenceRepository)
        {
            _preferenceRepository = preferenceRepository;
        }

        /// <summary>
        /// Получить предпочтения.
        /// </summary>
        /// <returns>Предпочтения</returns>
        public async Task<IEnumerable<PreferenceDto>> GetAllAsync()
        {
            var employees = await _preferenceRepository.GetAllAsync();
            var result = employees.Select(e => new PreferenceDto
            {
                Id = e.Id,
                Name = e.Name
            });

            return result;
        }
    }
}
