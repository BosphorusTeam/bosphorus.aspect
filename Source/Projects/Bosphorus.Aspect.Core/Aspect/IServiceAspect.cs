using Castle.DynamicProxy;

namespace Bosphorus.Aspect.Core.Aspect
{
    public interface IServiceAspect: IInterceptor
    {
    }

    public interface IServiceAspect<TService> : IServiceAspect
    {
    }
}
