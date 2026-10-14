using ServiceContracts;
using ServiceContracts.DTO;
using Entities;

namespace Services
{
    public class CountriesService : ICountryService
    {
        private readonly List<Country> _countries;

        public CountriesService(bool initialize = true)
        {
            _countries = new List<Country>();

            if (initialize)
            {
                _countries.AddRange(new List<Country>() 
                {
                    new Country()
                    {
                        CountryID = Guid.Parse("D3EF2298-7BF9-4ED4-8D1E-3D5B9E234D8C"),
                        CountryName = "Bharat"
                    },
                    new Country()
                    {
                        CountryID = Guid.Parse("D0264A93-7546-40EC-8E2E-76946B65CEE8"),
                        CountryName = "Japan"
                    },
                    new Country()
                    {
                        CountryID = Guid.Parse("D2E6659F-EFE5-4000-8BE9-54249454924A"),
                        CountryName = "Germany"
                    },
                    new Country()
                    {
                        CountryID = Guid.Parse("7BB6AA5F-FC92-428F-8E31-B830B170B5DE"),
                        CountryName = "Rassia"
                    },
                    new Country()
                    {
                        CountryID = Guid.Parse("8DC4DD05-A16F-4E00-A6C3-F3543A5F7253"),
                        CountryName = "Isreal"
                    }
                });
            }
        }

        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {
            if (countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            if (_countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
            {
                throw new ArgumentException("Country Name Already Exists.");
            }

            Country country = countryAddRequest.ToCountry();

            country.CountryID = Guid.NewGuid();

            _countries.Add(country);

            return country.ToCountryResponse();

        }

        public List<CountryResponse> GetAllCountries()
        {
            return _countries.Select(country => country.ToCountryResponse()).ToList();
        }

        public CountryResponse? GetCountryByCountryID(Guid? countryID)
        {
            if (countryID == null)
            {
                return null;
            }

            Country? countryResponseFromContries = _countries.FirstOrDefault(country =>
            
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
