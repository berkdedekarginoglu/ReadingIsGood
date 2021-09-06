using ReadingIsGood.Core.DataAccess.EntityFramework;
using ReadingIsGood.Core.Entities;
using ReadingIsGood.DataAccess.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Entities.DTOs;

namespace ReadingIsGood.DataAccess.Concrete.EntityFramework
{
    public class EfAddressDal : EfEntityRepositoryBase<Address, EfReadingIsGoodContext>, IAddressDal
    {
        public List<GetAddressDto> GetAddressesByUserId(string userId)
        {
            using var context = new EfReadingIsGoodContext();
            var result = from addresses in context.Addresses
                         join useradresses in context.UserAddresses on addresses.Id equals useradresses.AddressId
                         where useradresses.UserId == userId
                         select new GetAddressDto
                         {
                             Id = addresses.Id,
                             CityName = addresses.City.CityName,
                             Details = addresses.Details
                         };
                         

            return result.ToList();
        }

        
    }
}
