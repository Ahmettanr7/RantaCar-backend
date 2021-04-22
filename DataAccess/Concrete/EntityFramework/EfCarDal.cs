using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RantaCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RantaCarContext context = new RantaCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             select new CarDetailDto 
                             { 
                                 CarId = c.Id, 
                                 BrandName = b.BrandName, 
                                 ColorName = cl.ColorName, 
                                 DailyPrice = c.DailyPrice, 
                                 Description = c.Description, 
                                 ModelYear = c.ModelYear };
                return result.ToList();
            }
        }
    }
}
