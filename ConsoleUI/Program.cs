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
