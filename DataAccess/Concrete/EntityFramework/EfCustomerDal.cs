using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RantaCarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            using (RantaCarContext context = new RantaCarContext())
            {
                var result = from c in context.Customers
                             join u in context.Users on c.UserId equals u.Id

                             select new CustomerDetailDto
                             {
                                 UserId = u.Id,
                                 CustomerId = c.Id,
                                 CompanyName = c.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 PasswordHash = u.PasswordHash,
                                 PasswordSalt = u.PasswordSalt,
                                 Status = u.Status
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
