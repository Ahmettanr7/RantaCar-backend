using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RantaCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetCarDetails()
        {
            using (RantaCarContext context = new RantaCarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join cs in context.Customers
                             on r.CustomerId equals cs.CustomerId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join u in context.Users
                             on cs.UserId equals u.UserId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarName = b.BrandName,
                                 CustomerName = cs.CompanyName,
                                 UserName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = c.DailyPrice,
                                 TotalPrice = Convert.ToDecimal(r.ReturnDate.Value.Day - r.RentDate.Day) * c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
