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
        //public IActionResult Index(
        //    string searchBy, 
        //    string? searchString,
        //    string sortBy = nameof(PersonResponse.Name),
        //    SortOrderOptions sortOrder = SortOrderOptions.ASC
        //)
        /// The above line is replaced with below in lecture "233. Async Controller Action Methods"
        public async Task<IActionResult> Index(
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

            //List<PersonResponse> allPersons = 
            //    _personService.GetFilteredPerson(searchBy, searchString);
            // The above line is replaced with below in lecture "233. Async Controller Action Methods"
            List<PersonResponse> allPersons =
                await _personService.GetFilteredPerson(searchBy, searchString);

            ViewBag.currentSearchBy = searchBy;
            ViewBag.currentSearchString = searchString;

            //List<PersonResponse> sortedPersons = 
            //    _personService.GetSortedPersons(allPersons, sortBy, sortOrder);
            // The above line is replaced with below in lecture "233. Async Controller Action Methods"
            List<PersonResponse> sortedPersons =
                await _personService.GetSortedPersons(allPersons, sortBy, sortOrder);

            ViewBag.currentSortBy = sortBy;
            ViewBag.currentSortOrder = sortOrder;


            return View(sortedPersons);
        }

        [Route("[action]")]
        [HttpGet]
        //public IActionResult Create()
        // The above line is replaced with below in lecture "233. Async Controller Action Methods"
        public async Task<IActionResult> Create()
        {

            List<CountryResponse> allCountries = await _countryService.GetAllCountries();
            // The above line is replaced with below in lecture "233. Async Controller Action Methods"

            
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
        //public IActionResult Create(PersonAddRequest personAddRequest)
        // The above line is replaced with below in lecture "233. Async Controller Action Methods"
        public async Task<IActionResult> Create(PersonAddRequest personAddRequest)
        {
            if (!ModelState.IsValid)
            {
                //List<CountryResponse> countries = _countryService.GetAllCountries();
                // The above line is replaced with below in lecture "233. Async Controller Action Methods"
                List<CountryResponse> countries = await _countryService.GetAllCountries();
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

            //PersonResponse personResponse = _personService.AddPerson(personAddRequest);
            // The above line is replaced with below in lecture "233. Async Controller Action Methods"
            PersonResponse personResponse = await _personService.AddPerson(personAddRequest);
            
            return RedirectToAction("Index", "Persons");
        }

        [HttpGet]
        [Route("[action]/{personID}")]
        //public IActionResult Edit(Guid personID)
        // The above line is replaced with below in lecture "233. Async Controller Action Methods"
        public async Task<IActionResult> Edit(Guid personID)
        {
            //PersonResponse? personResponse = _personService.GetPersonByPersonID(personID);
            // The above line is replaced with below in lecture "233. Async Controller Action Methods"
            PersonResponse? personResponse = await _personService.GetPersonByPersonID(personID);

            if (personResponse == null)
            {
                return RedirectToAction("Index");
            }
            PersonUpdateRequest personUpdateRequest = personResponse.ToPersonUpdateRequest();

            //List<CountryResponse> allCountries = _countryService.GetAllCountries();
            // The above line is replaced with below in lecture "233. Async Controller Action Methods"
            List<CountryResponse> allCountries = await _countryService.GetAllCountries();

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
        //public IActionResult Edit(PersonUpdateRequest personUpdateRequest)
        // The above line is replaced with below in lecture "233. Async Controller Action Methods"
        public async Task<IActionResult> Edit(PersonUpdateRequest personUpdateRequest)
        {
            //PersonResponse? personResponse =  _personService.GetPersonByPersonID(personUpdateRequest.ID);
            // The above line is replaced with below in lecture "233. Async Controller Action Methods"
            PersonResponse? personResponse = await _personService.GetPersonByPersonID(personUpdateRequest.ID);

            if (personResponse == null)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                //_personService.UpdatePerson(personUpdateRequest);
                // The above line is replaced with below in lecture "233. Async Controller Action Methods"
                await _personService.UpdatePerson(personUpdateRequest);

                return RedirectToAction("Index");
            }
            else
            {
                //List<CountryResponse> countries = _countryService.GetAllCountries();
                // The above line is replaced with below in lecture "233. Async Controller Action Methods"
                List<CountryResponse> countries = await _countryService.GetAllCountries();

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
        //public IActionResult Delete(Guid? personID)
        // The above line is replaced with below in lecture "233. Async Controller Action Methods"
        public async Task<IActionResult> Delete(Guid? personID)
        {
            //PersonResponse? personResponse = _personService.GetPersonByPersonID(personID);
            // The above line is replaced with below in lecture "233. Async Controller Action Methods"
            PersonResponse? personResponse = await _personService.GetPersonByPersonID(personID);

            if (personResponse == null)
            {
                return RedirectToAction("Index");
            }

            return View(personResponse);
        }

        [HttpPost]
        [Route("[action]/{personID}")]
        //public IActionResult Delete(PersonUpdateRequest personUpdateRequest)
        // The above line is replaced with below in lecture "233. Async Controller Action Methods"
        public async Task<IActionResult> Delete(PersonUpdateRequest personUpdateRequest)
        {
            //PersonResponse? personResponse = _personService.GetPersonByPersonID(personUpdateRequest.ID);
            // The above line is replaced with below in lecture "233. Async Controller Action Methods"
            PersonResponse? personResponse = await _personService.GetPersonByPersonID(personUpdateRequest.ID);

            if (personResponse == null)
            {
                return RedirectToAction("Index");
            }

            //_personService.DeletePerson(personUpdateRequest.ID);
            // The above line is replaced with below in lecture "233. Async Controller Action Methods"
            await _personService.DeletePerson(personUpdateRequest.ID);

            return RedirectToAction("Index");
        }
    }
}
