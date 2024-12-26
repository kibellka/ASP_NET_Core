using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Services.Abstractions;
using PromoCodeFactory.Core.Services.Contracts;
using PromoCodeFactory.Core.Services.Contracts.Employee;

namespace PromoCodeFactory.Core.Services.Implementations
{
    /// <summary>
    /// Сервис для работы с сотрудником.
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Получить сотрудников.
        /// </summary>
        /// <returns>Сотрудник.</returns>
        public async Task<IEnumerable<EmployeeShortDto>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            var result = employees.Select(e => new EmployeeShortDto
                {
                    Id = e.Id, 
                    FullName = e.FullName,
                    Email = e.Email
             });

            return result;
        }

        /// <summary>
        /// Получить сотрудника по его идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Сотрудник.</returns>
        public async Task<EmployeeDto> GetByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return null;

            var result = new EmployeeDto
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Email = employee.Email,
                Role = new RoleDto
                {
                    Id = employee.Role.Id,
                    Name = employee.Role.Name,
                    Description = employee.Role.Description
                },
                AppliedPromocodesCount = employee.AppliedPromocodesCount
            };

            return result;
        }

        /// <summary>
        /// Создать сотрудника.
        /// </summary>
        /// <param name="dto">DTO создаваемого сотрудника.</param>
        /// <returns>Сотрудник.</returns>
        public async Task<Guid> CreateAsync(EmployeeCreateOrEditDto dto)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                RoleId = dto.RoleId
            };

            var createdEmployee = await _employeeRepository.AddAsync(employee);

            return createdEmployee.Id;
        }

        /// <summary>
        /// Изменить данные сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор редактируемого сотрудника.</param>
        /// <param name="dto">DTO редактируемого сотрудника.</param>
        /// <returns>Сотрудник.</returns>
        public async Task<EmployeeShortDto> UpdateAsync(Guid id, EmployeeCreateOrEditDto dto)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
                return null;

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Email = dto.Email;
            employee.RoleId = dto.RoleId;
            var updatedEmployee = await _employeeRepository.UpdateAsync(employee);
            var result = new EmployeeShortDto
            {
                Id = updatedEmployee.Id,
                FullName = updatedEmployee.FullName,
                Email = updatedEmployee.Email
            };

            return result;
        }

        /// <summary>
        /// Удалить сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор удаляемого сотрудника.</param>
        /// <returns>Признак успешного удаления сотрудника.</returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _employeeRepository.DeleteAsync(id);

            return result;
        }
    }
}
