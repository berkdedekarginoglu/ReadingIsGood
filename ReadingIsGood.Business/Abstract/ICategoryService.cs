using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.Entities.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReadingIsGood.Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(AddCategoryDto addCategoryDto);

        IDataResult<ICollection<GetCategoryDto>> GetAllCategories();

        IResult CheckCategories(string[] categoryIds);
    }
}
