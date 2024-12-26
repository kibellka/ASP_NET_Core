using System;

namespace PromoCodeFactory.WebHost.Models
{
    /// <summary>
    /// Промо-код
    /// </summary>
    public class PromoCodeShortResponse
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
        public string BeginDate { get; set; }

        /// <summary>
        /// Дата завершения действия.
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// Партнер.
        /// </summary>
        public string PartnerName { get; set; }
    }
}
