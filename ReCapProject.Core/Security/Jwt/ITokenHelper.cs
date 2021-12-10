using ReCapProject.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Core.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user , List<OperationClaim> operationClaims);
    }
}
