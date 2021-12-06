using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.DataAccess.Abstarct;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<Rental> Get(int id)
        {
            var result = _rentalDal.Get(r => r.Id == id);

            return new SuccessDataResult<Rental>(result,Messages.ItemListed);
        }

        public IDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            var result = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(result, Messages.ItemsListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.ItemDeleted);
        }
    }
}
