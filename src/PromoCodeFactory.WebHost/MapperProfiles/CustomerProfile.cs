using AutoMapper;
using PromoCodeFactory.Core.Services.Contracts.Customer;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.MapperProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CreateOrEditCustomerRequest, CustomerCreateOrEditDto>();
            CreateMap<CustomerShortDto, CustomerShortResponse>();
            CreateMap<CustomerDto, CustomerResponse>();
        }
    }
}
