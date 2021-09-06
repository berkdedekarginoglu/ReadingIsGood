using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.Entities.DTOs;
using System.Threading.Tasks;

namespace ReadingIsGood.Business.Abstract
{
    public interface IBookCategoryService
    {
        IResult Add(AddBookCategoryDto addBookCategoryDto);
    }
}
