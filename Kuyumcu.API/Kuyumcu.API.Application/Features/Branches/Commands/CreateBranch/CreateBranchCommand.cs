using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Branches.Commands.CreateBranch
{
    public sealed class CreateBranchCommand : IRequest<Result<Guid>>
    {
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;
    }
}
