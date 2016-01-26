using DataAccess.Contracts;
using DataAccess.Domain;
using Microsoft.AspNet.Mvc;

namespace JuveV.Controllers
{
    public class AdminController : Controller
    {
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