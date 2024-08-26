namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommandRequest(Guid Id) : ICommand<DeleteProductCommandResponse>;
    public record DeleteProductCommandResponse(bool IsSuccess);
    public class DeleteProductCommandHandler(IDocumentSession session)
        : ICommandHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
    {
        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest command, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);
            if (product is null)
            {
                throw new ProductNotFoundException(command.Id);
            }

            session.Delete(product);
            await session.SaveChangesAsync(cancellationToken);
            return new DeleteProductCommandResponse(true);
        }
    }
}
