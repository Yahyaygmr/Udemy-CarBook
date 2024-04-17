﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetCarCount();
        int GetLocationCount();
        int GetBlogCount();
        int GetBrandCount();
        decimal GetAvgRentPriceForDaily();
        decimal GetAvgRentPriceForWeekly();
        decimal GetAvgRentPriceForMounthly();
        int GetCarCountByTransmissionIsAuto();
        string BrandNameByMaxCar();
        string BlogTitleByMaxBlogComment();
        int GetCarCountWithLessThan1000Kilometers();
        int GetCarCountByFuelGasolineOrDiesel();
        int GetCountByFuelElectric();
        string GetCarBrandAndModelByDailyRentPriceMax();
        string GetCarBrandAndModelByDailyRentPriceMin();
    }
}