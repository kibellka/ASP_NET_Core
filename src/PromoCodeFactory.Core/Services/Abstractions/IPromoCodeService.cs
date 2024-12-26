using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Services.Contracts.PromoCode;

namespace PromoCodeFactory.Core.Services.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса работы с промо-кодами.
    /// </summary>
    public interface IPromoCodeService
    {
        /// <summary>
        /// Получить все промо-коды.
        /// </summary>
        /// <returns>Предпочтения</returns>
        Task<IEnumerable<PromoCodeShortDto>> GetAllAsync();

        /// <summary>
        /// Создать промокод и выдать его клиентам с указанным предпочтением
        /// </summary>
        /// <returns></returns>
        Task GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeDto dto);
    }
}
