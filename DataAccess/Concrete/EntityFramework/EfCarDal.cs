using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http.Internal;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, Context>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetail()
        {
            using (Context context = new Context())
            {
                var result = from car in context.Cars 
                    join brand in context.Brands 
                        on car.Id equals brand.Id 
                    join color in context.Colors 
                        on car.Id equals color.Id 
                    join bodyType in context.BodyTypes 
                        on car.Id equals bodyType.Id 
                    join fuelType in context.FuelTypes 
                        on car.Id equals fuelType.Id 
                    join model in context.Models 
                        on car.Id equals model.Id 
                    join transmissionType in context.TransmissionTypes 
                        on car.Id equals transmissionType.Id
                    select new CarDetailDto
                             {
                                 CarId = car.Id,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 ModelName = model.Name,
                                 Km = car.Km,
                                 MotorPower = car.MotorPower,
                                 ModelYear = car.ModelYear,
                                 FuelTypeName = fuelType.Name,
                                 Description = car.Description,
                                 TransmissionTypeName = transmissionType.Name,
                                 BodyTypeName = bodyType.Name,
                             };
                return result.ToList();
            }
        }
    }
}
