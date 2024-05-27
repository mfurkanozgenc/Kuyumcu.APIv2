using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Companies.UpdateCompany
{
    public sealed record UpdateCompanyCommand(
        Guid Id,
        string Name,
        string Address) : IRequest<Result<string>>;
}
