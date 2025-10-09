using BuildingBlocks.CQRS;
using Catalog.Api.Exceptions;
using Catalog.Api.Models;
using Marten;

namespace Catalog.Api.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdQueryResult>;
    public record GetProductByIdQueryResult(Product Product);
    public class GetProductByIdQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetProductByIdQueryResult>
    {
        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

            if(product == null)
            {
                throw new ProductNotFoundException(query.Id);
            }

            return new GetProductByIdQueryResult(product);
        }
    }
}
