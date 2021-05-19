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
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (RantaCarContext context = new RantaCarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join u in context.Users
                             on r.UserId equals u.Id
                             join clr in context.Colors
                             on c.ColorId equals clr.Id
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 UserId = u.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = clr.ColorName,
                                 UserName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = c.DailyPrice,
                                 CarId = c.Id,
                                 TotalRentDay = (r.ReturnDate.Value.Day - r.RentDate.Day+(r.ReturnDate.Value.Month-r.RentDate.Month)*30+(r.ReturnDate.Value.Year-r.RentDate.Year)*365),
                                 TotalPrice = Convert.ToDecimal(r.ReturnDate.Value.Day - r.RentDate.Day + (r.ReturnDate.Value.Month - r.RentDate.Month) * 30 + (r.ReturnDate.Value.Year - r.RentDate.Year) * 365) * c.DailyPrice
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
