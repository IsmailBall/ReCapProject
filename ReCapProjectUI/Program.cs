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
            //FirstDraft();
            ICarService carService = new CarManager(new EFCarDal());
            carService.Add(new Car() { BrandId = 1, DailyPrice = 500, ColorId = 3, ModelYear = DateTime.Now, Description = "YENİ ARAB" });
            List<Car> cars = carService.GetAll();

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Id} {car.BrandId} {car.ColorId} {car.DailyPrice} {car.Description} ");
            }

            Console.ReadLine();

        }

    }
}
