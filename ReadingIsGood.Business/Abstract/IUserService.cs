using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadingIsGood.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IDataResult<User> GetByMail(string email);
        IResult CheckUserById(string userId);
        IResult CheckUserByEmail(string email);
    }
}
