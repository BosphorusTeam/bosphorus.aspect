using System;
using Bosphorus.Aspect.Core.Aspect;
using Bosphorus.Common.Clr.Exception;
using Bosphorus.Common.Core.Application;
using Bosphorus.Common.Core.Context;
using Bosphorus.Common.Core.Context.Application;
using Bosphorus.Common.Core.Context.Invocation;
using Castle.DynamicProxy;

namespace Bosphorus.Aspect.Exception
{
    public class GenericServiceExecutionException<TService>: ExceptionBase
    {
        public GenericServiceExecutionException(ApplicationContext applicationContext, InvocationContext invocationContext, IInvocation invocation, System.Exception innerException)
            : base(ExceptionMessage.Build("Service execution failed")
                  .Add(nameof(applicationContext), applicationContext)
                  .Add(nameof(invocationContext), invocationContext)
                  .Add(nameof(invocation), invocation), innerException)
        {
            this.ApplicationContext = applicationContext;
            this.InvocationContext = invocationContext;
            this.Invocation = invocation;
        }

        public Type ServiceType => typeof (TService);

        public ApplicationContext ApplicationContext { get; }

        public InvocationContext InvocationContext { get; }

        public IInvocation Invocation { get; }
    }
}
