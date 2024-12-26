using AutoMapper;
using PromoCodeFactory.Core.Services.Contracts.Employee;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.MapperProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateOrEditEmployeeRequest, EmployeeCreateOrEditDto>();
            CreateMap<EmployeeShortDto, EmployeeShortResponse>();
            CreateMap<EmployeeDto, EmployeeResponse>();
        }
    }
}
