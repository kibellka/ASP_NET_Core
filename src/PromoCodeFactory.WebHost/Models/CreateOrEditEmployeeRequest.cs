using System;

namespace PromoCodeFactory.WebHost.Models
{
    /// <summary>
    /// Информация для создания или редактирвоания сотрудника.
    /// </summary>
    public class CreateOrEditEmployeeRequest
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
