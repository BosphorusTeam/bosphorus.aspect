using Bosphorus.Aspect.Core.Aspect;
using Castle.DynamicProxy;

namespace Bosphorus.Aspect.Default
{
    public class DefaultAspect<TService> : IDefaultAspect<TService>
    {
        private readonly InvocationContextProvider invocationContextProvider;

        public DefaultAspect(InvocationContextProvider invocationContextProvider)
        {
            this.invocationContextProvider = invocationContextProvider;
        }

        public void Intercept(IInvocation invocation)
        {
            InvocationContext invocationContext = new InvocationContext();
            invocationContextProvider.Register(invocationContext);
            try
            {
                invocation.Proceed();
            }
            finally
            {
                invocationContextProvider.Unregister(invocationContext);    
            }
            
        }
    }
}
