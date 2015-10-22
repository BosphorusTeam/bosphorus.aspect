using Bosphorus.Aspect.Core.Aspect.Applier.CoC;
using Bosphorus.Aspect.Default;
using Bosphorus.Aspect.Exception;
using Bosphorus.Aspect.Log;
using Bosphorus.BootStapper.Runner.Console;
using Bosphorus.Common.Core.CoC.Acceptance;
using Bosphorus.Common.Core.CoC.Convention;

namespace Bosphorus.Aspect.Core.Demo
{
    public class AspectApplier: IAcceptance<AspectAcceptance>, IConvention<AspectConvention>
    {
        public void Accept(ICriteria<AspectAcceptance> criteria)
        {
            criteria.Expect(acceptance => acceptance.IsService(typeof (IService), typeof (IProgram)));
        }

        public void Apply(AspectConvention context)
        {
            context
                .AddAspect(typeof (IDefaultAspect<>))
                .AddAspect(typeof (IExceptionAspect<>))
                .AddAspect(typeof (ILogAspect<>));
        }
    }
}
