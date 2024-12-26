using System;

namespace PromoCodeFactory.Core.Services.Contracts.Employee
{
    /// <summary>
    /// Сотрудник.
    /// </summary>
    public class EmployeeDto
    {
        /// <summary>
        /// Идентифиатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Роль.
        /// </summary>
        public RoleDto Role { get; set; }

        /// <summary>
        /// Количество примененных промо-кодов .
        /// </summary>
        public int AppliedPromocodesCount { get; set; }
    }
}
