using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;

namespace PromoCodeFactory.Core.Services.Contracts.Customer
{
    /// <summary>
    /// Информация для создания или обновления клиента.
    /// </summary>
    public class CustomerCreateOrEditDto
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Идентификаторы предпочтений
        /// </summary>
        public List<Guid> PreferenceIds { get; set; }
    }
}
