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
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Name = "Mercedes", Model = "C180" });
            brandManager.Add(new Brand { Name = "BMW", Model = "320" });
            brandManager.GetAll();
            brandManager.GetById(1);

            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { Name = "Beyaz" });
            colorManager.Add(new Color { Name = "Siyah" });
            colorManager.Add(new Color { Name = "Kırmızı" });
            colorManager.GetAll();
            colorManager.GetById(1);

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 1, ColorId = 1, DailyPrice = 100000, ModelYear = 1997, Description = "Temiz" });
            carManager.Add(new Car { BrandId = 2, ColorId = 3, DailyPrice = 156000, ModelYear = 2007, Description = "Çok İyi" });
            carManager.GetAll();
            carManager.GetCarDetails();
            carManager.GetCarsByBrandId(1);




        }
    }
}
