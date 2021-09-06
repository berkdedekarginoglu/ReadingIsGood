
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ReadingIsGood.Core.Entities.Concrete
{
    public class OrderDetail : IEntity
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public string BookId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        [NotMapped]
        public decimal TotalPrice { get { return UnitPrice * Quantity; } }
        public Order Order { get; set; }
    }
}
