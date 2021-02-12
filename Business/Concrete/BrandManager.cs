using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
                
        }
        public IResult Add(Brand brand)
        {
            var result = _brandDal.Get(p => p.Name == brand.Name);
            if (result != null)
            {
                return new ErrorResult("This brand already added try enter another brand");
            }
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetByBrandId(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.Id == id));
        }

        public IResult Update(Brand brand)
        {
           
            _brandDal.Update(brand);
            return new SuccessResult();
        }
    }
}
