using Microsoft.AspNetCore.Http;
using ReadingIsGood.Core.Utilities.Results;
using ReadingIsGood.Entities.DTOs;
using System.Threading.Tasks;

namespace ReadingIsGood.Business.Abstract
{
    public interface IBookImageService
    {
        IResult Add(AddBookImageDto addBookImageDto);

    }
}
