using Bosphorus.Common.Core.Context;
using Castle.DynamicProxy;

namespace Bosphorus.Aspect.Core.Aspect
{
    public abstract class AbstractServiceAspect<TService>: IServiceAspect<TService>
    {
        private readonly IContextProvider<InvocationContext> invocationContextProvider;

        protected AbstractServiceAspect(IContextProvider<InvocationContext> invocationContextProvider)
        {
            this.invocationContextProvider = invocationContextProvider;
        }

        public void Intercept(IInvocation invocation)
        {
            InvocationContext invocationContext = invocationContextProvider.Get();
            Intercept(invocationContext, invocation);
        }

        protected abstract void Intercept(InvocationContext invocationContext, IInvocation invocation);
    }
}
