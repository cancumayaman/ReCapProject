using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join clr in context.Colors
                             on c.ColorId equals clr.Id
                             join ci in context.CarImages
                             on c.Id equals ci.CarId
                             select new CarDetailDto { Id=c.Id, CarName = c.Name, BrandName = b.Name, ColorName = clr.Name, DailyPrice = c.DailyPrice,ImagePath=ci.ImagePath,Description=c.Description };
                return result.ToList();
            }
            
            
            
        }

        public List<CarDetailDto> GetCarDetailsByBrand(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join ci in context.CarImages
                             on c.Id equals ci.CarId

                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.Name,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = ci.ImagePath,
                                 Description = c.Description

                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByColor(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join ci in context.CarImages
                              on c.Id equals ci.CarId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 CarName = c.Name,
                                 BrandName = b.Name,
                                 ColorName = co.Name,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = ci.ImagePath,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }
    }
}
