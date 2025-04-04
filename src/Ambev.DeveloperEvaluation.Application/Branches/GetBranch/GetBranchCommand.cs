﻿using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.GetBranch
{
    public class GetBranchCommand : IRequest<GetBranchResult>
    {
        public Guid Id { get; set; }
        public GetBranchCommand(Guid id)
        {
            Id = id;
        }
    }
}
