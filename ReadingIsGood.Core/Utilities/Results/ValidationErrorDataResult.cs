using System.Collections.Generic;

namespace ReadingIsGood.Core.Utilities.Results
{
    public class ValidationErrorDataResult<T> : DataResult<T>
    {
        public ValidationErrorDataResult(List<string> validationErrors, string message) : base(default,
            false, message)
        {
            ValidationErrors = validationErrors;
        }

        public ValidationErrorDataResult(List<string> validationErrors) : base(default, false)
        {
            ValidationErrors = validationErrors;
        }

        public ValidationErrorDataResult() : base(default, false)
        {
        }

        public List<string> ValidationErrors { get; }
    }
}
