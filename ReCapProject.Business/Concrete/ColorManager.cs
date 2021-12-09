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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            return new SuccessResult();
        }

        public IResult Delete(Color color)
        {
            return new SuccessResult();
        }

        public IDataResult<Color> Get(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c=>c.Id == id));
        }

        public IDataResult<List<Color>> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(filter));
        }

        public IResult Update(Color color)
        {
            return new SuccessResult();
        }
    }
}
