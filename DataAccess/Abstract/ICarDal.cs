using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
   public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        List<CarDetailDto> GetCarDetailsByBrand(Expression<Func<Car, bool>> filter = null);
        List<CarDetailDto> GetCarDetailsByColor(Expression<Func<Car, bool>> filter = null);

    }
}
