using ReCapProject.Business.Abstract;
using ReCapProject.Business.BusinessAspects.Autofac;
using ReCapProject.Business.Constants;
using ReCapProject.Business.ValidationRules.FluentValidation;
using ReCapProject.Core.Aspects.Autofac.Caching;
using ReCapProject.Core.Aspects.Autofac.Validation;
using ReCapProject.Core.CrossCuttingConcerns.Validation;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.DataAccess.Abstarct;
using ReCapProject.Entities.Concrete;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ReCapProject.Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [SecuredOperation("car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.ItemDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(filter),Messages.ItemsListed);
        }
        [CacheAspect]
        public IDataResult<Car> Get(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id),Messages.ItemListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult(Messages.ItemUpdated);
        }

        public IDataResult<Car> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.BrandId == id),Messages.ItemListed);
        }

        public IDataResult<Car> GetCarByColorId(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.ColorId == id),Messages.ItemListed);
        }

        public IDataResult<List<CarDetail>> GetCarDetails()
        {
            if(DateTime.Now.Hour == 18)
            {
                return new ErrorDataResult<List<CarDetail>>("Bakim saati");
            }
            return new SuccessDataResult<List<CarDetail>>(_carDal.GetAllCarDetails());
        }

        public IDataResult<List<Car>> GetAllByCategory(int id)
        {
            var result = _carDal.GetAll(c => c.BrandId==id);
            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }
    }
}
