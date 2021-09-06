using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Core.Entities;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.DataAccess.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadingIsGood.Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var selectedClaims = _userDal.GetClaims(user);
            if (selectedClaims == null)
                return new ErrorDataResult<List<OperationClaim>>("Claims not found");
            return new SuccessDataResult<List<OperationClaim>>(selectedClaims);
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public  IDataResult<User> GetByMail(string email)
        {
            var selectedUser = _userDal.Get(x => x.Email == email);
            if (selectedUser == null)
                return new ErrorDataResult<User>();
            return new SuccessDataResult<User>(selectedUser);
        }

        public IResult CheckUserById(string userId)
        {
            var result = _userDal.Get(x => x.Id == userId);
            if (result == null)
                return new ErrorResult("User not found");
            return new SuccessResult();
        }

        public IResult CheckUserByEmail(string email)
        {
            var result =  _userDal.Get(x => x.Email == email);
            if (result == null)
                return new ErrorResult("User not found");
            return new SuccessResult();
        }


    }
}
