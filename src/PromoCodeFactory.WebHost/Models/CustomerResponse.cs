using System;
using System.Collections.Generic;

namespace PromoCodeFactory.WebHost.Models
{
    /// <summary>
    /// Клиент.
    /// </summary>
    public class CustomerResponse
    {
        /// <summary>
        /// Идентифиатор.
        /// </summary>
        public Guid Id { get; set; }

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
        /// Список предпочтений.
        /// </summary>
        public List<PreferenceResponse> Preferences { get; set; }

        /// <summary>
        /// Список промокодов.
        /// </summary>
        public List<PromoCodeShortResponse> PromoCodes { get; set; }
    }
}