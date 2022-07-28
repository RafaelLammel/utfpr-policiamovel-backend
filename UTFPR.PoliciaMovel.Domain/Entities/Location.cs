namespace UTFPR.PoliciaMovel.Domain.Entities
{
    public class Location : Entity
    {
        public string UserId {get; set;}
        public string Latitute { get; set; }
        public string Longitude { get; set; }
    }
}