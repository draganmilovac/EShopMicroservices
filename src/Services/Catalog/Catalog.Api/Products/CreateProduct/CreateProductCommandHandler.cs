using BuildingBlocks.CQRS;
using Catalog.Api.Models;
using MediatR;

namespace Catalog.Api.Products.CreateProduct
{
    internal record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;
    internal record CreateProductResult(Guid Id);


    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
                Name = command.Name,
            };

            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
