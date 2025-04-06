using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Branches.DeleteBranch
{
    public class DeleteBranchHandler : IRequestHandler<DeleteBranchCommand, DeleteBranchResponse>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DeleteBranchHandler(
            IBranchRepository branchRepository,
            IMapper mapper,
            IMediator mediator)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<DeleteBranchResponse> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteBranchCommandValidator();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var success = await _branchRepository.DeleteAsync(request.Id, cancellationToken);
            if (!success)
                throw new KeyNotFoundException($"Branch with ID {request.Id} not found.");

            return new DeleteBranchResponse { Success = true };
        }
    }
}
