using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=120000,ModelYear=2012,Description="Opel Astra"},
                new Car{Id=2,BrandId=2,ColorId=2,DailyPrice=260000,ModelYear=2020,Description="Peugeot 2008"},
                new Car{Id=3,BrandId=3,ColorId=2,DailyPrice=320000,ModelYear=2019,Description="Audi A4"},
                new Car{Id=4,BrandId=3,ColorId=2,DailyPrice=290000,ModelYear=2015,Description="Audi A6"},
                new Car{Id=5,BrandId=2,ColorId=3,DailyPrice=230000,ModelYear=2018,Description="Peugeot 3008"}
            };

            Brand brand = new Brand {Name = "Mercedes" };
            Color color = new Color {Name = "Kırmızı" };

            Car car = new Car { BrandId=1, ColorId=1, ModelYear=1997, DailyPrice=100000, Description="Doktordan Satılık"};

            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            colorManager.Add(color);
            brandManager.Add(brand);
            carManager.Add(car);
            
        }
    }
}
