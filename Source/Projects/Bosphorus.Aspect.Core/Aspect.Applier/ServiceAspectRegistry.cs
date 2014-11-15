using System;
using System.Collections.Generic;

namespace Bosphorus.Aspect.Core.Aspect.Applier
{
    public class ServiceAspectRegistry
    {
        private readonly IList<Type> aspects;

        public ServiceAspectRegistry()
        {
            aspects = new List<Type>();
        }

        public void Register(Type type)
        {
            aspects.Add(type);
        }

        public IEnumerable<Type> Aspects
        {
            get { return aspects; }
        }

    }
}