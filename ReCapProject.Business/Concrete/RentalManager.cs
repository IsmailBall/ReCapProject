using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.DataAccess.Abstarct;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReCapProject.Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var carStates = _rentalDal.GetAllCarsState().FirstOrDefault(cs => cs.Id == rental.CarId
            && cs.ReturnDate == null);
            if (carStates == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.ItemAdded);
            }
            return new ErrorResult("The car is being using");
        }
    }
}
