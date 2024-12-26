using System;

namespace PromoCodeFactory.Core.Services.Contracts.Customer
{
    /// <summary>
    /// Клиент.
    /// </summary>
    public class CustomerShortDto
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
    }
}
