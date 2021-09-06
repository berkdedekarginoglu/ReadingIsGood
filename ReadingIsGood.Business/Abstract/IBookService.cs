using ReadingIsGood.Core.Business;
using ReadingIsGood.Core.Entities.Concrete;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.Entities.DTOs;
using System.Collections.Generic;

namespace ReadingIsGood.Business.Abstract
{
    public interface IBookService : IServiceRepository<GetBookDto>
    {
        IResult Add(AddBookDto addBookDto);
        IResult Update(UpdateBookDto updateBookDto);
        IDataResult<ICollection<GetBookDto>> GetBooksByAuthorId(string authorId, int currentPage = 1, int dataPerPage = 25);
        IDataResult<ICollection<GetBookDto>> GetBooksByCategoryId(string categoryId, int currentPage = 1, int dataPerPage = 25);
        IDataResult<IEnumerable<Book>> GetOnRecorderLevels(int nearRecorder, int currentPage);
    }
}
