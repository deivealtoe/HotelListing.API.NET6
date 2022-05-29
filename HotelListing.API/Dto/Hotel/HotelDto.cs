namespace HotelListing.API.Dto.Hotel
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public double Rating { get; set; }
    }
}
