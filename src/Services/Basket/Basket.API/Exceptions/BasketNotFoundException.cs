namespace Basket.API.Exceptions
{
    public class BasketNotFoundException : Exception
    {
        public BasketNotFoundException(string userName) : base("Basket") { }
    }
}
