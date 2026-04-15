using Microsoft.AspNetCore.Mvc;

namespace CoreFitness.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}