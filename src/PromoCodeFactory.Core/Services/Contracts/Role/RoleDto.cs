using System;

namespace PromoCodeFactory.Core.Services.Contracts
{
    /// <summary>
    /// Роль.
    /// </summary>
    public class RoleDto
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
