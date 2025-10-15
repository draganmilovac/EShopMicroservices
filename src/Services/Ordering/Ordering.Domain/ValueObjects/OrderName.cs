using Ordering.Domain.Exceptions;

namespace Ordering.Domain.ValueObjects
{
    public record OrderName
    {
        public string Value { get; set; }

        private OrderName(string value) => Value = value;

        public static OrderName Of(string value)
        {
            ArgumentException.ThrowIfNullOrEmpty(value);

            return new OrderName(value);
        }
    }
}
