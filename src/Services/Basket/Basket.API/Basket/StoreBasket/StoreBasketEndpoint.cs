using Basket.API.Basket.GetBasket;
using Basket.API.Models;
using Carter;
using Mapster;
using MediatR;

namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketRequest(ShoppingCart Cart);
    public record StoreBasketResponse(string UserName);
    public class StoreBasketEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (StoreBasketRequest storeBasketRequest, ISender sender) =>
            {
                var request = storeBasketRequest.Adapt<StoreBasketCommand>();

                var result = await sender.Send(request);

                var response = result.Adapt<StoreBasketResponse>();

                return Results.Created($"/basket/{response.UserName}", response);

            })
                .WithName("StoreBasket")
                .Produces<StoreBasketResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithDescription("Store basket")
                .WithSummary("Store basket");
        }
    }
}
