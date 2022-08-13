namespace UTFPR.PoliciaMovel.Application.Exceptions
{
    public class InvalidUserLoginException : Exception
    {
        public InvalidUserLoginException(string message) : base(message)
        {
        }
    }
}

