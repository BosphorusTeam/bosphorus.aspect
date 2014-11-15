using Bosphorus.Dao.Core.Session.LifeStyle;
using Castle.Core;

namespace Bosphorus.Aspect.Core.Demo
{
    public class SingletonSessionProvider : AbstractSessionLifeStyleProvider
    {
        public override LifestyleType GetLifestyle()
        {
            return LifestyleType.Singleton;
        }
    }
}
