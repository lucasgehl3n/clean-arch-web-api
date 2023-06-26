namespace clean_arch_web_api.Domain.Exceptions
{
    public class BusinessRule : Exception
    {
        public BusinessRule(string? message) : base(message)
        {
        }
    }
}
