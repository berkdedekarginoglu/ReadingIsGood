using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.Entitties.DTOs;
using System.Collections.Generic;

namespace ReadingIsGood.Business.Abstract
{
    public interface IOperationClaimService
    {
        IResult Add(AddOperationClaimDto addOperationClaimDto);
        IResult Delete(OperationClaim operationClaim);
        IResult Update(OperationClaim operationClaim);
        IDataResult<OperationClaim> GetById(string id);
        IDataResult<ICollection<OperationClaim>> GetAll();
        IDataResult<OperationClaim> GetByName(string operationClaimName);
    }
}
