using System;
using System.ComponentModel.DataAnnotations;
using PromoCodeFactory.Core.Domain.Administration;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    /// <summary>
    /// Промо-код.
    /// </summary>
    public class PromoCode
        : BaseEntity
    {
        /// <summary>
        /// Код.
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }

        /// <summary>
        /// Сервисная информация.
        /// </summary>
        [MaxLength(200)]
        public string ServiceInfo { get; set; }

        /// <summary>
        /// Дата начала действия.
        /// </summary>
        [Required]
        public DateTime BeginDate { get; set; }

        /// <summary>
        /// Дата завершения действия.
        /// </summary>
        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Идентификатор покупателя.
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Покупатель.
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Партнер.
        /// </summary>
        [MaxLength(100)]
        public string PartnerName { get; set; }

        public string NewTestColumn { get; set; }

        /// <summary>
        /// Менеджер партнера.
        /// </summary>
        public virtual Employee PartnerManager { get; set; }

        /// <summary>
        /// Предпочтение.
        /// </summary>
        public virtual Preference Preference { get; set; }
    }
}
