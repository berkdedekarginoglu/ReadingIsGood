using ReadingIsGood.Business.Adapters.ISBNService;
using System;
using System.Threading.Tasks;

namespace ReadingIsGood.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IISBNService service = new DataFlexServiceManager();
            await service.VerifyISBNAsync("9786052118689");
        }
    }
}
