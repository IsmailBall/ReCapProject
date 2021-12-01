using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ReCapProject.Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAll(Expression<Func<Car,bool>> filter = null);
        Car Get(int id);
        Car GetCarsByBrandId(int id);
        Car GetCarsByColorId(int id);
        List<CarDetail> GetCarDetails();
    }
}
