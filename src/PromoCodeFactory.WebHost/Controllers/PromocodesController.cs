using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.Core.Services.Abstractions;
using PromoCodeFactory.Core.Services.Contracts.PromoCode;
using PromoCodeFactory.Core.Services.Implementations;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Промокоды
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PromocodesController
        : ControllerBase
    {
        private readonly IMapper _mapper;
        private IPromoCodeService _promoCodeService;

        public PromocodesController(IMapper mapper, IPromoCodeService promoCodeService)
        {
            _mapper = mapper;
            _promoCodeService = promoCodeService;
        }

        /// <summary>
        /// Получить все промокоды
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<PromoCodeShortResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PromoCodeShortResponse>>> GetPromocodesAsync()
        {
            var preferences = await _promoCodeService.GetAllAsync();
            var result = _mapper.Map<IReadOnlyCollection<PromoCodeShortResponse>>(preferences);

            return Ok(result);
        }

        /// <summary>
        /// Создать промокод и выдать его клиентам с указанным предпочтением
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeRequest request)
        {
            //TODO: Создать промокод и выдать его клиентам с указанным предпочтением

            var promocode = _mapper.Map<GivePromoCodeDto>(request);
            await _promoCodeService.GivePromoCodesToCustomersWithPreferenceAsync(promocode);

            return Ok();
        }
    }
}