using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products
{
    public class ProductsController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            var command = _mapper.Map<CreateProductCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);
            return Created(string.Empty, new ApiResponseWithData<CreateProductResponse>
            {
                Success = true,
                Data = _mapper.Map<CreateProductResponse>(response),
                Message = "Product created successfully",
            });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            var command = _mapper.Map<UpdateProductCommand>(request);
            command.Id = id;
            var response = await _mediator.Send(command, cancellationToken);
            if (response == null)
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Product not found",
                });
            return Ok(new ApiResponseWithData<UpdateProductResponse>
            {
                Success = true,
                Data = _mapper.Map<UpdateProductResponse>(response),
                Message = "Product updated successfully",
            });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetProductRequest { Id = id };
            var validator = new GetProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            var command = _mapper.Map<GetProductCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);
            if (response == null)
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Product not found",
                });
            var mappedResponse = _mapper.Map<GetProductResponse>(response);
            return Ok(new ApiResponseWithData<GetProductResponse>
            {
                Success = true,
                Data = mappedResponse,
                Message = "Product retrieved successfully",
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteProductRequest { Id = id };
            var validator = new DeleteProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            var command = _mapper.Map<DeleteProductCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);
            if (response == null)
                return NotFound(new ApiResponse
                {
                    Success = false,
                    Message = "Product not found",
                });
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Product deleted successfully",
            });
        }

    }
}
