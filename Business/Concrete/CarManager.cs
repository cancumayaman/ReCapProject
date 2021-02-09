using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //Business class dont new another class, do in below command instead of new
        ICarDal _iCarDal;
        public CarManager(ICarDal carDal)
        {
            _iCarDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 20)
            {
                _iCarDal.Add(car);
                Console.WriteLine("Car added successfully");
            }
            else
            {
                Console.WriteLine("Please control the car description or car daily price,description must be at least 2 character and daily price must be more than 20");
            }
        }

        public void Delete(Car car)
        {
            Console.WriteLine("Car deleted successfully");
            _iCarDal.Delete(car);

        }

        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
            
        }

        public Car GetByCarId(int id)
        {
          return  _iCarDal.Get(p => p.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _iCarDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _iCarDal.GetAll(p => p.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _iCarDal.GetAll(p => p.ColorId == colorId);
        }

        public void Update(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 20)
            {
                _iCarDal.Update(car);
                Console.WriteLine("Car updated successfully");
            }
            else
            {
                Console.WriteLine("Please control the car description or car daily price,description must be at least 2 character and daily price must be more than 20");

            }
               
        }
    }
}
