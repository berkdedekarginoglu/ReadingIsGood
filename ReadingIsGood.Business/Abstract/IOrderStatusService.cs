using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.Entities.DTOs;

namespace ReadingIsGood.Business.Abstract
{
    public interface IOrderStatusService
    {
        IResult Add(AddOrderStatus addOrderStatus);
        IResult Update(UpdateOrderStatusDto updateOrderStatus);
        IDataResult<OrderStatus> GetByName(string orderStatusName);
        IDataResult<OrderStatus> GetById(string orderStatusId);

    }
}
