using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public string BlogTitleByMaxBlogComment()
        {
            throw new NotImplementedException();
        }

        public string BrandNameByMaxCar()
        {
            throw new NotImplementedException();
        }

        public decimal GetAvgRentPriceForDaily()
        {
            int pricingId = _context.Pricings.Where(p => p.Name == "Günlük").Select(g => g.PricingId).FirstOrDefault();

            var value = _context.CarPricings.Where(c => c.PricingId == pricingId).Average(a => a.Amount);

            return value;
        }

        public decimal GetAvgRentPriceForMounthly()
        {
            int pricingId = _context.Pricings.Where(p => p.Name == "Aylık").Select(g => g.PricingId).FirstOrDefault();

            var value = _context.CarPricings.Where(c => c.PricingId == pricingId).Average(a => a.Amount);

            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int pricingId = _context.Pricings.Where(p => p.Name == "Haftalık").Select(g => g.PricingId).FirstOrDefault();

            var value = _context.CarPricings.Where(c => c.PricingId == pricingId).Average(a => a.Amount);

            return value;
        }

        public int GetBlogCount()
        {
            return _context.Blogs.Count();
        }

        public int GetBrandCount()
        {
            return _context.Brands.Count();
        }

        public string GetCarBrandAndModelByDailyRentPriceMax()
        {
            throw new NotImplementedException();
        }

        public string GetCarBrandAndModelByDailyRentPriceMin()
        {
            throw new NotImplementedException();
        }

        public int GetCarCount()
        {
            return _context.Cars.Count();
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            return _context.Cars.Where(c => c.Fuel == "Benzin" || c.Fuel == "Dizel").Count();
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            return _context.Cars.Where(c => c.Transmission == "Otomatik").Count();
        }

        public int GetCarCountWithLessThan1000Kilometers()
        {
            return _context.Cars.Where(c => c.Km < 1000).Count();
        }

        public int GetCountByFuelElectric()
        {
            return _context.Cars.Where(c => c.Fuel == "Elektrik").Count();
        }

        public int GetLocationCount()
        {
            return _context.Locations.Count();
        }
    }
}
