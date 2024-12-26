using System;

namespace PromoCodeFactory.Core.Services.Contracts.Employee
{
    /// <summary>
    /// Информация для создания сотрудника.
    /// </summary>
    public class EmployeeCreateOrEditDto
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
        /// Идентифиатор роли.
        /// </summary>
        public Guid RoleId { get; set; }
    }
}
