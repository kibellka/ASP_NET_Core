using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromoCodeFactory.Core.Domain.Administration
{
    /// <summary>
    /// Сотрудник.
    /// </summary>
    public class Employee
        : BaseEntity
    {
        /// <summary>
        /// Имя.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// Фамилия и имя.
        /// </summary>
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// Идентифиатор роли.
        /// </summary>
        public virtual Guid RoleId { get; set; }

        /// <summary>
        /// Роль.
        /// </summary>
        public virtual Role Role { get; set; }

        /// <summary>
        /// Количество примененных промо-кодов.
        /// </summary>
        public int AppliedPromocodesCount { get; set; }
    }
}
