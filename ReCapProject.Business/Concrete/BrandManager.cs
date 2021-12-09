using ReCapProject.Business.Abstract;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.DataAccess.Abstarct;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ReCapProject.Business.Concrete
{
    public class BrandManager : IBrandSerivce
    {

        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {
            return new SuccessResult();
        }

        public IDataResult<Brand> Get(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.Id==id));
        }

        public IDataResult<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(filter));
        }

        public IResult Update(Brand brand)
        {
            return new SuccessResult();
        }
    }
}
