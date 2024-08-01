using Business.Abstract;
using Business.Constants;
using Core.Concrete;
using Core.Results;
using Core.Security.Hashing;
using Core.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
   
    public class AuthManager : IAuthService
    {
        private IUserService userService;
        private ITokenHelper tokenHelper;


        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            this.userService = userService;
            this.tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = userService.GetClaims(user);

            return new SuccessDataResult<AccessToken>(tokenHelper.CreateToken(user,claims.Data));
            
        }

        public IDataResult<User> Login(UserForLoginDTO userForLoginDto)
        {
            var userToCheck = userService.GetByMail(userForLoginDto.Email).Data;
            if (userToCheck != null) {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDTO userForRegisterDto, string password)
        {
            
        }

        public IResult UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
