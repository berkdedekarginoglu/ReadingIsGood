using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.Entitties.DTOs;
using System.Collections.Generic;

namespace ReadingIsGood.Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IResult Add(UserOperationClaim UserOperationClaim);
    }
}
