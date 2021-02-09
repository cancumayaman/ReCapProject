using Business.Abstract;
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
        public void Add(Brand brand)
        {
            Console.WriteLine("Brand added successfully");
            _brandDal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            Console.WriteLine("Brand deleted successfully");
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetByBrandId(int id)
        {
            return _brandDal.Get(p => p.Id == id);
        }

        public void Update(Brand brand)
        {
            Console.WriteLine("Brand updated successfully");
            _brandDal.Update(brand);
        }
    }
}
