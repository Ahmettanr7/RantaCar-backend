using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Markası : {0} -  Rengi : {1} -  Model Yılı : {2} -  Yakıt : {3} -  Günlük Fiyatı : {4}",
                    car.BrandId,car.ColorId,car.ModelYear,car.Description,car.DailyPrice);
            }
        }
    }
}
