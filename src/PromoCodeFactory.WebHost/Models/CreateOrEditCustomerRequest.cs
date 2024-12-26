using System;
using System.Collections.Generic;

namespace PromoCodeFactory.WebHost.Models
{
    /// <summary>
    /// Информация по клиенту.
    /// </summary>
    public class CreateOrEditCustomerRequest
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
        /// Список идентификаторов предпочтений.
        /// </summary>
        public virtual List<Guid> PreferenceIds { get; set; }
    }
}