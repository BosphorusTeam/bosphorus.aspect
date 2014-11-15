using System;
using System.Collections.Generic;
using Bosphorus.Aspect.Core.Aspect;
using Bosphorus.Common.Core.Context;

namespace Bosphorus.Aspect.Default
{
    public class InvocationContextProvider: IContextProvider<InvocationContext>
    {
        private readonly Stack<InvocationContext> invocationContextStack;

        public InvocationContextProvider()
        {
            invocationContextStack = new Stack<InvocationContext>();
        }

        public void Register(InvocationContext invocationContext)
        {
            invocationContextStack.Push(invocationContext);
        }

        public InvocationContext Get()
        {
            InvocationContext result = invocationContextStack.Peek();
            return result;
        }

        public void Unregister(InvocationContext invocationContext)
        {
            invocationContextStack.Pop();
        }
    }
}
