using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.DataAccess.Abstarct;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepostoryBase<Rental, CarRentContext>, IRentalDal
    {
        public List<CarState> GetAllCarsState()
        {
            using (CarRentContext context = new CarRentContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             select new CarState
                             {
                                 Id = car.Id,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
