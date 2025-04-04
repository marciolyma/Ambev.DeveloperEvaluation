using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.DeleteBranch
{
    public class DeleteBranchCommand : IRequest<DeleteBranchResponse>
    {
        public Guid Id { get; set; }
        public DeleteBranchCommand(Guid id)
        {
            Id = id;
        }
    }
}
