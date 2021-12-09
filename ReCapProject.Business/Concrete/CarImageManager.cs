using Microsoft.AspNetCore.Http;
using ReCapProject.Business.Abstract;
using ReCapProject.Business.Constants;
using ReCapProject.Core.Utilities.Business;
using ReCapProject.Core.Utilities.Helpers.FileHelpers;
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
    public class CarImageManager : ICarImageService
    {

        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var businessResult = BusinessRules.Run(CheckIfLimitExceeded(carImage));
            var result = FileHelpers.Upload(formFile, DirectoryPath.GetCarImagesRouter());

            if (result.Succes && businessResult == null)
            {
                carImage.ImagePath = result.Data;
                carImage.Date = DateTime.Now;

                _carImageDal.Add(carImage);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult Delete(CarImage carImage)
        {
            var result = FileHelpers.Delete(carImage.ImagePath);
            if (result.Succes)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(filter));
        }

        public IDataResult<List<CarImage>> GetAllOfTheCarImages(int id)
        {
            var result = BusinessRules.Run(CheckIfCarExist(id));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>();
            }

            return ReturnDefaultOrFromCar(id);
        }

        public IResult Update(IFormFile formFile, CarImage carImage, string destination)
        {
            var result = FileHelpers.Update(formFile, carImage.ImagePath , destination);
            if (result.Succes)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IResult CheckIfLimitExceeded(CarImage carImage)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count();

            if (result<5)
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }

        private IResult CheckIfCarExist(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id);

            if (result != null)
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }

        private IDataResult<List<CarImage>> ReturnDefaultOrFromCar(int id)
        {
            var carImages = _carImageDal.GetAll(c => c.CarId == id).Where(c => !string.IsNullOrEmpty(c.ImagePath)).ToList();
            if (carImages == null)
            {
                var carImage = _carImageDal.Get(c => c.CarId == id);
                carImage.ImagePath = DirectoryPath.GetDefaultImagesRouter();
                return new SuccessDataResult<List<CarImage>>(new List<CarImage> { carImage });
            }

            return new SuccessDataResult<List<CarImage>>(carImages);
            
        }
    }
}
