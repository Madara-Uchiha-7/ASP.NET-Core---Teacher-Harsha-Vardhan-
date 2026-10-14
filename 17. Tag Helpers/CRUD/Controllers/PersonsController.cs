using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace CRUD.Controllers
{
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

        [Route("[action]")]
        [HttpGet]
        public IActionResult Create()
        {

            List<CountryResponse> allCountries = _countryService.GetAllCountries();
            ViewBag.Countries = allCountries.Select(country =>
                new SelectListItem()
                {
                    Text = country.CountryName, Value = country.CountryID.ToString()
                }
            ); 
            return View();
        }

        [HttpPost]  
        [Route("[action]")]
        public IActionResult Create(PersonAddRequest personAddRequest)
        { 
            if (!ModelState.IsValid)
            {
                List<CountryResponse> countries = _countryService.GetAllCountries();
                ViewBag.Countries = countries.Select(country =>
                    new SelectListItem()
                    {
                        Text = country.CountryName,
                        Value = country.CountryID.ToString()
                    }
                ); 

                ViewBag.Errors = ModelState.Values.
                    SelectMany(values => values.Errors).
                    ToList().SelectMany(error => error.ErrorMessage).ToList();

                return View();
            }
            
            PersonResponse personResponse = _personService.AddPerson(personAddRequest);


            return RedirectToAction("Index", "Persons");
        }

        [HttpGet]
        [Route("[action]/{personID}")]
        public IActionResult Edit(Guid personID)
        {
            PersonResponse? personResponse = _personService.GetPersonByPersonID(personID);

            if (personResponse == null)
            {
                return RedirectToAction("Index");
            }
            PersonUpdateRequest personUpdateRequest = personResponse.ToPersonUpdateRequest();

            List<CountryResponse> allCountries = _countryService.GetAllCountries();
            ViewBag.Countries = allCountries.Select(country =>
                new SelectListItem()
                {
                    Text = country.CountryName,
                    Value = country.CountryID.ToString()
                }
            );

            return View(personUpdateRequest);
        }

        [HttpPost]
        [Route("[action]/{personID}")]
        public IActionResult Edit(PersonUpdateRequest personUpdateRequest)
        {
            PersonResponse? personResponse =  _personService.GetPersonByPersonID(personUpdateRequest.ID);

            if (personResponse == null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                _personService.UpdatePerson(personUpdateRequest);
                return RedirectToAction("Index");
            }
            else
            {
                List<CountryResponse> countries = _countryService.GetAllCountries();
                ViewBag.Countries = countries.Select(country =>
                    new SelectListItem()
                    {
                        Text = country.CountryName,
                        Value = country.CountryID.ToString()
                    }
                );

                ViewBag.Errors = ModelState.Values.
                    SelectMany(values => values.Errors).
                    ToList().SelectMany(error => error.ErrorMessage).ToList();


                return View(personResponse.ToPersonUpdateRequest());
            } 
        }
        [HttpGet]
        [Route("[action]/{personID}")]
        public IActionResult Delete(Guid? personID)
        {
            PersonResponse? personResponse = _personService.GetPersonByPersonID(personID);

            if (personResponse == null)
            {
                return RedirectToAction("Index");
            }

            return View(personResponse);
        }

        [HttpPost]
        [Route("[action]/{personID}")]
        public IActionResult Delete(PersonUpdateRequest personUpdateRequest)
        {
            PersonResponse? personResponse = _personService.GetPersonByPersonID(personUpdateRequest.ID);

            if (personResponse == null)
            {
                return RedirectToAction("Index");
            }

            _personService.DeletePerson(personUpdateRequest.ID);
            return RedirectToAction("Index");
        }
    }
}
