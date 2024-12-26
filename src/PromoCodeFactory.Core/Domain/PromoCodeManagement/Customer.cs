using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    /// <summary>
    /// Клиент.
    /// </summary>
    public class Customer
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
        [MaxLength(70)]
        public string LastName { get; set; }

        /// <summary>
        /// Имя.
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
        /// Список предпочтений.
        /// </summary>
        public virtual ICollection<CustomerPreference> Preferences { get; set; }

        /// <summary>
        /// Список промокодов.
        /// </summary>
        public virtual ICollection<PromoCode> PromoCodes { get; set; }
    }
}