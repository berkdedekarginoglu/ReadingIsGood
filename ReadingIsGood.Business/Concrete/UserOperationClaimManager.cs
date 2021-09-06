using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Business.Constants;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.DataAccess.Abstract;
using ReadingIsGood.Entitties.DTOs;
using System;
using System.Collections.Generic;

namespace ReadingIsGood.Business.Concrete
{
    public class UserOperationClaimManager:IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public IResult Add(UserOperationClaim UserOperationClaimd)
        {
          
            _userOperationClaimDal.Add(UserOperationClaimd);
            return new SuccessResult(Messages.OperationClaimAdded);
        }

        
        public IResult Delete(UserOperationClaim entity)
        {
            
            var entityToDelete = GetById(entity.Id).Data;
            _userOperationClaimDal.Delete(entityToDelete);
            return new SuccessResult();
        }

       
        public IResult Update(UserOperationClaim entity)
        {
            _userOperationClaimDal.Update(entity);
            return new SuccessResult();
        }

       
        public IDataResult<UserOperationClaim> GetById(string id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(u => u.Id == id));
        }

        
        public IDataResult<ICollection<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<ICollection<UserOperationClaim>>(_userOperationClaimDal.GetAll());
        }

        
        public IDataResult<ICollection<UserOperationClaim>> GetByClaimId(string claimId)
        {
            return new SuccessDataResult<ICollection<UserOperationClaim>>(
                _userOperationClaimDal.GetAll(u => u.Id == claimId));
        }

       
        public IDataResult<ICollection<UserOperationClaim>> GetByUserId(string userId)
        {
            return new SuccessDataResult<ICollection<UserOperationClaim>>(
                _userOperationClaimDal.GetAll(u => u.UserId == userId));
        }

        public IResult AddForSuperUser(UserOperationClaim entity)
        {
          
            _userOperationClaimDal.Add(entity);
            return new SuccessResult();
        }

      
    }
}
