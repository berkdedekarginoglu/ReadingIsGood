using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.DataAccess.Abstract;
using ReadingIsGood.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadingIsGood.Business.Concrete
{
    public class UserAddressManager : IUserAddressService
    {
        private readonly IUserAddressDal _customerAddressDal;

        public UserAddressManager(IUserAddressDal customerAddressDal)
        {
            _customerAddressDal = customerAddressDal;
        }
        public IResult Add(AddUserAddressDto addUserAddressDto)
        {
            var createdCustomerAddress = new UserAddress
            {
                Id = Guid.NewGuid().ToString(),
                AddressId = addUserAddressDto.AddressId,
                UserId = addUserAddressDto.UserId
            };

            _customerAddressDal.Add(createdCustomerAddress);
            return new SuccessResult();
        }

        public ICollection<UserAddress> GetByUserId(string userId)
        {
            return _customerAddressDal.GetAll(x => x.UserId == userId);
            
        }
    }
}
