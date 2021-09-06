using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Business.Constants;
using ReadingIsGood.Business.ValidationRules.FluentValidation;
using ReadingIsGood.Core.Aspects.Autofac.Validation;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Business;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.Core.Utilities.Security.Hashing;
using ReadingIsGood.Core.Utilities.Security.Jwt;
using ReadingIsGood.Entities.DTOs;
using System;

namespace ReadingIsGood.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.SuccessfullyLoggedIn);
        }
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var getUser = _userService.GetByMail(userForLoginDto.Email);
            if (!getUser.Success)
                return new ErrorDataResult<User>(Messages.WrongEmailOrPassword);

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, getUser.Data.PasswordHash, getUser.Data.PasswordSalt))
                return new ErrorDataResult<User>(Messages.WrongEmailOrPassword);

            return new SuccessDataResult<User>(getUser.Data);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var checkRules = BusinessRules.Run(_userService.CheckUserByEmail(userForRegisterDto.Email));
            if (checkRules.Success)
                return new ErrorDataResult<User>(checkRules.Message);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                IsActive = true
            };
            _userService.Add(user);

           
            return new SuccessDataResult<User>(user);
        }

    }
}
