using System.Collections.Generic;
using System.Linq;
using Castle.Core;

namespace Bosphorus.Aspect.Core.Aspect.Applier
{
    internal class CompositeAspectApplier: IAspectApplier
    {
        private readonly IList<IAspectApplier> serviceAspectApplierList;

        public CompositeAspectApplier(IList<IAspectApplier> serviceAspectApplierList)
        {
            this.serviceAspectApplierList = serviceAspectApplierList;
        }

        public bool IsApplicable(ComponentModel model)
        {
            bool result = serviceAspectApplierList.Any(serviceAspectApplier => serviceAspectApplier.IsApplicable(model));
            return result;
        }

        public void Apply(ComponentModel model, AspectRegistry aspectRegistry)
        {
            foreach (IAspectApplier serviceAspectApplier in serviceAspectApplierList)
            {
                if (!serviceAspectApplier.IsApplicable(model))
                {
                    continue;
                }

                serviceAspectApplier.Apply(model, aspectRegistry);
            }
        }
    }
}
