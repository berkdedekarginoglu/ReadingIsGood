using ReadingIsGood.Core.Utilities.Results;
using RestSharp;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReadingIsGood.Business.Adapters.ISBNService
{
    public class DataFlexServiceManager : IISBNService
    {
        public async Task<IResult> VerifyISBNAsync(string isbn)
        {
            return await VerifyAsync(isbn);
        }

        public IResult VerifyISBN(string isbn)
        {
            var result = VerifyAsync(isbn).ContinueWith(ct =>
            {
                return ct.Result;
            });

            Task.WaitAll(result);
            return result.Result;
        }
        private static async Task<IResult> VerifyAsync(string sISBN)
        {
            var client = new RestClient("http://webservices.daehosting.com/services/ISBNService.wso/IsValidISBN13");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddHeader("Host", "webservices.daehosting.com");

            var body = JsonSerializer.Serialize(new sISBNModel(sISBN));
            request.AddParameter("application/json; charset=utf-8", body, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.Content == "false")
                return new ErrorResult();
            return new SuccessResult();
        }

        private struct sISBNModel
        {
            public sISBNModel(string isbn)
            {
                sISBN = isbn;
            }
            public string sISBN { get; private set; }
        }
    }
}
