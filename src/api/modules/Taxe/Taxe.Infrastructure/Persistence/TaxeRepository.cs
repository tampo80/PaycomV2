using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using FSH.Framework.Core.Domain.Contracts;
using FSH.Framework.Core.Persistence;
using Mapster;

namespace PayCom.WebApi.Taxe.Infrastructure.Persistence;

internal sealed class TaxeRepository<T> :  RepositoryBase<T>, IReadRepository<T>, IRepository<T>
    where T : class, IAggregateRoot
{
    public TaxeRepository(TaxeDbContext dbContext) : base(dbContext)
    { }
    
    protected override IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification) =>
        specification.Selector is not null
            ? base.ApplySpecification(specification)
            : ApplySpecification(specification, false)
                .ProjectToType<TResult>();
}
