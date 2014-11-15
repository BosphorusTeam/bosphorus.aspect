using Castle.Core;

namespace Bosphorus.Aspect.Core.Aspect.Applier
{
    public interface IServiceAspectApplier
    {
        bool IsApplicable(ComponentModel model);

        void Apply(ComponentModel model, ServiceAspectRegistry serviceAspectRegistry);
    }
}
