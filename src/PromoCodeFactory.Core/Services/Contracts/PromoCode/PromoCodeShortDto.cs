using System;

namespace PromoCodeFactory.Core.Services.Contracts.PromoCode
{
    /// <summary>
    /// Промо-код.
    /// </summary>
    public class PromoCodeShortDto
    {
        /// <summary>
        /// Идентифиатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Код.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Сервисная информация.
        /// </summary>
        public string ServiceInfo { get; set; }

        /// <summary>
        /// Дата начала действия.
        /// </summary>
        public DateTime BeginDate { get; set; }

        /// <summary>
        /// Дата завершения действия.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Партнер.
        /// </summary>
        public string PartnerName { get; set; }
    }
}
