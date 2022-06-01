using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Dto.User
{
    public class ApiUserDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
