using ReCapProject.Business.Abstract;
using ReCapProject.Core.Entities.Concrete;
using ReCapProject.Core.Security.Hashing;
using ReCapProject.Core.Security.Jwt;
using ReCapProject.Core.Utilities.Results;
using ReCapProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReCapProject.Business.Concrete
{
    public class AuthManager : IAuthService
    {

        ITokenHelper _tokenHelper;
        IUserService _userService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu");
        }

        public IDataResult<User> LogIn(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (!userToCheck.Succes)
            {
                return new ErrorDataResult<User>("Kullanıcı Bulunamadı");
            }

            if(!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.Data.PasswordHash,
                userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>("Hatalı Parola");
            }

            return new SuccessDataResult<User>(userToCheck.Data,"Giris Basarılı");
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            var result = _userService.Add(user);
            if(result.Succes)
                return new SuccessDataResult<User>(user, "Kayıt oldu");
            return new ErrorDataResult<User>("kayıt basarisiz");
        }

        public IResult UserExist(string mail)
        {
            var result = _userService.GetByMail(mail);
            if (result.Succes)
            {
                return new ErrorResult("Böyle bir Kullanıcı mevcut değil");
            }

            return new SuccessResult();
        }
    }
}
