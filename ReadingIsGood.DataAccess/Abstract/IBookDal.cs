using ReadingIsGood.Core.DataAccess;
using ReadingIsGood.Core.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadingIsGood.DataAccess.Abstract
{
    public interface IBookDal : IEntityRepository<Book>
    {
       List<Book> GetBooksByCategoryId(string categoryId,int currentPage, int dataPerPage);
       List<Book> GetBooksByAuthorId(string authorId, int currentPage, int dataPerPage);
    }
}
