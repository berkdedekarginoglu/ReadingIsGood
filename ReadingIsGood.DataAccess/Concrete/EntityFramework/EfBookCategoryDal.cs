using ReadingIsGood.Core.DataAccess.EntityFramework;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.DataAccess.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadingIsGood.DataAccess.Concrete.EntityFramework
{
    public class EfBookCategoryDal : EfEntityRepositoryBase<BookCategory, EfReadingIsGoodContext>, IBookCategoryDal
    {
        public void AddBulk(IEnumerable<BookCategory> bookCategories)
        {
            using var context = new EfReadingIsGoodContext();
            context.Set<BookCategory>().AddRange(bookCategories);
            context.SaveChanges();
        }
    }
}
