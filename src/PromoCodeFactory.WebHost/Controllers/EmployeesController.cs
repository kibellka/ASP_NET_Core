using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Services.Abstractions;
using PromoCodeFactory.Core.Services.Contracts.Employee;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Сотрудники
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController
        : ControllerBase
    {
        private readonly IMapper _mapper;
        private IEmployeeService _employeeService;

        public EmployeesController(IMapper mapper, IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }

        /// <summary>
        /// Получить данные всех сотрудников.
        /// </summary>
        /// <returns>Сотрудники.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<EmployeeShortResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyCollection<EmployeeShortResponse>>> GetEmployeesAsync()
        {
            var employees = await _employeeService.GetAllAsync();
            var result = _mapper.Map<IReadOnlyCollection<EmployeeShortResponse>>(employees);

            return Ok(result);
        }

        /// <summary>
        /// Получить данные сотрудника по его идентификатору.
        /// </summary>
        /// <returns>Сотрудник.</returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(EmployeeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeResponse>> GetEmployeeAsync(Guid id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
                return NotFound();

            var result = _mapper.Map<EmployeeResponse>(employee);

            return Ok(result);
        }

        /// <summary>
        /// Создать сотрудника.
        /// </summary>
        /// <param name="request">Данные нового сотрудника.</param>
        /// <returns>Созданный сотрудник.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateEmployeeAsync(CreateOrEditEmployeeRequest request)
        {
            var employee = _mapper.Map<EmployeeCreateOrEditDto>(request);
            var id = await _employeeService.CreateAsync(employee);

            return CreatedAtAction(nameof(GetEmployeeAsync), new { id }, null);
        }

        /// <summary>
        /// Обновить данные сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <param name="request">Данные для обновления.</param>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateEmployeeAsync(Guid id, CreateOrEditEmployeeRequest request)
        {
            var data = _mapper.Map<EmployeeCreateOrEditDto>(request);
            var result = await _employeeService.UpdateAsync(id, data);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Удалить сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEmployeeAsync(Guid id)
        {
            var result = await _employeeService.DeleteAsync(id);

            if (result)
                return NoContent();

            return NotFound();
        }
    }
}