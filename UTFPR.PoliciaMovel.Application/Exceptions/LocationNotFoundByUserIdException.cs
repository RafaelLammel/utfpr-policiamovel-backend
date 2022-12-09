namespace UTFPR.PoliciaMovel.Application.Exceptions
{
    public class LocationNotFoundByUserIdException : Exception
    {
        public LocationNotFoundByUserIdException(string msg) : base(msg)
        {
        }
    }
}

