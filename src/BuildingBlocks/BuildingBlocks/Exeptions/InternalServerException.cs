namespace BuildingBlocks.Exeptions
{
    public class InternalServerException : Exception
    {
        public InternalServerException(string message)
            : base(message)
        {

        }
        public InternalServerException(string message, string details)
            : base(message)
        {
            Detalis = details;
        }
        public string? Detalis { get; }
    }
}
