using Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace CRUD.Controllers
{
    // Below route is added in "204. Attribute Routing"
    // [Route("persons")] 
    // Above is updated in "204. Attribute Routing"
    [Route("[controller]")]
    public class PersonsController : Controller
    {
        private readonly IPersonService _personService;
        private readonly ICountryService _countryService;

        public PersonsController(IPersonService personService, ICountryService countryService)
        {
            _personService = personService;
            _countryService = countryService;
        }

        //[Route("persons/index")]
        // Above is updated in "204. Attribute Routing"
        // [Route("index")]
        // Above is updated in "204. Attribute Routing"
        [Route("[action]")]
        [Route("/")]
        public IActionResult Index(
            string searchBy, 
            string? searchString,
            string sortBy = nameof(PersonResponse.Name),
            SortOrderOptions sortOrder = SortOrderOptions.ASC
        )
        {
            ViewBag.SearchFields = new Dictionary<string, string>()
            {
                { nameof(PersonResponse.Name) , "Person Name"},
                { nameof(PersonResponse.Email) , "Email"},
                { nameof(PersonResponse.DateOfBirth) , "Date Of Birth"},
                { nameof(PersonResponse.Gender) , "Gender"},
                { nameof(PersonResponse.CountryID) , "Country"},
                { nameof(PersonResponse.Address) , "Address"}
            };

            List<PersonResponse> allPersons = 
                _personService.GetFilteredPerson(searchBy, searchString);

            ViewBag.currentSearchBy = searchBy;
            ViewBag.currentSearchString = searchString;

            List<PersonResponse> sortedPersons = 
                _personService.GetSortedPersons(allPersons, sortBy, sortOrder);

            ViewBag.currentSortBy = sortBy;
            ViewBag.currentSortOrder = sortOrder;


            return View(sortedPersons);
        }

        // [Route("persons/create")]
        // Above is updated in "204. Attribute Routing"
        // [Route("create")]
        // Above is updated in "204. Attribute Routing"
        [Route("[action]")]
        [HttpGet]
        public IActionResult Create()
        {

            List<CountryResponse> allCountries = _countryService.GetAllCountries();
            ViewBag.Countries = allCountries;
            return View();
        }

        [HttpPost]
        // [Route("persons/create")] 
        // Above is updated in "204. Attribute Routing"
        // [Route("create")]
        // Above is updated in "204. Attribute Routing"
        [Route("[action]")]
        public IActionResult Create(PersonAddRequest personAddRequest)
        { 
            if (!ModelState.IsValid)
            {
                List<CountryResponse> countries = _countryService.GetAllCountries();
                ViewBag.Countries = countries;

                ViewBag.Errors = ModelState.Values.
                    SelectMany(values => values.Errors).
                    ToList().SelectMany(error => error.ErrorMessage).ToList();

                return View();
            }
            
            PersonResponse personResponse = _personService.AddPerson(personAddRequest);


            return RedirectToAction("Index", "Persons");
        }
    }
}
