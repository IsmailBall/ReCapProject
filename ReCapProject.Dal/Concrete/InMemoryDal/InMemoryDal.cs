using ReCapProject.DataAccess.Abstarct;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
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
