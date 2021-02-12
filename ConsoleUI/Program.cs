using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entity.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ColorOperations();
            //BrandOperations();
            //CarOperations();
            //UserOperations();
            //CustomerOperations();
            RentalOperations();

        }

        private static void RentalOperations()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
           var result= rentalManager.Add(new Rental { CarId = 2, CustomerId = 2, RentDate = new DateTime(2021, 2, 12), ReturnDate = null });
            Console.WriteLine(result.Message);
        }

        private static void UserOperations()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            
           var result= userManager.Add(new User {  FirstName = "Ceren", LastName = "Yaman", Email = "ceren@gmail.com", Password = "cancuma" });
            Console.WriteLine(result.Message);
        }

        private static void CustomerOperations()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer {  CompanyName = "Yamanlar", UserId = 2 });
            Console.WriteLine(result.Message);
        }

        private static void ColorOperations()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //colorManager.Add(new Color { Name = "Red" });
            var result = colorManager.GetAll();
            if (result.Success)
            {
                foreach (var color in result.Data )
                {
                    Console.WriteLine(color.Name);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }

        private static void BrandOperations()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            // brandManager.Add(new Brand { Name = "BMW" });
            var result = brandManager.GetAll();
            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.Name);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarOperations()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success==true)
            {
                foreach (var car in result.Data )
                {
                    Console.WriteLine(car.Name+" "+car.Description);
                    
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            /*
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.Description);
            }
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.Description);
            }
            
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarName+" " +car.BrandName+" "+ car.ColorName+" "+car.DailyPrice+" $");
            } 
            */
        }
    }
}
