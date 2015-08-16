using Castle.DynamicProxy;

namespace Bosphorus.Aspect.Core.Aspect
{
    public interface IAspect: IInterceptor
    {
    }

    // ReSharper disable once UnusedTypeParameter
    public interface IAspect<TService> : IAspect
    {
    }
}
