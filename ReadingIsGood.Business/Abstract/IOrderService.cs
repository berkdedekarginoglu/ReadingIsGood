using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.Entities.DTOs;
using System.Collections.Generic;

namespace ReadingIsGood.Business.Abstract
{
    public interface IOrderService
    {
        IResult Add(AddOrderDto addOrderDto);
        IDataResult<GetOrderDto> Get(string Id,string userId);
        IDataResult<ICollection<GetOrderDto>> GetAll(string userId);
       
       
    }
}
