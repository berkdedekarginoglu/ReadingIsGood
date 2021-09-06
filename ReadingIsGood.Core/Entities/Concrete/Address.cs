using System.Collections.Generic;

namespace ReadingIsGood.Core.Entities.Concrete
{
    public class Address : IEntity
    {
        public string Id { get; set; }
        public int CityId { get; set; }
        public string Details { get; set; }
        public City City { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<UserAddress> UserAddress { get; set; }
    }
}