using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

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
                        on car.BrandId equals brand.Id 
                    join color in context.Colors 
                        on car.ColorId equals color.Id 
                    join bodyType in context.BodyTypes 
                        on car.BodyTypeId equals bodyType.Id 
                    join fuelType in context.FuelTypes 
                        on car.FuelTypeId equals fuelType.Id 
                    join model in context.Models 
                        on car.ModelId equals model.Id 
                    join transmissionType in context.TransmissionTypes 
                        on car.TransmissionTypeId equals transmissionType.Id
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

        public CarDetailDto GetCarDetailById(int id)
        {
            using (Context context = new Context())
            {
                var result = from car in context.Cars.Where(c=>c.Id==id)
                    join brand in context.Brands 
                        on car.BrandId equals brand.Id 
                    join color in context.Colors 
                        on car.ColorId equals color.Id 
                    join bodyType in context.BodyTypes 
                        on car.BodyTypeId equals bodyType.Id 
                    join fuelType in context.FuelTypes 
                        on car.FuelTypeId equals fuelType.Id 
                    join model in context.Models 
                        on car.ModelId equals model.Id 
                    join transmissionType in context.TransmissionTypes 
                        on car.TransmissionTypeId equals transmissionType.Id
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
                return result.SingleOrDefault();
            }
        }

        public List<CarDetailDto> GetCarsDetailByBrandId(int brandId)
        {
            using (Context context = new Context())
            {
                var result = from car in context.Cars.Where(c=>c.BrandId==brandId)
                    join brand in context.Brands 
                        on car.BrandId equals brand.Id 
                    join color in context.Colors 
                        on car.ColorId equals color.Id 
                    join bodyType in context.BodyTypes 
                        on car.BodyTypeId equals bodyType.Id 
                    join fuelType in context.FuelTypes 
                        on car.FuelTypeId equals fuelType.Id 
                    join model in context.Models 
                        on car.ModelId equals model.Id 
                    join transmissionType in context.TransmissionTypes 
                        on car.TransmissionTypeId equals transmissionType.Id
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


        public List<CarDetailDto> GetCarsDetailByColorId(int colorId)
        {
            using (Context context = new Context())
            {
                var result = from car in context.Cars.Where(c=>c.ColorId==colorId)
                    join brand in context.Brands 
                        on car.BrandId equals brand.Id 
                    join color in context.Colors 
                        on car.ColorId equals color.Id 
                    join bodyType in context.BodyTypes 
                        on car.BodyTypeId equals bodyType.Id 
                    join fuelType in context.FuelTypes 
                        on car.FuelTypeId equals fuelType.Id 
                    join model in context.Models 
                        on car.ModelId equals model.Id 
                    join transmissionType in context.TransmissionTypes 
                        on car.TransmissionTypeId equals transmissionType.Id
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
