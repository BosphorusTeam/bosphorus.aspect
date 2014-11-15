using Bosphorus.Aspect.Core;
using Bosphorus.Aspect.Core.Aspect;

namespace Bosphorus.Aspect.Exception
{
    public interface IExceptionAspect<TService> : IServiceAspect<TService>
    {
    }
}