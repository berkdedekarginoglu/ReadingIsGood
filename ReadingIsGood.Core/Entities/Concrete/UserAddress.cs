
namespace ReadingIsGood.Core.Entities.Concrete
{
    public class UserAddress : IEntity
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string AddressId { get; set; }
        public User User { get; set; }
        public Address Address { get; set; }
       
    }
}
