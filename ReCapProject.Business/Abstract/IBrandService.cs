using ReCapProject.Core.Utilities.Results;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ReCapProject.Business.Abstract
{
    public interface IBrandSerivce
    {
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);
        IDataResult<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null);
        IDataResult<Brand> Get(int id);
    }
}
