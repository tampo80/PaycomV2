using Ardalis.Specification;
using PayCom.WebApi.Catalog.Domain;

namespace PayCom.WebApi.Catalog.Application.Products.Get.v1;

public class GetProductSpecs : Specification<Product, ProductResponse>
{
    public GetProductSpecs(Guid id)
    {
        Query
            .Where(p => p.Id == id)
            .Include(p => p.Brand);
    }
}
