using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ReadingIsGood.Core.Utilities.IoC;

namespace ReadingIsGood.Core.DependencyResolver
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
           
        }
    }
}
