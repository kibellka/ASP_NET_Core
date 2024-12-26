using System;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    /// <summary>
    /// Предпочтения клиентов.
    /// </summary>
    public class CustomerPreference
    {
        /// <summary>
        /// Идентификатор клиента.
        /// </summary>
        [Required]
        public Guid CustomerId { get; set; }

		/// <summary>
		/// Идентификатор предпочтения.
		/// </summary>
		[Required]
		public Guid PreferenceId { get; set; }

        /// <summary>
        /// Клиент.
        /// </summary>
        public virtual Customer Customer { get; set; }
        
        /// <summary>
        /// Предпочтение.
        /// </summary>
        public virtual Preference Preference { get; set; }
    }
}
