using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItem
{
    public class GetSaleItemHandler : IRequestHandler<GetSaleItemCommand, GetSaleItemResult>
    {
        private readonly ISaleItemRepository _saleItemRepository;
        private readonly IMapper _mapper;

        public GetSaleItemHandler(ISaleItemRepository saleItemRepository, IMapper mapper)
        {
            _saleItemRepository = saleItemRepository;
            _mapper = mapper;
        }

        public async Task<GetSaleItemResult> Handle(GetSaleItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetSaleItemCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var saleItem = await _saleItemRepository.GetByIdAsync(request.Id, cancellationToken);
            if (saleItem == null)
                throw new KeyNotFoundException($"SaleItem with id {request.Id} not found");

            return _mapper.Map<GetSaleItemResult>(saleItem);
        }
    }
}
