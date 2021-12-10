using ReCapProject.Core.DataAccess;
using ReCapProject.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.DataAccess.Abstarct
{
    public interface IUserDal:IEntityRepostory<User>
    {
        List<OperationClaim> GetOperationClaims(User user);
    }
}
