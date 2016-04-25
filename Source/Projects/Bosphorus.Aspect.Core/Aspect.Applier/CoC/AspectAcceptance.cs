using System;
using System.Linq;
using Castle.Core;

namespace Bosphorus.Aspect.Core.Aspect.Applier.CoC
{
    public class AspectAcceptance
    {
        public ComponentModel ComponentModel { get; private set; }

        public AspectAcceptance(ComponentModel model)
        {
            ComponentModel = model;
        }
    }

    public static class AspectAcceptanceExtensions
    {
        public static bool IsService(this AspectAcceptance extended, params Type[] serviceTypes)
        {
            bool result = extended.ComponentModel.Services.Intersect(serviceTypes).Any();
            return result;
        }
    }
}
