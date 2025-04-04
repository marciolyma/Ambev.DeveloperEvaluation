using Ambev.DeveloperEvaluation.Application.Customers.GetCustomer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Customers.GetCustomer
{
    public class GetCustomerProfile : Profile
    {
        public GetCustomerProfile()
        {
            CreateMap<GetCustomerRequest, GetCustomerCommand>();
            CreateMap<GetCustomerResult, GetCustomerResponse>();
        }
    }
}
