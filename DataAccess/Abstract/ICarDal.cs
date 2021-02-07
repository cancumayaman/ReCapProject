using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICarDal
    {
        List<Car> GetAll();
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        List<Car> GetAllByCarId(int id);
    }
}
