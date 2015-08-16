using Castle.Core;

namespace Bosphorus.Aspect.Core.Aspect.Applier
{
    public interface IAspectApplier
    {
        bool IsApplicable(ComponentModel model);

        void Apply(ComponentModel model, AspectRegistry aspectRegistry);
    }
}
