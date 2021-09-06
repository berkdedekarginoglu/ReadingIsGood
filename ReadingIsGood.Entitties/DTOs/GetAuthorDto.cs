using ReadingIsGood.Core.Entities;

namespace ReadingIsGood.Entities.DTOs
{
    public class GetAuthorDto : IDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
