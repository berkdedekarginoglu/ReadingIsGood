using ReadingIsGood.Core.DataAccess.EntityFramework;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.DataAccess.Abstract;
using ReadingIsGood.Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace ReadingIsGood.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order,EfReadingIsGoodContext> , IOrderDal
    {
        public GetOrderDto GetOrder(string orderNo, string userId)
        {
            using var context = new EfReadingIsGoodContext();

            var result = from user in context.Users
                         join order in context.Orders
                         on user.Id equals order.UserId into table_order_user
                         from joined_order in table_order_user
                         join orderDetail in context.OrderDetails
                         on joined_order.Id equals orderDetail.OrderId into table_order_user_orderDetail
                         from joined_orderDetail in table_order_user_orderDetail
                         join book in context.Books
                         on joined_orderDetail.BookId equals book.Id
                         where joined_order.OrderNo == orderNo
                         select new GetOrderDto
                         {
                             OrderNo = joined_order.OrderNo,
                             AddressCity = joined_order.Address.City.CityName,
                             AddressDetails = joined_order.Address.Details,
                             BookDescription = book.Description,
                             BookISBN = book.ISBN,
                             BookName = book.Name,
                             BookPrice = book.UnitPrice,
                             Quantity = joined_orderDetail.Quantity,
                             OrderDate = joined_order.OrderDate,
                             RequiredDate = joined_order.RequiredDate,
                             ShippedDate = joined_order.ShippedDate,
                             TotalPrice = joined_orderDetail.TotalPrice,
                             Status = joined_order.OrderStatus.Status
                         };

            return result.First();
        }

        public ICollection<GetOrderDto> GetOrders(string userId)
        {
            using var context = new EfReadingIsGoodContext();

            var result = from user in context.Users
                         join order in context.Orders
                         on user.Id equals order.UserId into table_order_user
                         from joined_order in table_order_user
                         join orderDetail in context.OrderDetails
                         on joined_order.Id equals orderDetail.OrderId into table_order_user_orderDetail
                         from joined_orderDetail in table_order_user_orderDetail
                         join book in context.Books
                         on joined_orderDetail.BookId equals book.Id
                         where user.Id == userId
                         select new GetOrderDto
                         {
                             OrderNo = joined_order.OrderNo,
                             AddressCity = joined_order.Address.City.CityName,
                             AddressDetails = joined_order.Address.Details,
                             BookDescription = book.Description,
                             BookISBN = book.ISBN,
                             BookName = book.Name,
                             BookPrice = book.UnitPrice,
                             Quantity = joined_orderDetail.Quantity,
                             OrderDate = joined_order.OrderDate,
                             RequiredDate = joined_order.RequiredDate,
                             ShippedDate = joined_order.ShippedDate,
                             TotalPrice = joined_orderDetail.TotalPrice,
                             Status = joined_order.OrderStatus.Status
                         };

            return result.ToList();
        }


    }
}
