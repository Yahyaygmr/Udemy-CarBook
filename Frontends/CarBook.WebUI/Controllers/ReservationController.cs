using CarBook.Dto.LocationDtos;
using CarBook.Dto.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.locations = await LocationsSelectListAsync();
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto dto)
        {
            var client = _httpClientFactory.CreateClient();
             var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:44386/api/Reservations", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }

        public async Task<List<ResultLocationDto>> GetLocationsAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44386/api/Locations");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                return values;
            }
            return new List<ResultLocationDto>();
        }
        public async Task<List<SelectListItem>> LocationsSelectListAsync()
        {
            var list = await GetLocationsAsync();
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
