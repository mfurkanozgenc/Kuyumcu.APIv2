using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Companies.CreateCompany
{
    public sealed record CreateCompanyCommand(
        string Name,
        string Address) : IRequest<Result<Guid>>;
}
