using DataAccess.Contracts;
using DataAccess.Domain;
using Microsoft.AspNet.Mvc;

namespace JuveV.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlayerTypeRepository<PlayerType> _repository;

        public HomeController(IPlayerTypeRepository<PlayerType> repository)
        {
            _repository = repository;
        }

        public string Index()
        {
            var playerTypes = _repository.GetList();
            return "Hello from controller: Index";
        }

        public IActionResult PlayerTypes()
        {
            return View();
        }
    }
}