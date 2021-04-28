﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {   //Veritabanından geliyormuş gibi simule ediyoruz
            _cars = new List<Car> {
                new Car {Id = 1, BrandId = 1, ColorId = 2, ModelYear = 2021, DailyPrice = 350, FuelType = "Dizel"},
                new Car {Id = 2, BrandId = 2, ColorId = 4, ModelYear = 2019, DailyPrice = 250, FuelType = "Benzin"},
                new Car {Id = 3, BrandId = 1, ColorId = 5, ModelYear = 2021, DailyPrice = 325, FuelType = "Dizel"},
                new Car {Id = 4, BrandId = 3, ColorId = 1, ModelYear = 2010, DailyPrice = 200, FuelType = "LPG+Benzin"},
                new Car {Id = 5, BrandId = 5, ColorId = 7, ModelYear = 2016, DailyPrice = 225, FuelType = "Benzin"},

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.Id == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice; 
            carToUpdate.FuelType = car.FuelType;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
