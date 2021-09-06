using ReadingIsGood.Core.Utilities.Results;

namespace ReadingIsGood.Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return new SuccessResult();
        }
    }
}
