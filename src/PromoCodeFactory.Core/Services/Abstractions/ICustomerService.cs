using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Services.Contracts.Customer;

namespace PromoCodeFactory.Core.Services.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса работы с клиентами.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Получить клиента.
        /// </summary>
        /// <returns>Клиенты.</returns>
        Task<IEnumerable<CustomerShortDto>> GetAllAsync();

        /// <summary>
        /// Получить клиента.
        /// </summary>
        /// <param name="id">Идентификатор клиента.</param>
        /// <returns>Клиент.</returns>
        Task<CustomerDto> GetByIdAsync(Guid id);

        /// <summary>
        /// Создать клиента.
        /// </summary>
        /// <param name="dto">Клиент.</param>
        Task<Guid> CreateAsync(CustomerCreateOrEditDto dto);

        /// <summary>
        /// Изменить данные клиента.
        /// </summary>
        /// <param name="id">Идентификатор клиента.</param>
        /// <param name="dto">Клиент.</param>
        Task<CustomerShortDto> UpdateAsync(Guid id, CustomerCreateOrEditDto dto);

        /// <summary>
        /// Удалить клиента.
        /// </summary>
        /// <param name="id">Идентификатор клиента.</param>
        Task<bool> DeleteAsync(Guid id);
    }
}
