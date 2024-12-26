using System;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.Core.Services.Contracts.Preference
{
    /// <summary>
    /// Предпочтение.
    /// </summary>
    public class PreferenceDto
    {
        /// <summary>
        /// Идентифиатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
