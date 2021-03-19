using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
              new Car{ Id=1,BrandId=1,ColorId=1,ModelYear=2000,DailyPrice=100,Description="Comfortable"},
              new Car{ Id=2,BrandId=2,ColorId=3,ModelYear=2010,DailyPrice=200,Description="More Comfortable"},
              new Car{ Id=3,BrandId=3,ColorId=3,ModelYear=2020,DailyPrice=300,Description="Family Car"}
            };

        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car deletedCar = null;
           deletedCar= _cars.SingleOrDefault(x => x.Id == car.Id);
            _cars.Remove(deletedCar);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByCarId(int id)
        {
            return _cars.Where(x => x.Id == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByBrand(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByColor(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car updatedCar = null;
            updatedCar = _cars.SingleOrDefault(x => x.Id == car.Id);
            updatedCar.Id = car.Id;
            updatedCar.BrandId = car.BrandId;
            updatedCar.ColorId = car.ColorId;
            updatedCar.ModelYear = car.ModelYear;
            updatedCar.DailyPrice = car.DailyPrice;
            updatedCar.Description = car.Description;
        }
    }
}
