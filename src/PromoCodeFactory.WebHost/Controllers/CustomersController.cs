using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Services.Abstractions;
using PromoCodeFactory.Core.Services.Contracts.Customer;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Клиенты
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomersController
        : ControllerBase
    {
        private readonly IMapper _mapper;
        private ICustomerService _customerService;

        public CustomersController(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        /// <summary>
        /// Получить данные всех клиентов.
        /// </summary>
        /// <returns>Клиенты.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<CustomerShortResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyCollection<CustomerShortResponse>>> GetCustomersAsync()
        {
            var customers = await _customerService.GetAllAsync();
            var result = _mapper.Map<IReadOnlyCollection<CustomerShortResponse>>(customers);

            return Ok(result);
        }

        /// <summary>
        /// Получить данные клиента по его идентификатору.
        /// </summary>
        /// <returns>Клиент.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomerResponse>> GetCustomerAsync(Guid id)
        {
            //TODO: Добавить получение клиента вместе с выданными ему промокодами
            var customer = await _customerService.GetByIdAsync(id);

            if (customer == null)
                return NotFound();

            var result = _mapper.Map<CustomerResponse>(customer);

            return Ok(result);
        }

        /// <summary>
        /// Создать клиента.
        /// </summary>
        /// <param name="request">Данные нового сотрудника.</param>
        /// <returns>Созданный сотрудник.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> CreateCustomerAsync(CreateOrEditCustomerRequest request)
        {
            //TODO: Добавить создание нового клиента вместе с его предпочтениями
            var customer = _mapper.Map<CustomerCreateOrEditDto>(request);
            var id = await _customerService.CreateAsync(customer);

            return CreatedAtAction(nameof(GetCustomerAsync), new { id }, null);
        }

        /// <summary>
        /// Обновить данные клиента.
        /// </summary>
        /// <param name="id">Идентификатор клиента.</param>
        /// <param name="request">Данные для обновления.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCustomersAsync(Guid id, CreateOrEditCustomerRequest request)
        {
            //TODO: Обновить данные клиента вместе с его предпочтениями
            var customer = _mapper.Map<CustomerCreateOrEditDto>(request);
            var result = await _customerService.UpdateAsync(id, customer);

            if (result == null)
                return NotFound();

            return NoContent();
        }

        /// <summary>
        /// Удалить клиента.
        /// </summary>
        /// <param name="id">Идентификатор клиента.</param>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCustomerAsync(Guid id)
        {
            //TODO: Удаление клиента вместе с выданными ему промокодами
            var result = await _customerService.DeleteAsync(id);

            if (result)
                return NoContent();

            return NotFound();
        }
    }
}