using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Services.Abstractions;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Предпочтения
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PreferencesController
        : ControllerBase
    {
        private readonly IMapper _mapper;
        private IPreferenceService _preferenceService;

        public PreferencesController(IMapper mapper, IPreferenceService preferenceService)
        {
            _mapper = mapper;
            _preferenceService = preferenceService;
        }

        /// <summary>
        /// Получить все предпочтения.
        /// </summary>
        /// <returns>Предпочтения.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<PreferenceResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyCollection<PreferenceResponse>>> GetPreferencesAsync()
        {
            var preferences = await _preferenceService.GetAllAsync();
            var result = _mapper.Map<IReadOnlyCollection<PreferenceResponse>>(preferences);

            return Ok(result);
        }
    }
}
