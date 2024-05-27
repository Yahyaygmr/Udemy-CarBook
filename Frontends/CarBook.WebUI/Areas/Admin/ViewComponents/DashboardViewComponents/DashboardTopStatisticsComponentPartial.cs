using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.Areas.Admin.ViewComponents.DashboardViewComponents
{
    public class DashboardTopStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardTopStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IViewComponentResult Invoke()
        {
            var client = _httpClientFactory.CreateClient();
            Random random = new Random();


            #region CarCount
            var valueCarCount = GetStatisticAsync(client, "GetCarCount");
            ViewBag.carCount = valueCarCount.Result.result.carCount;
            ViewBag.carCountRandom = random.Next(0, 101);
            #endregion

            #region LocationCount
            var valueLocationCount = GetStatisticAsync(client, "GetLocationCount");
            ViewBag.locationCount = valueLocationCount.Result.result.locationCount;
            ViewBag.locationCountRandom = random.Next(0, 101);
            #endregion

            #region AuthorCount
            var valueAuthorCount = GetStatisticAsync(client, "GetAuthorCount");
            ViewBag.authorCount = valueAuthorCount.Result.result.authorCount;
            ViewBag.authorCountRandom = random.Next(0, 101);
            #endregion

            #region BrandCount
            var valueBrandCount = GetStatisticAsync(client, "GetBrandCount");
            ViewBag.brandCount = valueBrandCount.Result.result.brandCount;
            ViewBag.brandCountRandom = random.Next(0, 101);
            #endregion
            return View();
        }
        public async Task<ResultStatisticsDto> GetStatisticAsync(HttpClient client, string endpoint)
        {
            var responseMessage = await client.GetAsync($"https://localhost:44386/api/Statistics/{endpoint}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                return values;
            }
            throw new Exception();
        }
    }
}
