using ReadingIsGood.Core.Entities.Concrete;
using System.Collections.Generic;

namespace ReadingIsGood.Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
