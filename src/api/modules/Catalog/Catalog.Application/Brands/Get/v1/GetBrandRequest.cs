using MediatR;

namespace PayCom.WebApi.Catalog.Application.Brands.Get.v1;
public class GetBrandRequest : IRequest<BrandResponse>
{
    public Guid Id { get; set; }
    public GetBrandRequest(Guid id) => Id = id;
}
