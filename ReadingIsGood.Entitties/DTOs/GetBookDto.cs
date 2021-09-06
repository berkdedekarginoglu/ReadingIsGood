using ReadingIsGood.Core.Entities;
using System;

namespace ReadingIsGood.Entities.DTOs
{
    public class GetBookDto : IDto
    {
        public string Id { get; set; }
        public string ISBN { get; set; }
        public string AuthorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public int UnitsInStock { get; set; }
        public int YearOfPublication { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
