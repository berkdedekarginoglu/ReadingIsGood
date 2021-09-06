using ReadingIsGood.Core.DataAccess;
using ReadingIsGood.Core.Entities;
using ReadingIsGood.Core.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadingIsGood.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
