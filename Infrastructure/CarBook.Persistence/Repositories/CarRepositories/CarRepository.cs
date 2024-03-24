using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context) : base(context)
        {
            _context = context;
        }

        public List<Car> GetCarsListWithBrands()
        {
            return _context.Cars.Include(x => x.Brand).ToList();
        }

        public List<Car> GetLast5CarsListWithBrands()
        {
           return _context.Cars
                .OrderByDescending(x => x.CarId)
                .Take(5)
                .Include(x => x.Brand)
                .ToList();
        }
    }
}
