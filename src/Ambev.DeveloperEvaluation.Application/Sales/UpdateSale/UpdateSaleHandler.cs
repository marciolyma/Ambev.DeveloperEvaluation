using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Seed;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = _mapper.Map<Sale>(command);

            if (sale == null)
                throw new KeyNotFoundException("Sale not found");

            foreach (var item in sale.SaleItems)
            {
                item.Discount = DiscountCalculator.CalculateDiscount(item.Quantity, item.UnitPrice);
            }
            sale.TotalAmount = sale.SaleItems.Sum(i => i.TotalAmount);

            var updatedSale = await _saleRepository.UpdateAsync(sale, cancellationToken);

            var result = _mapper.Map<UpdateSaleResult>(updatedSale);

            return result;

        }
    }
}
