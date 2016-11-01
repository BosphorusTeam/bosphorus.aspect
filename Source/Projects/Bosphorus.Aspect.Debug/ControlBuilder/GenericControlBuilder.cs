using System.Windows.Forms;
using Castle.Windsor;

namespace Bosphorus.Aspect.Debug.ControlBuilder
{
    public class GenericControlBuilder
    {
        private readonly IWindsorContainer container;

        public GenericControlBuilder(IWindsorContainer container)
        {
            this.container = container;
        }

        public Control Build<TItem>(TItem item)
        {
            var controlBuilder = container.Resolve<IControlBuilder<TItem>>();
            var control = controlBuilder.Build(item);
            return control;
        }

    }
}
