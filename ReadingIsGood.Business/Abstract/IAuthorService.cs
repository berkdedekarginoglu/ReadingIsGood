using ReadingIsGood.Core.Business;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.Entities.DTOs;
using System.Collections.Generic;

namespace ReadingIsGood.Business.Abstract
{
    public interface IAuthorService : IServiceRepository<GetAuthorDto>
    {
        IResult Add(AddAuthorDto author);
        IResult Update(UpdateAuthorDto author);
        IResult DeleteById(string id);
        IDataResult<ICollection<GetAuthorDto>> GetAll(int currentPage, int dataCountOfPage);
    }
}
