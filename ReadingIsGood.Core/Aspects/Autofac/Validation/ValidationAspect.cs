using Castle.DynamicProxy;
using Core.Constants;
using FluentValidation;
using FluentValidation.Results;
using ReadingIsGood.Core.CrossCuttingConcerncs.Validation.FluentValidation;
using ReadingIsGood.Core.Utilities.Helpers.InterceptorHelpers;
using ReadingIsGood.Core.Utilities.Interceptors;
using ReadingIsGood.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingIsGood.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        private List<ValidationFailure> _errors;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception(Messages.ValidationClassIsNotValid);
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                _errors = ValidationTool.Validate(validator, entity);
            }
            
            if (_errors != null) Invoke = false;
        }

        protected override void OnAfter(IInvocation invocation)
        {
            Invoke = true;
            if (_errors != null)
            {
                var validationErrors = new List<string>();
                
                foreach (var error in _errors) validationErrors.Add(error.ErrorMessage);

                AutofacInterceptorHelper.ChangeReturnValue(invocation, typeof(ValidationErrorDataResult<>),
                     validationErrors,
                     "Validation Error");
            }
        }
    }
}
