using ReadingIsGood.Core.Entities;

namespace ReadingIsGood.Core.Entities.Concrete
{
    public class BookCategory : IEntity
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public string BookId { get; set; }

        public Category Category { get; set; }

        public Book Book { get; set; }
    }
}
