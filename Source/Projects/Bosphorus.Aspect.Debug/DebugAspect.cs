using Bosphorus.Aspect.Debug.ControlBuilder;
using Castle.DynamicProxy;

namespace Bosphorus.Aspect.Debug
{
    public class DebugAspect : IDebugAspect
    {
        private readonly GenericControlBuilder genericControlBuilder;

        public DebugAspect(GenericControlBuilder genericControlBuilder)
        {
            this.genericControlBuilder = genericControlBuilder;
        }

        //http://bugsquash.blogspot.com.tr/2010/03/proxying-and-parallelizing-processes.html
        //Remote
        public void Intercept(IInvocation invocation)
        {
            InvocationForm form = new InvocationForm(genericControlBuilder, invocation);
            form.ShowDialog();
        }
    }

}