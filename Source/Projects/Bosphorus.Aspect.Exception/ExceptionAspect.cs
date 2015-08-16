using Bosphorus.Aspect.Core.Aspect;
using Bosphorus.Common.Core.Application;
using Bosphorus.Common.Core.Context;
using Castle.DynamicProxy;

namespace Bosphorus.Aspect.Exception
{
    public class ExceptionAspect<TService>: AbstractAspect<TService>, IExceptionAspect<TService>
    {
        public ExceptionAspect(GenericContextProvider genericContextProvider) 
            : base(genericContextProvider)
        {
        }

        protected override void Intercept(ApplicationContext applicationContext, CallContext callContext, InvocationContext invocationContext, IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (System.Exception exception)
            {
                throw new GenericServiceExecutionException<TService>(applicationContext, invocationContext, invocation, exception);
            }
        }
    }
}
