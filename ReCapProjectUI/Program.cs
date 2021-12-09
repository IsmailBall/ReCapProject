using ReCapProject.Business.Abstract;
using ReCapProject.Business.Concrete;
using ReCapProject.Business.Constants;
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

            Console.WriteLine(DirectoryPath.GetCarImagesRouter());

            //ICarService carService = new CarManager(new EfCarDal());
            ////AddCars(carService);
            ////DisplayCars(carService);

            //IRentalService rentalService = new RentalManager(new EfRentalDal());

            //rentalService.Add(new Rental
            //{
            //    CarId = 3,
            //    CustomerId = 1,
            //    RentDate = DateTime.Now.ToString()
            //});
            //var result = rentalService.Add(new Rental
            //{
            //    CarId = 3,
            //    CustomerId = 1,
            //    RentDate = DateTime.Now.ToString()
            //});


            //Console.WriteLine(result.Succes);

            Console.ReadLine();

        }

        private static void DisplayCars(ICarService carService)
        {
            var cars = carService.GetCarDetails();

            if (cars.Succes != true)
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
