using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, RantaCarContext>, ICarImageDal
    {
        public bool IsExist(int id)
        {
            using (RantaCarContext context = new RantaCarContext())
            {
                return context.CarImages.Any(p => p.CarImageId == id);
            }
        }
    }
}