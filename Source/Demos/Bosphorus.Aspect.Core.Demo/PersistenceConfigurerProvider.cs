using Bosphorus.Dao.NHibernate.Fluent.PersistenceConfigurerProvider;
using FluentNHibernate.Cfg.Db;

namespace Bosphorus.Aspect.Core.Demo
{
    public class PersistenceConfigurerProvider: IPersistenceConfigurerProvider
    {
        public IPersistenceConfigurer GetPersistenceProvider(string sessionAlias)
        {
            SQLiteConfiguration persistenceConfigurer = SQLiteConfiguration
                .Standard
                .UsingFile("Local.db3");

            return persistenceConfigurer;
        }
    }
}
