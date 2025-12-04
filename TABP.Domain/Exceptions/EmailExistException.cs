namespace TABP.Domain.Exceptions
{
    public class EmailExistException(string message) : ConflictException(message)
    {
        public override string Error()
        {
            return "The email already exists. Please try another one.";
        }
    }
}