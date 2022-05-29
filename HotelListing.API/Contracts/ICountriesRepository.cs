using HotelListing.API.Models;

namespace HotelListing.API.Contracts
{
    public interface ICountriesRepository : IGerenicRepository<Country>
    {
        Task<Country> GetDetails(int id);
    }
}
