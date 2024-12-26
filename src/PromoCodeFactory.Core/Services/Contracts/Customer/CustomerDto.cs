using System;
using System.Collections.Generic;
using PromoCodeFactory.Core.Services.Contracts.Preference;
using PromoCodeFactory.Core.Services.Contracts.PromoCode;

namespace PromoCodeFactory.Core.Services.Contracts.Customer
{
    /// <summary>
    /// Клиент.
    /// </summary>
    public class CustomerDto
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
        public virtual ICollection<PreferenceDto> Preferences { get; set; }

        /// <summary>
        /// Список промокодов.
        /// </summary>
        public virtual ICollection<PromoCodeShortDto> PromoCodes { get; set; }
    }
}
