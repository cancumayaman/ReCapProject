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
            
           ColorOperations();
           BrandOperations();
            CarOperations();

        }

        private static void ColorOperations()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
           
            colorManager.Add(new Color { Name = "Red" });

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Name);
            }
            
        }

        private static void BrandOperations()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { Name = "BMW" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
            Console.WriteLine(brandManager.GetByBrandId(1));
        }

        private static void CarOperations()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
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
        }
    }
}
