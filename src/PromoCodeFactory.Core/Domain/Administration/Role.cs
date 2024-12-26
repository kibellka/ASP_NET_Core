using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.Core.Domain.Administration
{
    /// <summary>
    /// Роль.
    /// </summary>
    public class Role
        : BaseEntity
    {
        /// <summary>
        /// Наименование роли.
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        /// <summary>
        /// Описание роли.
        /// </summary>
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
