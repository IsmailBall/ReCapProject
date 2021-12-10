using ReCapProject.Core.DataAccess.EntityFramework;
using ReCapProject.Core.Entities.Concrete;
using ReCapProject.DataAccess.Abstarct;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ReCapProject.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepostoryBase<User, CarRentContext>, IUserDal
    {
        public List<OperationClaim> GetOperationClaims(User user)
        {
            using (CarRentContext context = new CarRentContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaims in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaims.OperationClaimId
                             where userOperationClaims.UserId == user.Id
                             select new OperationClaim()
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return result.ToList();
            }
        }
    }
}
