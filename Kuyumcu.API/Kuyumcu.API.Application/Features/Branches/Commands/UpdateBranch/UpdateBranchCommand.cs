using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Branches.Commands.UpdateBranch
{
    public sealed class UpdateBranchCommand : IRequest<Result<string>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Town { get; set; } = string.Empty;
    }
}
