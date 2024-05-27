using Kuyumcu.API.Domain.Entities;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Branches.Queries.GetBranchById
{
    public sealed record GetAllBranchByIdQuery(Guid Id) : IRequest<Result<Branch>>;
}
