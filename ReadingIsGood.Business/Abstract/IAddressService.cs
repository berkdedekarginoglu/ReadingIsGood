using ReadingIsGood.Core.Business;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadingIsGood.Business.Abstract
{
    public interface IAddressService : IServiceRepository<GetAddressDto>
    {
        IResult Add(AddAddressDto addAddressDto);
        IDataResult<ICollection<GetAddressDto>> GetByUserId(string customerId);

    }
}
