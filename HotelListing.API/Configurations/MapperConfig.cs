using AutoMapper;
using HotelListing.API.Dto.Country;
using HotelListing.API.Dto.Hotel;
using HotelListing.API.Dto.User;
using HotelListing.API.Models;

namespace HotelListing.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CountryDetailsDto>().ReverseMap();
            CreateMap<Country, PutCountryDto>().ReverseMap();
            
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Hotel, CreateHotelDto>().ReverseMap();
            CreateMap<Hotel, HotelDetailsDto>().ReverseMap();
            CreateMap<Hotel, PutHotelDto>().ReverseMap();

            CreateMap<ApiUser, ApiUserDto>().ReverseMap();
        }
    }
}
