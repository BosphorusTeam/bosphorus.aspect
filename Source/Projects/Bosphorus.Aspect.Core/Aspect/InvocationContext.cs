using System;
using Bosphorus.Common.Core.Context;

namespace Bosphorus.Aspect.Core.Aspect
{
    public class InvocationContext: IContext
    {
        private readonly Guid id;

        public InvocationContext()
        {
            id = Guid.NewGuid();
        }

        public Guid? Id => id;

        public object Get(string key)
        {
            return null;
        }
    }
}
