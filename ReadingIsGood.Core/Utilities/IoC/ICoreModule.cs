using Microsoft.Extensions.DependencyInjection;

namespace ReadingIsGood.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
    
}
