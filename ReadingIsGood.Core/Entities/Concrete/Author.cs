using ReadingIsGood.Core.Entities;
using System;
using System.Collections.Generic;

namespace ReadingIsGood.Core.Entities.Concrete
{
    public class Author : IEntity
    {
      
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
