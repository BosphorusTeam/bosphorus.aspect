using Bosphorus.Dao.NHibernate.Fluent.ConfigurationProcessor;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Bosphorus.Aspect.Core.Demo
{
    public class SchemaUpdater : AbstractConfigurationProcessor
    {
        protected override void Process(Configuration configuration)
        {
            SchemaUpdate schemaUpdate = new SchemaUpdate(configuration);
            schemaUpdate.Execute(true, true);
        }
    }
}
