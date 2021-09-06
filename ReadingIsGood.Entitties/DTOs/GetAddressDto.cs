using ReadingIsGood.Core.Entities;

namespace ReadingIsGood.Entities.DTOs
{
    public class GetAddressDto : IDto
    {
        public string Id { get; set; }
        public string CityName { get; set; }
        public string Details { get; set; }
    }
}
