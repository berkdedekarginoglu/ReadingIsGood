using ReadingIsGood.Core.Entities;
using ReadingIsGood.Core.Utilities.Results;
using System.Threading.Tasks;

namespace ReadingIsGood.Core.Business
{
    public interface IServiceRepository<TDto>
        where TDto : class,IDto,new()
    {
        IDataResult<TDto> GetById(string entityId);
    }
}
