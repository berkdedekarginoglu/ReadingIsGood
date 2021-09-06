using ReadingIsGood.Core.Entities;
using System.Collections.Generic;

namespace ReadingIsGood.Core.Entities.Concrete
{
    public class Category : IEntity
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }

        public IEnumerable<BookCategory> BookCategories { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
