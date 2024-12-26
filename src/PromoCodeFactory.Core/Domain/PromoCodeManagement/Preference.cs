using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    /// <summary>
    /// Предпочтение.
    /// </summary>
    public class Preference
        : BaseEntity
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
