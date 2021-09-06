using AutoMapper;
using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Business.Constants;
using ReadingIsGood.Business.Mapper2.Autofac;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Business;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.DataAccess.Abstract;
using ReadingIsGood.Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ReadingIsGood.Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;
        private readonly IUserService _userService;
        private readonly IUserAddressService _customerAddressService;
        public AddressManager(IAddressDal addressDal, IUserService userService, IUserAddressService customerAddressService)
        {
            _addressDal = addressDal;
            _userService = userService;
            _customerAddressService = customerAddressService;
        }

        public  IResult Add(AddAddressDto addAddressDto)
        {
            var rulesCheck = BusinessRules.Run(_userService.CheckUserById(addAddressDto.UserId),CheckUserAddressCount(addAddressDto.UserId));

            if (!rulesCheck.Success)
                return new ErrorDataResult<IEnumerable<GetAddressDto>>(rulesCheck.Message);

            var createdAddress = ObjectMapper.Mapper.Map<Address>(addAddressDto);
            createdAddress.Id = Guid.NewGuid().ToString();

            _addressDal.Add(createdAddress);

            var userAddressDto = new AddUserAddressDto{ AddressId = createdAddress.Id, UserId = addAddressDto.UserId };

            var result = _customerAddressService.Add(userAddressDto);

            if (!result.Success)
                return new ErrorResult(result.Message);
            return new SuccessResult(Messages.AddressAdded);
        }
        public IDataResult<ICollection<GetAddressDto>> GetByUserId(string customerId)
        {
            var checkUser =  _userService.CheckUserById(customerId);
            if (!checkUser.Success)
                return new ErrorDataResult<ICollection<GetAddressDto>>(Messages.UserNotFound);

            var addresses =  _addressDal.GetAddressesByUserId(customerId);

            return new SuccessDataResult<ICollection<GetAddressDto>>(addresses);
        }
        public  IDataResult<GetAddressDto> GetById(string entityId)
        {
            var selectedAddress = _addressDal.Get(x => x.Id == entityId);
            if (selectedAddress == null)
                return new ErrorDataResult<GetAddressDto>();
            return new SuccessDataResult<GetAddressDto>(ObjectMapper.Mapper.Map<GetAddressDto>(selectedAddress));
        }
        private IResult CheckUserAddressCount(string userId)
        {
            var result = _customerAddressService.GetByUserId(userId);
            return (result != null && result.Count > 3) ? new ErrorResult(Messages.AddressLimitExceed) : new SuccessResult();
        }

        
    }
}
