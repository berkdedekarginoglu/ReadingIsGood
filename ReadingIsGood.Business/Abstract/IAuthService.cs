using ReadingIsGood.Core.Entities;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.Core.Utilities.Security.Jwt;
using ReadingIsGood.Entities.DTOs;
using System.Threading.Tasks;

namespace ReadingIsGood.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<AccessToken> CreateAccessToken(User user);
        IDataResult<User> Register(UserForRegisterDto customerForRegisterDto);
        IDataResult<User> Login(UserForLoginDto customerForLoginDto);
    }
}
