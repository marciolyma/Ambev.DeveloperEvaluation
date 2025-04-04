using Ambev.DeveloperEvaluation.Application.Branches.CreateBranch;
using Ambev.DeveloperEvaluation.Application.Branches.GetBranch;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch;
using Ambev.DeveloperEvaluation.WebApi.Features.Branches.GetBranch;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches
{
    [Authorize]
    [Route("api/[controller]")]
    public class BranchesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BranchesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateBrancheResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(CreateBrancheResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBranch([FromBody] CreateBrancheRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateBrancheRequestValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors);
            var command = _mapper.Map<CreateBranchCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);
            return Created(string.Empty, new ApiResponseWithData<CreateBrancheResponse>
            {
                Success = true,
                Message = "Branch created successfully",
                Data = _mapper.Map<CreateBrancheResponse>(response)
            });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetBranchResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBranch(Guid id, CancellationToken cancellationToken)
        {
            var request = new GetBranchRequest { Id = id };
            var validator = new GetBranchRequestValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors);
            var command = _mapper.Map<GetBranchCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);
            var mappedResponse = _mapper.Map<GetBranchResponse>(response);
            return Ok(new ApiResponseWithData<GetBranchResponse>
            {
                Success = true,
                Message = "Branch retrieved successfully",
                Data = _mapper.Map<GetBranchResponse>(response)
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBranch(Guid id, CancellationToken cancellationToken)
        {
            var request = new GetBranchRequest { Id = id };
            var validator = new GetBranchRequestValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors);
            var command = _mapper.Map<GetBranchCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Branch deleted successfully"
            });
        }
    }
}
