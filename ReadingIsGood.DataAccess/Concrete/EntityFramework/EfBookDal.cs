using Microsoft.EntityFrameworkCore;
using ReadingIsGood.Core.DataAccess.EntityFramework;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ReadingIsGood.DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, EfReadingIsGoodContext>, IBookDal
    {
        public List<Book> GetBooksByAuthorId(string authorId, int currentPage, int dataPerPage)
        {
            using var context = new EfReadingIsGoodContext();

            var result = from books in context.Books
                         where books.AuthorId == authorId
                         select new Book
                         {
                             Id = books.Id,
                             AuthorId = books.AuthorId,
                             CreatedAt = books.CreatedAt,
                             Description = books.Description,
                             IsActive = books.IsActive,
                             Name = books.Name,
                             Pages = books.Pages,
                             UnitPrice = books.UnitPrice,
                             UnitsInStock = books.UnitsInStock,
                             UpdatedAt = books.UpdatedAt,
                             YearOfPublication = books.YearOfPublication,

                         };

            return result.Skip((currentPage - 1) * dataPerPage).Take(dataPerPage).ToList();
        }

        public List<Book> GetBooksByCategoryId(string categoryId,int currentPage,int dataPerPage)
        {
            using var context = new EfReadingIsGoodContext();
            
            var result = from bookCategories in context.BookCategories
                         join books in context.Books
                         on bookCategories.BookId equals books.Id
                         where bookCategories.CategoryId == categoryId
                         select new Book
                             {
                                 Id = books.Id,
                                 AuthorId = books.AuthorId,
                                 CreatedAt = books.CreatedAt,
                                 Description = books.Description,
                                 IsActive = books.IsActive,
                                 Name = books.Name,
                                 Pages = books.Pages,
                                 UnitPrice = books.UnitPrice,
                                 UnitsInStock = books.UnitsInStock,
                                 UpdatedAt = books.UpdatedAt,
                                 YearOfPublication = books.YearOfPublication,

                             };

            return result.Skip((currentPage-1)*dataPerPage).Take(dataPerPage).ToList();
        }

    }
}
