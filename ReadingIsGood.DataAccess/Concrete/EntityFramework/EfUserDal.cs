using ReadingIsGood.Core.DataAccess.EntityFramework;
using ReadingIsGood.DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;
using ReadingIsGood.Core.Entities.Concrete;

namespace ReadingIsGood.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User,EfReadingIsGoodContext> ,IUserDal
    {
        public  List<OperationClaim> GetClaims(User user)
        {
            using var context = new EfReadingIsGoodContext();
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return  result.ToList();
            
        }
    }
}
