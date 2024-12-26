using System;

namespace PromoCodeFactory.WebHost.Models
{
    /// <summary>
    /// Предпочтение.
    /// </summary>
    public class PreferenceResponse
    {
        /// <summary>
        /// Идентифиатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }
    }
}
