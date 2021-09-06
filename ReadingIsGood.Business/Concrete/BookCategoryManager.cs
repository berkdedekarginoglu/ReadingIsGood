using ReadingIsGood.Business.Abstract;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.DataAccess.Abstract;
using ReadingIsGood.Entities.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingIsGood.Business.Concrete
{
    public class BookCategoryManager : IBookCategoryService
    {
        private readonly IBookCategoryDal _bookCategoryDal;

        public BookCategoryManager(IBookCategoryDal bookCategoryDal)
        {
            _bookCategoryDal = bookCategoryDal;
        }
        public IResult Add(AddBookCategoryDto addBookCategoryDto)
        {

            var bookCategories = addBookCategoryDto.CategoryIds.Select(x =>
            {
                return new BookCategory
                {
                    Id = Guid.NewGuid().ToString(),
                    BookId = addBookCategoryDto.BookId,
                    CategoryId = x
                };
            });

            _bookCategoryDal.AddBulk(bookCategories);

            return new SuccessResult();
        }
    }
}
