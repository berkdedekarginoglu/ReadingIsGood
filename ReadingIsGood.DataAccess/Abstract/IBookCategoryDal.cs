using ReadingIsGood.Core.DataAccess;
using ReadingIsGood.Core.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadingIsGood.DataAccess.Abstract
{
    public interface IBookCategoryDal : IEntityRepository<BookCategory>
    {
        void AddBulk(IEnumerable<BookCategory> bookCategories);
    }
}
