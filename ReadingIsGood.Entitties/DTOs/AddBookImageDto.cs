using ReadingIsGood.Core.Entities;

namespace ReadingIsGood.Entities.DTOs
{
    public class AddBookImageDto : IDto
    {
        public string BookId { get; set; }
        public string ImagePath { get; set; }
    }
}
