using System;

namespace ReadingIsGood.Core.Entities.Concrete
{
    public class Order : IEntity
    {

        public string Id { get; set; }
        public string OrderNo { get; set; }
        public string OrderStatusId { get; set; }

        public string UserId { get; set; }
        public string AddressId { get; set; }
        public Address Address { get; set; }
        public User User { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        

    }
}
