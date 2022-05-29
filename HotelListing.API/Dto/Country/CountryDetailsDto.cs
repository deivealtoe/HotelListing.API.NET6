using HotelListing.API.Dto.Hotel;
using HotelListing.API.Models;

namespace HotelListing.API.Dto.Country
{
    public class CountryDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ShortName { get; set; } = null!;
        public HashSet<HotelDto>? Hotels { get; set; }
    }
}
