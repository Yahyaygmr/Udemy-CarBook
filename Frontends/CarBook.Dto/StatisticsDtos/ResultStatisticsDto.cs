using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
            public Result result { get; set; }
            public int id { get; set; }
            public object exception { get; set; }
            public int status { get; set; }
            public bool isCanceled { get; set; }
            public bool isCompleted { get; set; }
            public bool isCompletedSuccessfully { get; set; }
            public int creationOptions { get; set; }
            public object asyncState { get; set; }
            public bool isFaulted { get; set; }
        public class Result
        {
            public int carCount { get; set; }
            public int locationCount { get; set; }
            public int authorCount { get; set; }
            public int brandCount { get; set; }
            public int blogCount { get; set; }
            public decimal avgRentPriceForDaily { get; set; }
            public decimal avgRentPriceForWeekly { get; set; }
            public decimal avgRentPriceForMounthly { get; set; }
            public int carCountByTransmissionIsAuto { get; set; }
            public string brandNameByMaxCar { get; set; }
            public string blogTitleByMaxBlogComment { get; set; }
            public int carCountWithLessThan1000Kilometers { get; set; }
            public int carCountByFuelGasolineOrDiesel { get; set; }
            public int countByFuelElectric { get; set; }
            public string carBrandAndModelByDailyRentPriceMax { get; set; }
            public string carBrandAndModelByDailyRentPriceMin { get; set; }

        }

    }
}
