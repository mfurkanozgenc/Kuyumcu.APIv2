using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Branches.Commands.DeleteBranchById
{
    public sealed record DeleteBranchByIdCommand(Guid Id) : IRequest<Result<string>>;
}
