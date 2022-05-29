using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Dto.Country
{
    public class CreateCountryDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string ShortName { get; set; } = null!;
    }
}
