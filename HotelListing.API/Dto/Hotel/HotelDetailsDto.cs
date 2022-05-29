using HotelListing.API.Dto.Country;

namespace HotelListing.API.Dto.Hotel
{
    public class HotelDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public double Rating { get; set; }
        public CountryDto Country { get; set; } = null!;
    }
}
