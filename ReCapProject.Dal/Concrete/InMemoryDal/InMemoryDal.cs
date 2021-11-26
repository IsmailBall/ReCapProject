using ReCapProject.DataAccess.Abstarct;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReCapProject.DataAccess.Concrete.InMemoryDal
{
    public class InMemoryDal : ICarDal
    {
        List<Car> cars = new List<Car> { };
        public void Add(Car car)
        {
            cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car toDeleted = cars.SingleOrDefault(c => c.Id == car.Id);
            cars.Remove(toDeleted);
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public Car GetById(int id)
        {
            return cars.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Car car)
        {
            Car toUpdated = cars.SingleOrDefault(c => c.Id == car.Id);
            toUpdated.BrandId = car.BrandId;
            toUpdated.ColorId = car.ColorId;
            toUpdated.DailyPrice = car.DailyPrice;
            toUpdated.Description = car.Description;
            toUpdated.ModelYear = car.ModelYear;
        }
    }
}
