using Ambev.DeveloperEvaluation.Application.Branches.CreateBranch;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.CreateBranch
{
    public class CreateBrancheProfile : Profile
    {
        public CreateBrancheProfile()
        {
            CreateMap<CreateBrancheRequest, CreateBranchCommand>();
            CreateMap<CreateBranchResult, CreateBrancheResponse>();
        }
    }
}
