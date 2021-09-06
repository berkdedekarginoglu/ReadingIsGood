using ReadingIsGood.Core.DataAccess;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Entities.DTOs;
using System.Collections.Generic;

namespace ReadingIsGood.DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        ICollection<GetOrderDto> GetOrders(string userId);

        GetOrderDto GetOrder(string id,string userId);
    }
}
