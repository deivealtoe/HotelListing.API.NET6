using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Dto.Hotel
{
    public class CreateHotelDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
        [Required]
        [Range(1, int.MaxValue)]
        public int CountryId { get; set; }
    }
}
