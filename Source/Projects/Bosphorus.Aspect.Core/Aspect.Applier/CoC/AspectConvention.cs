using System;
using System.Collections.Generic;

namespace Bosphorus.Aspect.Core.Aspect.Applier.CoC
{
    public class AspectConvention
    {
        public IList<Type> Aspects { get; }

        public AspectConvention()
        {
            Aspects = new List<Type>();
        }
    }

    public static class AspectConventionExtension
    {
        public static AspectConvention AddAspect<TAspect>(this AspectConvention extended)
            where TAspect : IAspect
        {
            return extended.AddAspect(typeof (TAspect));
        }

        public static AspectConvention AddAspect(this AspectConvention extended, Type aspectType)
        {
            extended.Aspects.Add(aspectType);
            return extended;
        }
    }
}
