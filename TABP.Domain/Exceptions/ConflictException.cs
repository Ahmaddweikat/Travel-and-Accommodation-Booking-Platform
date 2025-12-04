namespace TABP.Domain.Exceptions
{
    public class ConflictException(string message) : CustomException(message)
    {
        public override string Error()
        {
            return "Conflict";
        }
    }
}