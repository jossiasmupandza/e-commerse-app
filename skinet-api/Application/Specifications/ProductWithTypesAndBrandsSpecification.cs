using System;
using System.Linq.Expressions;
using Domain;

namespace Application.Specifications
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification(SpecParams specParams) :
            base(x => 
                (!specParams.BrandId.HasValue || x.ProductBrandId == specParams.BrandId) 
                && (!specParams.TypeId.HasValue || x.ProductTypeId == specParams.TypeId)
            )
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddOrderBy(x => x.Name);
            ApplyPaging( specParams.PageSize * (specParams.PageIndex -1),specParams.PageSize);

            if (specParams.Sort != null)
            {
                switch (specParams.Sort)
                {
                    case "nameDesc":
                        AddOrderByDescending(x => x.Name);
                        break;
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    default: 
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }

        public ProductWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}