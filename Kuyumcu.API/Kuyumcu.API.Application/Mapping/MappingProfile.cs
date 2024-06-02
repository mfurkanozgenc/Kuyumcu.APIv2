using AutoMapper;
using Kuyumcu.API.Application.Features.Branches.Commands.CreateBranch;
using Kuyumcu.API.Application.Features.Branches.Commands.UpdateBranch;
using Kuyumcu.API.Application.Features.Companies.CreateCompany;
using Kuyumcu.API.Application.Features.Companies.UpdateCompany;
using Kuyumcu.API.Application.Features.ProductCategories.CreateProductCategory;
using Kuyumcu.API.Application.Features.ProductCategories.UpdateProductCategory;
using Kuyumcu.API.Application.Features.Products.CreateProduct;
using Kuyumcu.API.Application.Features.Products.UpdateProduct;
using Kuyumcu.API.Application.Features.ProductTypes.CreateProductType;
using Kuyumcu.API.Application.Features.ProductTypes.UpdateProductTypeCategory;
using Kuyumcu.API.Domain.Entities;

namespace Kuyumcu.API.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyCommand, Company>();
            CreateMap<UpdateCompanyCommand, Company>();

            CreateMap<CreateBranchCommand, Branch>();
            CreateMap<UpdateBranchCommand, Branch>();

            CreateMap<CreateProductCategoryCommand , ProductCategory>();
            CreateMap<UpdateProductCategoryCommand , ProductCategory>();

            CreateMap<CreateProductTypeCommand, ProductType>();
            CreateMap<UpdateProductTypeCommand, ProductType>();

            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}
