using DataAccess.Contracts;
using DataAccess.Domain;
using Microsoft.AspNet.Mvc;

namespace JuveV.Controllers
{
    public class AdminController : Controller
    {
        private readonly IPlayerTypeRepository<PlayerType> _repository;

        public AdminController(IPlayerTypeRepository<PlayerType> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PlayerTypes()
        {
            return View();
        }

        public IActionResult Teams()
        {
            return View();
        }

    }
}