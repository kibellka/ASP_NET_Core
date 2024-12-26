using System;

namespace PromoCodeFactory.WebHost.Models
{
    /// <summary>
    /// Роль.
    /// </summary>
    public class RoleItemResponse
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание роли.
        /// </summary>
        public string Description { get; set; }
    }
}