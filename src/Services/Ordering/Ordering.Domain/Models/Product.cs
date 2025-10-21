using Ordering.Domain.Abstractions;
using Ordering.Domain.ValueObjects;

namespace Ordering.Domain.Models
{
    public class Product : Entity<ProductId>
    {
        public string Name { get; private set; } = default!;
        public decimal Price { get; private set; } = default!;

        public Product CreateCustomer(ProductId customerId, string name, decimal price)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

            var product = new Product
            {
                Id = customerId,
                Name = name,
                Price = price
            };

            return product;
        }
    }
}
