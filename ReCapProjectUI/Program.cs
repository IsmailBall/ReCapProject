using ReCapProject.Business.Abstract;
using ReCapProject.Business.Concrete;
using ReCapProject.DataAccess.Concrete.InMemoryDal;
using ReCapProject.Entities.Concrete;
using System;

namespace ReCapProjectUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = (decimal)50, Description = "Daily Car", ModelYear = DateTime.Now };
            Car car2 = new Car { Id = 2, BrandId = 2, ColorId = 2, DailyPrice = (decimal)60, Description = "Daily Car", ModelYear = DateTime.Now };
            Car car3 = new Car { Id = 3, BrandId = 3, ColorId = 3, DailyPrice = (decimal)70, Description = "Daily Car", ModelYear = DateTime.Now };
            Car car4 = new Car { Id = 4, BrandId = 4, ColorId = 4, DailyPrice = (decimal)80, Description = "Daily Car", ModelYear = DateTime.Now };
            Car car5 = new Car { Id = 5, BrandId = 5, ColorId = 5, DailyPrice = (decimal)90, Description = "Daily Car", ModelYear = DateTime.Now };

            ICarService carService = new CarManager(new InMemoryDal());

            carService.Add(car1);
            carService.Add(car2);
            carService.Add(car3);
            carService.Add(car4);
            carService.Add(car5);
            DisplayCars(carService);

            //Update Car
            car3.BrandId = 10;
            carService.Update(car3);
            DisplayCars(carService);

            //Delete Car
            carService.Delete(car1);
            DisplayCars(carService);

            //Get By Id
            Console.WriteLine(carService.GetById(car2.Id).Id);

            Console.ReadLine();
        }

        private static void DisplayCars(ICarService carService)
        {
            foreach (var car in carService.GetAll())
            {
                Console.WriteLine($"{car.BrandId} {car.ColorId} {car.DailyPrice} {car.Description} ");
            }
        }
    }
}
