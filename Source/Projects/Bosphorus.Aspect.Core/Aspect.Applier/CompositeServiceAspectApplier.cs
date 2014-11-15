using System.Collections.Generic;
using System.Linq;
using Castle.Core;

namespace Bosphorus.Aspect.Core.Aspect.Applier
{
    internal class CompositeServiceAspectApplier: IServiceAspectApplier
    {
        private readonly IList<IServiceAspectApplier> serviceAspectApplierList;

        public CompositeServiceAspectApplier(IList<IServiceAspectApplier> serviceAspectApplierList)
        {
            this.serviceAspectApplierList = serviceAspectApplierList;
        }

        public bool IsApplicable(ComponentModel model)
        {
            bool result = serviceAspectApplierList.Any(serviceAspectApplier => serviceAspectApplier.IsApplicable(model));
            return result;
        }

        public void Apply(ComponentModel model, ServiceAspectRegistry serviceAspectRegistry)
        {
            foreach (IServiceAspectApplier serviceAspectApplier in serviceAspectApplierList)
            {
                if (!serviceAspectApplier.IsApplicable(model))
                {
                    continue;
                }

                serviceAspectApplier.Apply(model, serviceAspectRegistry);
            }
        }
    }
}
