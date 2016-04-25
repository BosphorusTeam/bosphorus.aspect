using Bosphorus.Common.Api.Context.Listener;
using Bosphorus.Common.Application.Scope.Invocation;
using Castle.DynamicProxy;

namespace Bosphorus.Aspect.Default
{
    public class DefaultAspect<TService> : IDefaultAspect<TService>
    {
        private readonly DefaultContextInvoker<InvocationContext> defaultContextInvoker;

        public DefaultAspect(DefaultContextInvoker<InvocationContext> defaultContextInvoker)
        {
            this.defaultContextInvoker = defaultContextInvoker;
        }

        public void Intercept(IInvocation invocation)
        {
            InvocationContext invocationContext = new InvocationContext();
            defaultContextInvoker.InvokeStarted(invocationContext);
            try
            {
                invocation.Proceed();
            }
            finally
            {
                defaultContextInvoker.InvokeFinished(invocationContext);
            }
        }
    }
}
