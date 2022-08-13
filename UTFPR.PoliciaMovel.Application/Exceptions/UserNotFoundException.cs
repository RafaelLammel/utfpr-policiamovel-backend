namespace UTFPR.PoliciaMovel.Application.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
        {
        }
        
        public UserNotFoundException(string msg) : base(msg)
        {
        }
    }
}
