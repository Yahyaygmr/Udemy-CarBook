using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.CarPricings
                .Include(c => c.Car)
                .ThenInclude(c => c.Brand)
                .Include(c => c.Pricing)
                .ToList();
            return values;
        }
        public List<CarPricing> GetCarPricingWithCarsDaily()
        {
            var values = _context.CarPricings
                .Include(c => c.Car)
                .ThenInclude(c => c.Brand)
                .Include(c => c.Pricing)
                .Where(x => x.PricingId == 3)
                .ToList();
            return values;
        }
    }
}
