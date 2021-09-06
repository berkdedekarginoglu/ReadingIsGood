using ReadingIsGood.Core.Utilities.Results;
using System.Threading.Tasks;

namespace ReadingIsGood.Business.Adapters.ISBNService
{
    public interface IISBNService
    {
        Task<IResult> VerifyISBNAsync(string isbn);

        IResult VerifyISBN(string isbn);
    }
}
