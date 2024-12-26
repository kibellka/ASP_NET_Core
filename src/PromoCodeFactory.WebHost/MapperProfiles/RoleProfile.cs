using AutoMapper;
using PromoCodeFactory.Core.Services.Contracts;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.MapperProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDto, RoleItemResponse>();
        }
    }
}
