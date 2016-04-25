using System;
using Bosphorus.Common.Api.Exception;
using Castle.DynamicProxy;

namespace Bosphorus.Aspect.Exception
{
    public class GenericServiceExecutionException<TService>: ExceptionBase
    {
        public GenericServiceExecutionException(IInvocation invocation, System.Exception innerException)
            : base(ExceptionMessage.Build("Service execution failed")
                  .Add(nameof(invocation), invocation), innerException)
        {
            this.Invocation = invocation;
        }

        public Type ServiceType => typeof (TService);

        public IInvocation Invocation { get; }
    }
}
