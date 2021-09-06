using System.Collections.Generic;

namespace ReadingIsGood.Entities.DTOs
{
    public class AddBookCategoryDto
    {
        public IEnumerable<string> CategoryIds { get; set; }
        public string BookId { get; set; }
    }
}
