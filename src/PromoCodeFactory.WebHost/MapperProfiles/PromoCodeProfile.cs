using AutoMapper;
using PromoCodeFactory.Core.Services.Contracts;
using PromoCodeFactory.Core.Services.Contracts.PromoCode;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.MapperProfiles
{
    public class PromoCodeProfile : Profile
    {
        public PromoCodeProfile()
        {
            CreateMap<GivePromoCodeRequest, GivePromoCodeDto>();

            CreateMap<PromoCodeShortDto, PromoCodeShortResponse>()
                .ForMember(d => d.BeginDate, map => map.MapFrom(s => s.BeginDate.ToString("yyyy-MM-dd")))
                .ForMember(d => d.EndDate, map => map.MapFrom(s => s.EndDate.ToString("yyyy-MM-dd")));
        }
    }
}
