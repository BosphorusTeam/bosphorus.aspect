using Bosphorus.Aspect.Core.Aspect;
using Bosphorus.Common.Core.Context;
using Castle.DynamicProxy;

namespace Bosphorus.Aspect.Exception
{
    public class ExceptionAspect<TService>: AbstractServiceAspect<TService>, IExceptionAspect<TService>
    {
        public ExceptionAspect(IContextProvider<InvocationContext> invocationContextProvider) 
            : base(invocationContextProvider)
        {
        }

        protected override void Intercept(InvocationContext invocationContext, IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (System.Exception exception)
            {
                throw new GenericServiceExecutionException<TService>(invocationContext, invocation, exception);
            }
        }
    }
}
