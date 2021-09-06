using System.Collections.Generic;

namespace ReadingIsGood.Core.Entities.Concrete
{
    public class OrderStatus : IEntity
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
