using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Dto.Country
{
    public class PutCountryDto
    {
        [Required]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
    }
}
