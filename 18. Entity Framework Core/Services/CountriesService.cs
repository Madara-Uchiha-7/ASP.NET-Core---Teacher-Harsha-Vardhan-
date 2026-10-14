using ServiceContracts;
using ServiceContracts.DTO;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class CountriesService : ICountryService
    {
        private readonly PersonsDbContext _db;

        public CountriesService(PersonsDbContext personsDbContext)
        {
            _db = personsDbContext;
        }

        // public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        // The above line is commented and replaced in "232. Async EF Operations"
        public async Task<CountryResponse> AddCountry(CountryAddRequest? countryAddRequest)
        {
            if (countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            // if (_db.Countries.Count(temp => temp.CountryName == countryAddRequest.CountryName) > 0)
            // The above line is commented and replaced in "232. Async EF Operations"
            // For CountAync, we have added the Microsoft.EntityFrameworkCore;
            // Since we are calling ConuntAsync we have to use the await.
            if (await _db.Countries.CountAsync(temp => temp.CountryName == countryAddRequest.CountryName) > 0)
            {
                throw new ArgumentException("Country Name Already Exists.");
            }

            Country country = countryAddRequest.ToCountry();

            country.CountryID = Guid.NewGuid();

            _db.Countries.Add(country);

            //_db.SaveChanges();
            // The above line is commented and replaced in "232. Async EF Operations
            await _db.SaveChangesAsync();

            return country.ToCountryResponse();

        }

        // public List<CountryResponse> GetAllCountries()
        // The above line is commented and replaced in "232. Async EF Operations"
        public async Task<List<CountryResponse>> GetAllCountries()
        {
            //return _db.Countries.Select(country => country.ToCountryResponse()).ToList();
            // The above line is commented and replaced in "232. Async EF Operations"
            return await _db.Countries.Select(country => country.ToCountryResponse()).ToListAsync();
        }

        // public CountryResponse? GetCountryByCountryID(Guid? countryID)
        // The above line is commented and replaced in "232. Async EF Operations"
        public async Task<CountryResponse?> GetCountryByCountryID(Guid? countryID)
        {
            if (countryID == null)
            {
                return null;
            }

            //Country? countryResponseFromContries = _db.Countries.FirstOrDefault(country =>

            //    country.CountryID == countryID
            //);
            // The above line is commented and replaced in "232. Async EF Operations"

            Country? countryResponseFromContries = await _db.Countries.FirstOrDefaultAsync(country =>

                country.CountryID == countryID
            );

            if (countryResponseFromContries == null)
            {
                return null;
            }

            return countryResponseFromContries?.ToCountryResponse();
        }
    }
}
