using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using Core.Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //BrandTest();
            //ColorTest();
            //CarTest();
            //UserTest();
            //CustomerTest();
            //RentalTest();
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rental {CarId = 1, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = DateTime.Now});
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer {UserId = 1, CompanyName = "DD"});
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User
                {Email = "deniz.dursun1@outlook.com", FirstName = "Deniz", LastName = "Dursun"});
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarsDetail().Data)
            {
                Console.WriteLine(car.ModelName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color {Name = "Beyaz"});
            colorManager.Add(new Color {Name = "Siyah"});
            colorManager.Add(new Color {Name = "Kırmızı"});
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.Name);
            }

            Console.WriteLine(colorManager.GetById(1).Data.Name);
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand {Name = "Mercedes"});
            brandManager.Add(new Brand {Name = "BMW"});
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.Name);
            }

            Console.WriteLine(brandManager.GetById(1).Data.Name);
        }
    }
}
