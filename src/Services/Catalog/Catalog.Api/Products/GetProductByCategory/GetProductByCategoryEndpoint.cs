using Carter;
using Catalog.Api.Models;
using Catalog.Api.Products.GetProducts;
using Mapster;
using MediatR;

namespace Catalog.Api.Products.GetProductByCategory
{
    public class GetProductByCategoryEndpoint : ICarterModule
    {
        public record GetProductByCategoryResult(IEnumerable<Product> Products);
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCategoryQuery(category));

                var response = result.Adapt<GetProductByCategoryResult>();

                return Results.Ok(response);
            })
                .WithName("GetProductByCategory")
                .Produces<GetProductsResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithDescription("Get product by category")
                .WithSummary("Get product by category");
        }
    }
}
