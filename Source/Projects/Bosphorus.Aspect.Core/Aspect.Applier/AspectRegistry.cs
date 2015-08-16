using System;
using System.Collections.Generic;

namespace Bosphorus.Aspect.Core.Aspect.Applier
{
    public class AspectRegistry
    {
        private readonly IList<Type> aspects;

        public AspectRegistry()
        {
            aspects = new List<Type>();
        }

        public void Register(Type type)
        {
            aspects.Add(type);
        }

        public IEnumerable<Type> Aspects => aspects;
    }
}