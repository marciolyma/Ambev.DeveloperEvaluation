using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct
{
    public class GetProductProfile : Profile
    {
        public GetProductProfile()
        {
            CreateMap<Guid, GetProductCommand>()
                .ConstructUsing(id => new GetProductCommand(id));

            CreateMap<GetProductRequest, GetProductCommand>();
            CreateMap<GetProductResult, GetProductResponse>();
        }
    }
}
