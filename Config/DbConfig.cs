using System.Collections.Generic;
using System.Linq;
using LinqToDB.Configuration;

namespace MusterAg.Monitoring.Client.Config
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }

    public class DbConfig : ILinqToDBSettings
    {
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();

        public string DefaultConfiguration => "MySql";
        public string DefaultDataProvider => "MySql";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "MusterAgDb",
                        ProviderName = "MySql",
                        ConnectionString = "Server=localhost;Database=musterag;Uid=root;Pwd=admin;"
                    };
            }
        }
    }
}