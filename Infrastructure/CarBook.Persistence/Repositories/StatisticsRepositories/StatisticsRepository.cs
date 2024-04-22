using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
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
            var blogId = _context.Comments
                .GroupBy(c => c.BlogId)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .FirstOrDefault();
            var blog = _context.Blogs
                .Where(x => x.BlogId == blogId)
                .FirstOrDefault();
            var value = blog.Name;
            return value;
        }

        public string BrandNameByMaxCar()
        {
            var brandId = _context.Cars
                .GroupBy(c => c.BrandId)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .FirstOrDefault();
            var brand = _context.Brands.Where(x => x.BrandId == brandId).FirstOrDefault();
            var value = brand.Name;
            return value;

        }

        public int GetAuthorCount()
        {
            return _context.Authors.Count();
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
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingId).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingId == pricingId).Max(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarId).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarId == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public string GetCarBrandAndModelByDailyRentPriceMin()
        {
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingId).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingId == pricingId).Min(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarId).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarId == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
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
