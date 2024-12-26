namespace PromoCodeFactory.Core.Services.Contracts.PromoCode
{
    /// <summary>
    /// Промо-код для выдачи клиенту.
    /// </summary>
    public class GivePromoCodeDto
    {
        /// <summary>
        /// Сервисная информация.
        /// </summary>
        public string ServiceInfo { get; set; }

        /// <summary>
        /// Партнер.
        /// </summary>
        public string PartnerName { get; set; }

        /// <summary>
        /// Промо-код
        /// </summary>
        public string PromoCode { get; set; }

        /// <summary>
        /// Предпочтение
        /// </summary>
        public string Preference { get; set; }
    }
}
