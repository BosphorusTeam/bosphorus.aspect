using System;
using Castle.Core;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Handlers;

namespace Bosphorus.Aspect.Core
{
    public class GenericImplementationMatchingStrategy : IGenericImplementationMatchingStrategy
    {
        public Type[] GetGenericArguments(ComponentModel model, CreationContext context)
        {
            return new[] { context.RequestedType };
        }
    }
}
