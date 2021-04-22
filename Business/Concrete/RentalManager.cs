using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(
                CheckIfTheCarHasBeenDelivered(rental),
               CheckIfitisOneDayPastDelivery(rental),
               CheckIfRentDay(rental)
               );

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("admin")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [CacheRemoveAspect("IRentalService.Get")]
        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            
            return new SuccessDataResult<List<RentalDetailDto>>(  _rentalDal.GetRentalDetails());
        }

        private IResult CheckIfTheCarHasBeenDelivered(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && !r.ReturnDate.HasValue);
            if (result.Any())
            {
                return new ErrorResult(Messages.RentalNotComeBack);
            }
            return new SuccessResult();   
        }

        private IResult CheckIfitisOneDayPastDelivery(Rental rental)
        {
            //<datetime.now.day değişecek
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && (rental.RentDate.Day - r.ReturnDate.Value.Day)==0);
            if (result.Any())
            {
                return new ErrorResult(Messages.CarIsAtRest);
            }
            return new SuccessResult();
        }

        private IResult CheckIfRentDay(Rental rental)
                   
        {
            if (rental.RentDate.Day<DateTime.Now.Day)
            {
                return new ErrorResult(Messages.RentDayCantbePast);
            }
            return new SuccessResult();
        }
        
    }
}
