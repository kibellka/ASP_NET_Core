using System;

namespace PromoCodeFactory.WebHost.Models
{
    /// <summary>
    /// Клиент.
    /// </summary>
    public class CustomerShortResponse
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