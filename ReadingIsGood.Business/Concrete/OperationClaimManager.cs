using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Business.Constants;
using ReadingIsGood.Core.Aspects.Autofac.Authorization;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.DataAccess.Abstract;
using ReadingIsGood.Entitties.DTOs;
using System;
using System.Collections.Generic;

namespace ReadingIsGood.Business.Concrete
{
    [SecuredOperation("Admin")]
    public class OperationClaimManager :  IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;
        private readonly IUserOperationClaimService _userOperationClaimService;
        private readonly IUserService _userService;
        public OperationClaimManager(IOperationClaimDal operationClaimDal, IUserOperationClaimService userOperationClaimService, IUserService userService)
        {
            _operationClaimDal = operationClaimDal;
            _userOperationClaimService = userOperationClaimService;
            _userService = userService;
        }

       
        public IResult Add(AddOperationClaimDto addOperationClaimDto)
        {
            var checkUser = _userService.CheckUserById(addOperationClaimDto.UserId);
            if (!checkUser.Success)
                return new ErrorResult(Messages.UserNotFound);

            var newOperationClaim = new OperationClaim
            {
                Id = Guid.NewGuid().ToString(),
                Name = addOperationClaimDto.Name
            };

            _operationClaimDal.Add(newOperationClaim);

            var added = _userOperationClaimService.Add(new UserOperationClaim
            {
                Id = Guid.NewGuid().ToString(),
                OperationClaimId = newOperationClaim.Id,
                UserId = addOperationClaimDto.UserId
            });

            if(!added.Success)
                return new ErrorResult();
            return new SuccessResult(added.Message);
        }

     
        public IResult Delete(OperationClaim operationClaim)
        {
          
            var entityToDelete = GetById(operationClaim.Id).Data;

            _operationClaimDal.Delete(entityToDelete);
            return new SuccessResult();
        }

       
        public IResult Update(OperationClaim entity)
        {
           
            _operationClaimDal.Update(entity);
            return new SuccessResult();
        }

      
        public IDataResult<OperationClaim> GetById(string id)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(o => o.Id == id));
        }

       
        public IDataResult<ICollection<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<ICollection<OperationClaim>>(_operationClaimDal.GetAll());
        }

        
        public IDataResult<OperationClaim> GetByName(string operationClaimName)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(o => o.Name == operationClaimName));
        }
    }
}
