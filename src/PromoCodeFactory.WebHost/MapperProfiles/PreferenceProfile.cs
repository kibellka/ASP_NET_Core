using AutoMapper;
using PromoCodeFactory.Core.Services.Contracts.Preference;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.MapperProfiles
{
    public class PreferenceProfile : Profile
    {
        public PreferenceProfile()
        {
            CreateMap<PreferenceDto, PreferenceResponse>();
            //	CreateMap<PreferenceResponse, PreferenceDto>();
    
        }
    }
}
