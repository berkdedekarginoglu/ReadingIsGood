using ReadingIsGood.Core.Entities;
using System;
using System.Collections.Generic;

namespace ReadingIsGood.Core.Entities.Concrete
{
    public class Book : IEntity
    {
        public string Id { get; set; }
        public string AuthorId { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public int UnitsInStock { get; set; }
        public int YearOfPublication { get; set; }
        public decimal UnitPrice { get; set; }
        public int ReorderLevel { get; set; }
        public Author Author { get; set; }
        public IEnumerable<BookCategory> BookCategories { get; set; }
        public IEnumerable<BookImage> BookImages { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

    }
}
