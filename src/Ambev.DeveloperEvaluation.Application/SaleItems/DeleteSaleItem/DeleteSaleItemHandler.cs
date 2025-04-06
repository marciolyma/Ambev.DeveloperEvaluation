using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItem
{
    /// <summary>
    /// Handler for the DeleteSaleItemCommand.
    /// </summary>
    public class DeleteSaleItemHandler : IRequestHandler<DeleteSaleItemCommand, DeleteSaleItemResponse>
    {
        private readonly ISaleItemRepository _saleRepository;

        /// <summary>
        /// Initializes a new instance of the DeleteSaleItemHandler class.
        /// </summary>
        /// <param name="saleRepository"></param>
        public DeleteSaleItemHandler(ISaleItemRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        /// <summary>
        /// Handles the DeleteSaleItemCommand request.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        /// <exception cref="KeyNotFoundException"></exception>
        public async Task<DeleteSaleItemResponse> Handle(DeleteSaleItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteSaleItemCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if(!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var success = await _saleRepository.DeleteAsync(request.Id, cancellationToken);
            if(!success)
                throw new KeyNotFoundException("Sale not found");

            return new DeleteSaleItemResponse { Success = true };
        }
    }
}
