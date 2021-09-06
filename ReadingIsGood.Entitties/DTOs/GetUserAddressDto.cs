using ReadingIsGood.Core.Entities;

namespace ReadingIsGood.Entities.DTOs
{
    public class GetUserAddressDto : IDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string AddressId { get; set; }
    }
}
