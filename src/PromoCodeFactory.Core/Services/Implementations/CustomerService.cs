using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.Core.Services.Abstractions;
using PromoCodeFactory.Core.Services.Contracts.Customer;
using PromoCodeFactory.Core.Services.Contracts.Preference;
using PromoCodeFactory.Core.Services.Contracts.PromoCode;

namespace PromoCodeFactory.Core.Services.Implementations
{
    /// <summary>
    /// Сервис работы с клиентами.
    /// </summary>
    public class CustomerService: ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Preference> _preferenceRepository;
        private readonly IRepository<PromoCode> _promoCodeRepository;

        public CustomerService(
            IRepository<Customer> customerRepository,
            IRepository<Preference> preferenceRepository,
            IRepository<PromoCode> promoCodeRepository)
        {
            _customerRepository = customerRepository;
            _preferenceRepository = preferenceRepository;
            _promoCodeRepository = promoCodeRepository;
        }

        /// <summary>
        /// Получить клиента.
        /// </summary>
        /// <returns>Клиенты.</returns>
        public async Task<IEnumerable<CustomerShortDto>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();

            var result = customers
                .Select(e => new CustomerShortDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email
                });

            return result;
        }

        /// <summary>
        /// Получить клиента.
        /// </summary>
        /// <param name="id">Идентификатор клиента.</param>
        /// <returns>Клиент.</returns>
        public async Task<CustomerDto> GetByIdAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
                return null;

            var result =  new CustomerDto
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Email = customer.Email,
                    Preferences = customer.Preferences.Select(p => new PreferenceDto
                    { 
                        Id = p.Preference.Id,
                        Name = p.Preference.Name
                    }).ToList(),
                    PromoCodes = customer.PromoCodes.Select(p => new PromoCodeShortDto
                    {
                        Id = p.Id, Code = p.Code,
                        ServiceInfo = p.ServiceInfo,
                        BeginDate = p.BeginDate,
                        EndDate = p.EndDate,
                        PartnerName = p.PartnerName
                    }).ToList()
                };

            return result;
        }

        /// <summary>
        /// Создать клиента.
        /// </summary>
        /// <param name="dto">Клиент.</param>
        public async Task<Guid> CreateAsync(CustomerCreateOrEditDto dto)
        {
            var preferences = await _preferenceRepository
             .GetByIdsAsync(dto.PreferenceIds);

            var customer = new Customer()
            {
            //	Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
            };

            customer.Preferences = preferences.Select(x => new CustomerPreference()
            {
                Customer = customer,
                Preference = x
            }).ToList();

            var createdCustomer = await _customerRepository.AddAsync(customer);

            return createdCustomer.Id;
        }

        /// <summary>
        /// Изменить данные клиента.
        /// </summary>
        /// <param name="id">Идентификатор клиента.</param>
        /// <param name="dto">Клиент.</param>
        public async Task<CustomerShortDto> UpdateAsync(Guid id, CustomerCreateOrEditDto dto)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
                return null;

            var preferences = await _preferenceRepository.GetByIdsAsync(dto.PreferenceIds);

            customer.Email = customer.Email;
            customer.FirstName = customer.FirstName;
            customer.LastName = customer.LastName;
            customer.Preferences.Clear();
            customer.Preferences = preferences.Select(x => new CustomerPreference()
                {
                    Customer = customer,
                    Preference = x
                })
                .ToList();

            var updatedCustomer = await _customerRepository.UpdateAsync(customer);
            var result = new CustomerShortDto
            {
                Id = updatedCustomer.Id,
                FirstName = updatedCustomer.FirstName,
                LastName = updatedCustomer.LastName,
                Email = updatedCustomer.Email
            };

            return result;
        }

        /// <summary>
        /// Удалить клиента.
        /// </summary>
        /// <param name="id">Идентификатор клиента.</param>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);

            if (customer == null)
                return false;

            var promocodeIds = customer.PromoCodes.Select(e => e.Id);

            var result = await _customerRepository.DeleteAsync(id);

            foreach (var promocodeId in promocodeIds)
            {
                await _promoCodeRepository.DeleteAsync(promocodeId);
            }

            return result;
        }
    }
}
