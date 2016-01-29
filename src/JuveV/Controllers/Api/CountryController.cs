using DataAccess.Contracts;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace JuveV.Controllers.Api
{
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _repository;
        private readonly ILogger<CountryController> _logger;

        public CountryController(ICountryRepository repository, ILogger<CountryController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return Json(_repository.GetList());
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(_repository.GetById(id));
        }
    }
}
