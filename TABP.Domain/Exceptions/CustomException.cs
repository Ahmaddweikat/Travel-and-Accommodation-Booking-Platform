namespace TABP.Domain.Exceptions
{
    public class CustomException(string message) : Exception(message)
    {
        public virtual string Error()
        {
            return "Exception";
        }
    }
}