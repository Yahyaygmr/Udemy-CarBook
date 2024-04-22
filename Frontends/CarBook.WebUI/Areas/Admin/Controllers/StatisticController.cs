using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/{controller}/{action}/{id?}")]
    public class StatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
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

            #region BlogCount
            var valueBlogCount = GetStatisticAsync(client, "GetBlogCount");
            ViewBag.blogCount = valueBlogCount.Result.result.blogCount;
            ViewBag.blogCountRandom = random.Next(0, 101);
            #endregion

            #region AvgRentPriceForDaily
            var valueAvgRentPriceForDaily = GetStatisticAsync(client, "GetAvgRentPriceForDaily");
            ViewBag.avgRentPriceForDaily = Convert.ToInt32(valueAvgRentPriceForDaily.Result.result.avgRentPriceForDaily);
            ViewBag.avgRentPriceForDailyRandom = random.Next(0, 101);
            #endregion

            #region AvgRentPriceForWeekly
            var valueAvgRentPriceForWeekly = GetStatisticAsync(client, "GetAvgRentPriceForWeekly");
            ViewBag.avgRentPriceForWeekly = Convert.ToInt32(valueAvgRentPriceForWeekly.Result.result.avgRentPriceForWeekly);
            ViewBag.avgRentPriceForWeeklyRandom = random.Next(0, 101);
            #endregion

            #region AvgRentPriceForMonthly
            var valueAvgRentPriceForMonthly = GetStatisticAsync(client, "GetAvgRentPriceForMounthly");
            ViewBag.avgRentPriceForMonthly = Convert.ToInt32(valueAvgRentPriceForMonthly.Result.result.avgRentPriceForMounthly);
            ViewBag.avgRentPriceForMonthlyRandom = random.Next(0, 101);
            #endregion

            #region CarCountByTransmissionAuto
            var valueCarCountByTransmissionAuto = GetStatisticAsync(client, "GetCarCountByTransmissionIsAuto");
            ViewBag.carCountByTransmissionAuto = valueCarCountByTransmissionAuto.Result.result.carCountByTransmissionIsAuto;
            ViewBag.carCountByTransmissionAutoRandom = random.Next(0, 101);
            #endregion

            #region BrandNameByMaxCar
            var valueBrandNameByMaxCar = GetStatisticAsync(client, "BrandNameByMaxCar");
            ViewBag.brandNameByMaxCar = valueBrandNameByMaxCar.Result.result.brandNameByMaxCar;
            ViewBag.brandNameByMaxCarRandom = random.Next(0, 101);
            #endregion

            #region BlogTitleByMaxBlogComment
            //var valueBlogTitleByMaxBlogComment = GetStatisticAsync(client, "BlogTitleByMaxBlogComment");
            //ViewBag.blogTitleByMaxBlogComment = valueBlogTitleByMaxBlogComment.Result.result.blogTitleByMaxBlogComment;
            //ViewBag.blogTitleByMaxBlogCommentRandom = random.Next(0, 101);
            #endregion

            #region CarCountWithLessThan1000Kilometers
            var valueCarCountWithLessThan1000Kilometers = GetStatisticAsync(client, "GetCarCountWithLessThan1000Kilometers");
            ViewBag.carCountWithLessThan1000Kilometers = valueCarCountWithLessThan1000Kilometers.Result.result.carCountWithLessThan1000Kilometers;
            ViewBag.carCountWithLessThan1000KilometersRandom = random.Next(0, 101);
            #endregion

            #region CarCountByFuelGasolineOrDiesel
            var valueCarCountByFuelGasolineOrDiesel = GetStatisticAsync(client, "GetCarCountByFuelGasolineOrDiesel");
            ViewBag.carCountByFuelGasolineOrDiesel = valueCarCountByFuelGasolineOrDiesel.Result.result.carCountByFuelGasolineOrDiesel;
            ViewBag.carCountByFuelGasolineOrDieselRandom = random.Next(0, 101);
            #endregion

            #region CountByFuelElectric
            var valueCountByFuelElectric = GetStatisticAsync(client, "GetCountByFuelElectric");
            ViewBag.countByFuelElectric = valueCountByFuelElectric.Result.result.countByFuelElectric;
            ViewBag.countByFuelElectricRandom = random.Next(0, 101);
            #endregion

            #region CarBrandAndModelByDailyRentPriceMax
            var valueCarBrandAndModelByDailyRentPriceMax = GetStatisticAsync(client, "GetCarBrandAndModelByDailyRentPriceMax");
            ViewBag.carBrandAndModelByDailyRentPriceMax = valueCarBrandAndModelByDailyRentPriceMax.Result.result.carBrandAndModelByDailyRentPriceMax;
            ViewBag.carBrandAndModelByDailyRentPriceMaxRandom = random.Next(0, 101);
            #endregion

            #region CarBrandAndModelByDailyRentPriceMin
            var valueCarBrandAndModelByDailyRentPriceMin = GetStatisticAsync(client, "GetCarBrandAndModelByDailyRentPriceMin");
            ViewBag.carBrandAndModelByDailyRentPriceMin = valueCarBrandAndModelByDailyRentPriceMin.Result.result.carBrandAndModelByDailyRentPriceMin;
            ViewBag.carBrandAndModelByDailyRentPriceMinRandom = random.Next(0, 101);
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
