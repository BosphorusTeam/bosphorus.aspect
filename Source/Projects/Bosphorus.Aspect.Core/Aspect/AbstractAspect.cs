using Bosphorus.Common.Core.Application;
using Bosphorus.Common.Core.Context;
using Castle.DynamicProxy;

namespace Bosphorus.Aspect.Core.Aspect
{
    public abstract class AbstractAspect<TService>: IAspect<TService>
    {
        private readonly GenericContextProvider genericContextProvider;

        protected AbstractAspect(GenericContextProvider genericContextProvider)
        {
            this.genericContextProvider = genericContextProvider;
        }

        public void Intercept(IInvocation invocation)
        {
            ApplicationContext applicationContext = genericContextProvider.Get<ApplicationContext>();
            CallContext callContext = genericContextProvider.Get<CallContext>();
            InvocationContext invocationContext = genericContextProvider.Get<InvocationContext>();
            Intercept(applicationContext, callContext, invocationContext, invocation);
        }

        protected abstract void Intercept(ApplicationContext applicationContext, CallContext callContext, InvocationContext invocationContext, IInvocation invocation);
    }
}
