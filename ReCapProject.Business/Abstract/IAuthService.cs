using ReCapProject.Core.Entities.Concrete;
using ReCapProject.Core.Security.Jwt;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> LogIn(UserForLoginDto userForLoginDto);
        IResult UserExist(string mail);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
