using Microsoft.AspNetCore.Http;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ReCapProject.Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile formFile, CarImage carImage);
        IResult Update(IFormFile formFile, CarImage carImage, string destination);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetAll(Expression<Func<CarImage, bool>> filter = null);
        IDataResult<CarImage> Get(int id);
        IDataResult<List<CarImage>> GetAllOfTheCarImages(int id);
    }
}
