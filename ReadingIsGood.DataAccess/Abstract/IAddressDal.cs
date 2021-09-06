using ReadingIsGood.Core.DataAccess;
using ReadingIsGood.Core.Entities;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadingIsGood.DataAccess.Abstract
{
    public interface IAddressDal : IEntityRepository<Address>
    {
        List<GetAddressDto> GetAddressesByUserId(string customerId);
    }
}
