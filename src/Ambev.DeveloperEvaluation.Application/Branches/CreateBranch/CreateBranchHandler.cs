using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Events.Branches;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.CreateBranch
{
    public class CreateBranchHandler : IRequestHandler<CreateBranchCommand, CreateBranchResult>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateBranchHandler(
            IBranchRepository branchRepository,
            IMapper mapper,
            IMediator mediator)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<CreateBranchResult> Handle(CreateBranchCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateBranchValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
                throw new InvalidCastException(validationResult.Errors.First().ErrorMessage);

            var branch = _mapper.Map<Branch>(command);
            var createdBranch = await _branchRepository.CreateAsync(branch, cancellationToken);
            var result = _mapper.Map<CreateBranchResult>(createdBranch);

            await _mediator.Publish(new BranchCreatedEvent(branch), cancellationToken);

            return result;
        }
    }
}
