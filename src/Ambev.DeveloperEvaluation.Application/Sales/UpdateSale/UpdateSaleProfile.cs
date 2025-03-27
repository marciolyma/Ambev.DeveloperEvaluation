using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleProfile : Profile
    {
        public UpdateSaleProfile()
        {
            CreateMap<UpdateSaleCommand, Sale>()
                .ForMember(dest => dest.SaleItems, opt => opt.MapFrom(src => src.SaleItems));
        }
    }
}
