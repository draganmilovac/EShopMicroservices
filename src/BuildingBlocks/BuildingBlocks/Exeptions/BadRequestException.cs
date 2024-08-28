namespace BuildingBlocks.Exeptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message)
            : base(message) { }
        public BadRequestException(string message, string details)
            : base(message)
        {
            Detalis = details;
        }
        public string? Detalis
        {
            get;
        }
    }
}
