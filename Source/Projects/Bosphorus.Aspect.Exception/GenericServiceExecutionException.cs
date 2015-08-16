using System;
using Bosphorus.Aspect.Core.Aspect;
using Bosphorus.Common.Clr.Exception;
using Bosphorus.Common.Core.Application;
using Bosphorus.Common.Core.Context;
using Castle.DynamicProxy;

namespace Bosphorus.Aspect.Exception
{
    public class GenericServiceExecutionException<TService>: ExceptionBase
    {
        public GenericServiceExecutionException(ApplicationContext applicationContext, InvocationContext invocationContext, IInvocation invocation, System.Exception innerException)
            : base(ExceptionMessage.Build("Service execution failed")
                  .Add("ApplicationContext", applicationContext)
                  .Add("InvocationContext", invocationContext)
                  .Add("Invocation", invocation), innerException)
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
