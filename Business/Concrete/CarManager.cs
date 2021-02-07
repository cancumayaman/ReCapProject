using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entity.Concrete;
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
        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
            
        }
    }
}
