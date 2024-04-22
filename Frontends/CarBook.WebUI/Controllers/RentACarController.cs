using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class RentACarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
