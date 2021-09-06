using ReadingIsGood.Core.DataAccess.EntityFramework;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.DataAccess.Abstract;

namespace ReadingIsGood.DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, EfReadingIsGoodContext>,
        IUserOperationClaimDal
    {
    }
}
