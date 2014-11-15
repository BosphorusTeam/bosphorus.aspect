using System;
using Bosphorus.Aspect.Core.Aspect;
using Bosphorus.Common.Clr.Exception;
using Castle.DynamicProxy;

namespace Bosphorus.Aspect.Exception
{
    public class GenericServiceExecutionException<TService>: ExceptionBase
    {
        private readonly InvocationContext invocationContext;
        private readonly IInvocation invocation;

        public GenericServiceExecutionException(InvocationContext invocationContext, IInvocation invocation, System.Exception innerException)
            : base(ExceptionMessage.Build("Service execution failed").Add("InvocationContext", invocationContext).Add("Invocation", invocation) , innerException)
        {
            this.invocationContext = invocationContext;
            this.invocation = invocation;
        }

        public Type ServiceType
        {
            get { return typeof (TService); }
        }

        public IInvocation Invocation
        {
            get { return invocation; }
        }

        public InvocationContext InvocationContext
        {
            get { return invocationContext; }
        }
    }
}
