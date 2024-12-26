using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.Core.Services.Abstractions;
using PromoCodeFactory.Core.Services.Contracts.PromoCode;

namespace PromoCodeFactory.Core.Services.Implementations
{
    /// <summary>
    /// Cервиса работы с промо-кодами.
    /// </summary>
    public class PromoCodeService : IPromoCodeService
    {
        private readonly IRepository<PromoCode> _promoCodeRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Preference> _preferenceRepository;

        public PromoCodeService(
            IRepository<PromoCode> promoCodeRepository,
            IRepository<Customer> customerRepository,
            IRepository<Employee> employeeRepository,
            IRepository<Preference> preferenceRepository)
        {
            _promoCodeRepository = promoCodeRepository;
            _customerRepository = customerRepository;
            _employeeRepository = employeeRepository;
            _preferenceRepository = preferenceRepository;
        }

        /// <summary>
        /// Получить все промо-коды.
        /// </summary>
        /// <returns>Предпочтения</returns>
        public async Task<IEnumerable<PromoCodeShortDto>> GetAllAsync()
        {
            var promododes = await _promoCodeRepository.GetAllAsync();
            var result = promododes.Select(e => new PromoCodeShortDto
            {
                Id = e.Id,
                Code = e.Code,
                ServiceInfo = e.ServiceInfo,
                BeginDate = e.BeginDate,
                EndDate = e.EndDate,
                PartnerName = e.PartnerName
            });

            return result;
        }

        /// <summary>
        /// Создать промокод и выдать его клиентам с указанным предпочтением
        /// </summary>
        /// <returns></returns>
        public async Task GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeDto dto)
        {
            var preference = (await _preferenceRepository.GetAllAsync()).Where(p => p.Name == dto.Preference).FirstOrDefault();
            if (preference == null)
                return;

            var customers = (await _customerRepository.GetAllAsync()).Where(e => e.Preferences.Select(p => p.Preference.Id).Contains(preference.Id)).ToList();
            if (customers == null || customers.Count == 0)
                return;

            var employee = (await _employeeRepository.GetAllAsync()).FirstOrDefault();

            foreach (var customer in customers)
            {
                var promocode = new PromoCode
                {
                    Id = Guid.NewGuid(),
                    Code = dto.PromoCode,
                    ServiceInfo = dto.ServiceInfo,
                    BeginDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(7),
                    Customer = customer,
                    PartnerManager = employee,
                    PartnerName = dto.PartnerName,
                    Preference = preference
                };

                var result = await _promoCodeRepository.AddAsync(promocode);
            }
        }
    }
}
