using CarBook.Dto.FooterAdressDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/{controller}/{action}/{id?}")]
    public class FooterAdressController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FooterAdressController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44386/api/FooterAdresses");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFooterAdressDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateFooterAdress()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterAdress(CreateFooterAdressDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44386/api/FooterAdresses", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FooterAdress");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateFooterAdress(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44386/api/FooterAdresses/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFooterAdressDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFooterAdress(UpdateFooterAdressDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);

            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44386/api/FooterAdresses/", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FooterAdress");
            }
            return View();
        }
        public async Task<IActionResult> RemoveFooterAdress(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44386/api/FooterAdresses/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FooterAdress");
            }
            return View();
        }
    }
}
