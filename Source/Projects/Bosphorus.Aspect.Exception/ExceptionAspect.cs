using Castle.DynamicProxy;

namespace Bosphorus.Aspect.Exception
{
    public class ExceptionAspect<TService>: IExceptionAspect<TService>
    {
        public void Intercept(IInvocation invocation)
        {
            try
            {
                invocation.Proceed();
            }
            catch (System.Exception exception)
            {
                throw new GenericServiceExecutionException<TService>(invocation, exception);
            }
        }
    }
}
