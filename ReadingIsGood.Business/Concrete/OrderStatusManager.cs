using AutoMapper;
using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Business.Constants;
using ReadingIsGood.Business.Mapper2.Autofac;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.DataAccess.Abstract;
using ReadingIsGood.Entities.DTOs;
using System;

namespace ReadingIsGood.Business.Concrete
{
    public class OrderStatusManager : IOrderStatusService
    {
        private readonly IOrderStatusDal _orderStatusDal;
        public OrderStatusManager(IOrderStatusDal orderStatusDal)
        {
            _orderStatusDal = orderStatusDal;
        }
        public IResult Add(AddOrderStatus addOrderStatus)
        {
            var createdOrderStatus = ObjectMapper.Mapper.Map<OrderStatus>(addOrderStatus);
            createdOrderStatus.Id = Guid.NewGuid().ToString();

            _orderStatusDal.Add(createdOrderStatus);

            return new SuccessResult(Messages.OrderStatusAdded);
        }
        public IResult Update(UpdateOrderStatusDto updateOrderStatus)
        {
            var selectedOrderStatus = _orderStatusDal.Get(x => x.Id == updateOrderStatus.Id);
            var modifiedOrderStatus = ObjectMapper.Mapper.Map<OrderStatus>(updateOrderStatus);
            _orderStatusDal.Update(modifiedOrderStatus);
            return new SuccessResult(Messages.OrderStatusUpdated);
        }
        public IDataResult<OrderStatus> GetById(string orderStatusId)
        {
            var selectedOrderStatus = _orderStatusDal.Get(x => x.Id == orderStatusId);

            if (selectedOrderStatus == null)
                return new ErrorDataResult<OrderStatus>(Messages.OrderStatusNotFound);
            return new SuccessDataResult<OrderStatus>(selectedOrderStatus);
        }
        public IDataResult<OrderStatus> GetByName(string orderStatusName)
        {
            var selectedOrderStatus = _orderStatusDal.Get(x => x.Status == orderStatusName);

            if (selectedOrderStatus == null)
                return new ErrorDataResult<OrderStatus>(Messages.OrderStatusNotFound);
            return new SuccessDataResult<OrderStatus>(selectedOrderStatus);
        }
        
    }
}
