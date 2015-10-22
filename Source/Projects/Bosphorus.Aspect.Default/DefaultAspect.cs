using Bosphorus.Aspect.Core.Aspect;
using Bosphorus.Common.Core.Context;
using Bosphorus.Common.Core.Context.Invocation;
using Castle.DynamicProxy;

namespace Bosphorus.Aspect.Default
{
    public class DefaultAspect<TService> : IDefaultAspect<TService>
    {
        private readonly ContextInvoker<InvocationContext> contextInvoker;

        public DefaultAspect(ContextInvoker<InvocationContext> contextInvoker)
        {
            this.contextInvoker = contextInvoker;
        }

        public void Intercept(IInvocation invocation)
        {
            InvocationContext invocationContext = new InvocationContext();
            contextInvoker.InvokeStarted(invocationContext);
            try
            {
                invocation.Proceed();
            }
            finally
            {
                contextInvoker.InvokeFinished(invocationContext);
            }
        }
    }
}
