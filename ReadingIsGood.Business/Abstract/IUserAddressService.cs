using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadingIsGood.Business.Abstract
{
    public interface IUserAddressService
    {
        IResult Add(AddUserAddressDto addYserAddressDto);

        ICollection<UserAddress> GetByUserId(string userId);
    }
}
