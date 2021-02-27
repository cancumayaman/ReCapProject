using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarImagesService
    {
        IResult Add(IFormFile file, CarImages carImage);
        IResult Update(IFormFile file, CarImages carImage);
        IResult Delete(CarImages carImage);
        IDataResult<List<CarImages>> GetAll();
        IDataResult<CarImages> Get(int id);
        IDataResult<List<CarImages>> GetImagesByCarId(int id);
    }
}
