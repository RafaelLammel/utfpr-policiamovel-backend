namespace UTFPR.PoliciaMovel.Domain.Entities
{
    public class Location : Entity
    {
        public string UserId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime LastPutDate { get; set; }
    }
}