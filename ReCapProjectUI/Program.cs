using ReCapProject.Business.Abstract;
using ReCapProject.Business.Concrete;
using ReCapProject.DataAccess.Concrete.EntityFramework;
using ReCapProject.DataAccess.Concrete.InMemoryDal;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ReCapProjectUI
{
    class Program
    {
        static void Main(string[] args)
        {

            ICarService carService = new CarManager(new EFCarDal());
            //AddCars(carService);

            var cars = carService.GetCarDetails();

            if(cars.Succes != true)
            {
                Console.WriteLine(cars.Message);
            }
            else
            {
                foreach (var car in cars.Data)
                {
                    Console.WriteLine($"{car.Id} {car.BrandName} {car.ColorName} {car.ModelYear.Year} ");
                }
            }

            Console.ReadLine();

        }

        private static void AddCars(ICarService carService)
        {
            carService.Add(new Car() { BrandId = 1, DailyPrice = 500, ColorId = 1, ModelYear = DateTime.Now, Description = "Yeni Araba" });
            carService.Add(new Car() { BrandId = 2, DailyPrice = 600, ColorId = 2, ModelYear = DateTime.Now, Description = "Yeni Araba" });
            carService.Add(new Car() { BrandId = 3, DailyPrice = 700, ColorId = 3, ModelYear = DateTime.Now, Description = "Yeni Araba" });
            carService.Add(new Car() { BrandId = 4, DailyPrice = 800, ColorId = 4, ModelYear = DateTime.Now, Description = "Yeni Araba" });
            carService.Add(new Car() { BrandId = 5, DailyPrice = 900, ColorId = 5, ModelYear = DateTime.Now, Description = "Yeni Araba" });
        }
    }
}
