using System;

namespace PromoCodeFactory.Core.Services.Contracts.Employee
{
    /// <summary>
    /// Сотрудник.
    /// </summary>
    public class EmployeeShortDto
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
    }
}
