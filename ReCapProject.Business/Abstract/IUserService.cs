using ReCapProject.Core.Utilities.Results;
using ReCapProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ReCapProject.Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null);
        IDataResult<User> Get(int id);

    }
}
