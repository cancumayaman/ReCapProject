using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from re in context.Rentals
                             join c in context.Cars
                             on re.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join csm in context.Customers
                             on re.CustomerId equals csm.Id
                             join us in context.Users
                             on csm.UserId equals us.Id
                             select new RentalDetailDto { 
                              Id=re.Id,
                              BrandName=b.Name,
                              FirstName=us.FirstName,
                              LastName=us.LastName,
                              RentDate=re.RentDate,
                              ReturnDate=re.ReturnDate
                             
                             };
                return result.ToList();
            }
        }
    }
}
