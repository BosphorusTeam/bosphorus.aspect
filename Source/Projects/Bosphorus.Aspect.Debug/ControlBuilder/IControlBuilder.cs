using System.Windows.Forms;

namespace Bosphorus.Aspect.Debug.ControlBuilder
{
    public interface IControlBuilder<in TItem>
    {
        Control Build(TItem item);
    }
}