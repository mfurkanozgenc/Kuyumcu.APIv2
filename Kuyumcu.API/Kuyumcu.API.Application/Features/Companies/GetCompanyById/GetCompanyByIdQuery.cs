using Kuyumcu.API.Domain.Entities;
using MediatR;
using TS.Result;

namespace Kuyumcu.API.Application.Features.Companies.GetAllCompany
{
    public sealed record GetCompanyByIdQuery (Guid Id) : IRequest<Result<Company>>;
}
