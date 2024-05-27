using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Companies.DeleteCompany
{
    public sealed record DeleteCompanyByIdCommand(Guid Id) : IRequest<Result<string>>;
}
 