using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetCarDetails();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            var result = rentalManager.GetRentalDetails();
            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("Araba : {0}  Müşteri : {1}  Kiraladığı Tarih : {2}  Teslim Tarihi : {3}  Arabanın Günlüğü : {4} Toplam Tutar : {5}",
                        rental.CarName, rental.CustomerName, rental.RentDate, rental.ReturnDate, rental.DailyPrice, rental.TotalPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Markası : {0} -  Rengi : {1} -  Model Yılı : {2} -  Yakıt : {3} -  Günlük Fiyatı : {4}",
                    car.BrandName, car.ColorName, car.ModelYear, car.Description, car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
