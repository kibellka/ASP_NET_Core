using System;

namespace PromoCodeFactory.WebHost.Models
{
    /// <summary>
    /// Сотрудник.
    /// </summary>
    public class EmployeeResponse
    {
        /// <summary>
        /// Идентифиатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Фамилия и имя.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Роль.
        /// </summary>
        public RoleItemResponse Role { get; set; }

        /// <summary>
        /// Количество примененных промо-кодов .
        /// </summary>
        public int AppliedPromocodesCount { get; set; }
    }
}