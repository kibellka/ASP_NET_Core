using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Services.Contracts.Employee;

namespace PromoCodeFactory.Core.Services.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса работы с сотрудниками.
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Получить сотрудников.
        /// </summary>
        /// <returns>Сотрудники</returns>
        Task<IEnumerable<EmployeeShortDto>> GetAllAsync();

        /// <summary>
        /// Получить сотрудника.
        /// </summary>
        /// <param name="id"> Идентификатор сотрудника.</param>
        /// <returns>Сотрудник.</returns>
        Task<EmployeeDto> GetByIdAsync(Guid id);

        /// <summary>
        /// Создать сотрудника.
        /// </summary>
        /// <param name="creatingCourseDto">Сотрудник.</param>
        Task<Guid> CreateAsync(EmployeeCreateOrEditDto dto);

        /// <summary>
        /// Изменить данные сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <param name="updatingCourseDto">Сотрудник.</param>
        Task<EmployeeShortDto> UpdateAsync(Guid id, EmployeeCreateOrEditDto dto);

        /// <summary>
        /// Удалить сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        Task<bool> DeleteAsync(Guid id);
    }
}
