using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
  public  interface ICarService
    {

         IDataResult<List<Car>> GetAll();
        
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<Car> GetByCarId(int id);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(Expression<Func<Car, bool>> filter = null); 
        IDataResult<List<CarDetailDto>> GetCarDetailsByColor(Expression<Func<Car, bool>> filter = null);
        IDataResult<List<CarDetailDto>> GetCarsDetailByBrandIdAndColorId(int brandId, int colorId);
        IResult AddTransactionalTest(Car car);
    }
}
