
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductResponse(IEnumerable<Product> Product);
    public class GetProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet($"/products", async (ISender sender) =>
            {
                var query = await sender.Send(new GetProductsQuery());
                var result = query.Adapt<GetProductResponse>();

                return Results.Ok(result);
            })
                .WithName("GetProducts")
                .Produces<CreateProductResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Get all products")
                .WithDescription("Get all products");
        }
    }
}
