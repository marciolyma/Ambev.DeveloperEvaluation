using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;

        public DeleteProductHandler(IProductRepository productRepository, IMediator mediator)
        {
            _productRepository = productRepository;
            _mediator = mediator;
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteProductValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            var success = await _productRepository.DeleteAsync(request.Id, cancellationToken);
            if(!success)
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");

            return new DeleteProductResponse { Success = success };

        }
    }
}
