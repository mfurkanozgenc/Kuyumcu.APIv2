using MediatR;
using System.Net.Http.Headers;
using TS.Result;

namespace Kuyumcu.API.Application.Features.ProductCategories.GetAllCategoryByBranchId
{
    public sealed class GetAllCategoryByBranchIdQuery : IRequest<Result<List<ProductHeaderValue>>>
    {
        public Guid BranchId;
    }

    internal sealed class GetAllCategoryByBranchIdQuery() : IRequestHandler,
}
