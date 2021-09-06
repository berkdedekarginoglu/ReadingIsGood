using Castle.DynamicProxy;
using Core.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ReadingIsGood.Core.Extensions;
using ReadingIsGood.Core.Utilities.Helpers.InterceptorHelpers;
using ReadingIsGood.Core.Utilities.Interceptors;
using ReadingIsGood.Core.Utilities.IoC;
using ReadingIsGood.Core.Utilities.Results;
using System;
using System.Collections.Generic;

namespace ReadingIsGood.Core.Aspects.Autofac.Authorization
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }


        
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            Invoke = false;
        }

        protected override void OnAfter(IInvocation invocation)
        {
            
            AutofacInterceptorHelper.ChangeReturnValue(invocation, typeof(SecurityErrorDataResult<>), null,
                   Messages.AuthorizationDenied);
        }

      

       


    }
}
