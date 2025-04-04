using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events.Branches
{
    public class BranchCreatedEvent : INotification
    {
        public BranchCreatedEvent(Branch branch)
        {
            Branch = branch;
        }

        public Branch Branch { get; }


    }
}
