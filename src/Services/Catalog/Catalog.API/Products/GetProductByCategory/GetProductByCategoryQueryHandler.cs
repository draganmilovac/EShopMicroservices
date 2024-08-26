using Marten.Linq.QueryHandlers;

namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryQueryResponse>;
    public record GetProductByCategoryQueryResponse(IEnumerable<Product> Products);
    public class GetProductByCategoryQueryHandler (IDocumentSession session)
        : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryQueryResponse>
    {
        public async Task<GetProductByCategoryQueryResponse> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>()
                .Where(x => x.Category.Contains(query.Category))
                .ToListAsync();

            return new GetProductByCategoryQueryResponse(products);
        }
    }
}
