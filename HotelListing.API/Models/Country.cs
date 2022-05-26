namespace HotelListing.API.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public HashSet<Hotel>? Hotels { get; set; }
    }
}