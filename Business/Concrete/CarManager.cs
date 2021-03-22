using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entity.Concrete;
using Entity.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Transactions;

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
        [SecuredOperation("car.add,admin,car.list")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
          
                _iCarDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
         
            
        }
      

        public IResult Delete(Car car)
        {
            
            _iCarDal.Delete(car);
            return new SuccessResult();

        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(),Messages.CarsListed);
            
        }
        [SecuredOperation("user")]
        [PerformanceAspect(5)]
        public IDataResult<Car> GetByCarId(int id)
        {
          return new SuccessDataResult<Car>(_iCarDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails(filter));
        }
        
       

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.ColorId == colorId));
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 20)
            {
                _iCarDal.Update(car);
                return new SuccessResult();
            }
            return new ErrorResult();
               
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 0)
            {
                throw new Exception("");
            }
            Add(car);
            return null;

        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(p => p.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetailsByBrand(filter));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColor(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetailsByColor(filter));
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailByBrandIdAndColorId(int brandId, int colorId)
        {

            List<CarDetailDto> carDetails = _iCarDal.GetCarDetails(p => p.BrandId == brandId && p.ColorId == colorId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>();
            }
            else
            {
                return new SuccessDataResult<List<CarDetailDto>>(carDetails);
            }

        }
    }
}
