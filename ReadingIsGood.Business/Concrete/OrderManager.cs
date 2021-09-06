using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Business.Constants;
using ReadingIsGood.Business.Utilities.Helpers;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Business;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.DataAccess.Abstract;
using ReadingIsGood.Entities.DTOs;
using System;
using System.Collections.Generic;

namespace ReadingIsGood.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        
        private readonly IOrderDal _orderDal;
        private readonly IOrderStatusService _orderStatusService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IBookService _bookSerivce;

        public OrderManager(IOrderDal orderDal,IOrderStatusService orderStatusService,IBookService bookService,IOrderDetailService orderDetailService)
        {
            
            _bookSerivce = bookService;
            _orderDal = orderDal;
            _orderStatusService = orderStatusService;
            _orderDetailService = orderDetailService;
        }

        public IResult Add(AddOrderDto addOrderDto)
        {

            var selectedBook = _bookSerivce.GetById(addOrderDto.BookId);
            if (!selectedBook.Success)
                return new ErrorDataResult<string>(Messages.BookNotFound);

            var checkRules = BusinessRules.Run(CheckStock(selectedBook.Data.Id, addOrderDto.Quantity));
            if (!checkRules.Success)
                return new ErrorDataResult<string>(checkRules.Message);


            var createdOrder = new Order();

            createdOrder.AddressId = addOrderDto.AddressId;
            createdOrder.UserId = addOrderDto.UserId;
            createdOrder.Id = Guid.NewGuid().ToString();
            createdOrder.OrderStatusId = _orderStatusService.GetByName("Pending").Data.Id;
            createdOrder.RequiredDate = DateTime.Now;
            createdOrder.OrderNo = StringGenerators.GenerateOrderNo();

            _orderDal.Add(createdOrder);


            var orderDetail = new OrderDetail
            {
                Id = Guid.NewGuid().ToString(),
                BookId = addOrderDto.BookId,
                OrderId = createdOrder.Id,
                Quantity = addOrderDto.Quantity,
                UnitPrice = selectedBook.Data.UnitPrice
            };

            var orderDetailResult = _orderDetailService.Add(orderDetail);
            if (!orderDetailResult.Success)
                return new ErrorResult();

            return new SuccessResult(Messages.OrderAdded);

        }
        public IDataResult<GetOrderDto> Get(string orderNo,string userId)
        {
            var order = _orderDal.GetOrder(orderNo, userId);
            if (order == null)
                return new ErrorDataResult<GetOrderDto>(Messages.OrderNotFound);
            return new SuccessDataResult<GetOrderDto>(order);
        }
        public IDataResult<ICollection<GetOrderDto>> GetAll(string userId)
        {
            var orders = _orderDal.GetOrders(userId);
            if (orders.Count < 0)
                return new ErrorDataResult<ICollection<GetOrderDto>>(Messages.OrderNotFound);
            return new SuccessDataResult<ICollection<GetOrderDto>>(orders);
        }
        private IResult CheckStock(string bookId,int quantity)
        {
            return _bookSerivce.GetById(bookId).Data.UnitsInStock < quantity ? new ErrorResult(Messages.NotEnoughStock) : new SuccessResult();

        }
    }
}
