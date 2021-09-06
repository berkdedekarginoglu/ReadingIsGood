using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;

namespace ReadingIsGood.Business.Abstract
{
    public interface IOrderDetailService
    {
        IResult Add(OrderDetail orderDetail);
    }
}
