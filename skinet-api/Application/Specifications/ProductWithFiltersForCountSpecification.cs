using Domain;

namespace Application.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(SpecParams specParams) :
            base(x => 
                (string.IsNullOrEmpty(specParams.Search) || x.Name.ToLower().Contains(specParams.Search)) &&
                (!specParams.BrandId.HasValue || x.ProductBrandId == specParams.BrandId) 
                && (!specParams.TypeId.HasValue || x.ProductTypeId == specParams.TypeId)
            )
        {
        }
    }
}