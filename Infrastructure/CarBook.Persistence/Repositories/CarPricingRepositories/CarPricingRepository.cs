using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

		public List<CarPricingViewModel> GetCarPricingWithTimePeriod()
		{
			List<CarPricingViewModel> values = new List<CarPricingViewModel>();
			using (var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = "Select * From (Select Model,Name,CoverImageUrl,PricingID,Amount From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarId Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([2],[3],[4])) as PivotTable;";
				command.CommandType = System.Data.CommandType.Text;
				_context.Database.OpenConnection();
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
						{
							Brand = reader["Name"].ToString(),
							Model = reader["Model"].ToString(),
							CoverImageUrl = reader["CoverImageUrl"].ToString(),
							Amounts = new List<decimal>
							{
								// DBNull kontrolü ekleyerek Convert.ToDecimal() kullanımı
								reader["2"] != DBNull.Value ? Convert.ToDecimal(reader["2"]) : 0m,
								reader["3"] != DBNull.Value ? Convert.ToDecimal(reader["3"]) : 0m,
								reader["4"] != DBNull.Value ? Convert.ToDecimal(reader["4"]) : 0m
							}
						};
						values.Add(carPricingViewModel);
					}
				}
				_context.Database.CloseConnection();
				return values;
			}
		}
	}
}

