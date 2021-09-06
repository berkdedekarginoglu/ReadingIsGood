using ReadingIsGood.Core.Entities;
using System;

namespace ReadingIsGood.Core.Entities.Concrete
{
    public class BookImage : IEntity
    {
        public string Id { get; set; }
        public string BookId { get; set; }
        public string ImagePath{ get; set; }
        public Book Book { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
