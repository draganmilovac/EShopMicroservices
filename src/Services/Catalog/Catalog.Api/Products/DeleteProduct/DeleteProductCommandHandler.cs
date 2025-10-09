using BuildingBlocks.CQRS;
using Catalog.Api.Models;
using FluentValidation;
using Marten;

namespace Catalog.Api.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductCommandResult>;
    public record DeleteProductCommandResult(bool IsSuccess);

    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product ID is required");
        }
    }

    public class DeleteProductCommandHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand, DeleteProductCommandResult>
    {
        public async Task<DeleteProductCommandResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

            if (product is null)
            {
                return null;
            }

            session.Delete(product);
            await session.SaveChangesAsync(cancellationToken);

            return new DeleteProductCommandResult(true);
        }
    }
}
