using System.Collections.Generic;

namespace ReadingIsGood.Entities.DTOs
{
    public class UpdateBookDto
    {
        public string ISBN { get; set; }
        public string AuthorId { get; set; }
        public IEnumerable<string> CategoryIds { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public int UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public int YearOfPublication { get; set; }
    }
}
