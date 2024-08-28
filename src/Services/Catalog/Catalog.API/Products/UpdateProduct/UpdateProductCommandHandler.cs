
using FluentValidation;

namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommandRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<UpdateProductCommandResponse>;
    public record UpdateProductCommandResponse(bool IsSuccess);

    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
                .Length(2, 150).WithMessage("Nume must be between 2 and 150 characters");

            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greather than 0");
        }
    }
    public class UpdateProductCommandHandler(IDocumentSession session)
        : ICommandHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest command, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
            if (product is null)
            {
                throw new ProductNotFoundException(command.Id);
            }
            product.Name = command.Name;
            product.Category = command.Category;
            product.Description = command.Description;
            product.ImageFile = command.ImageFile;
            product.Price = command.Price;

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);
            return new UpdateProductCommandResponse(true);
        }
    }
}
