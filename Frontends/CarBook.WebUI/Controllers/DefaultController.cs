using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Drawing.Text;

namespace CarBook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;  
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.locations =await LocationsSelectListAsync();
            return View();
        }
        [HttpPost]
        public IActionResult Index(string book_pick_date,string book_off_date,string time_pick, string time_off, string locationId)
        {
            TempData["book_pick_date"] = book_pick_date;
            TempData["book_off_date"] = book_off_date;
            TempData["time_pick"] = time_pick;
            TempData["time_off"] = time_off;
            TempData["locationId"] = locationId;

            return RedirectToAction("Index","RentACar");
        }
        private async Task<List<ResultLocationDto>> GetLocationsAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44386/api/Locations");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                return values;
            }
            return new List<ResultLocationDto>();
        }
        private async Task<List<SelectListItem>> LocationsSelectListAsync()
        {
            var list =await GetLocationsAsync();
            List<SelectListItem> value = (from x in list
                                          select new SelectListItem
                                          {
                                              Text = x.Name,
                                              Value = x.LocationId.ToString()
                                          }).ToList();
            return value;
        }
    }
}
