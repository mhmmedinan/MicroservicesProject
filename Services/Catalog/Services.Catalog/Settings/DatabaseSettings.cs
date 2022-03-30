using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Catalog.Settings
{
    public class DatabaseSettings
    {
        public string ConnectionString;
        public string Database;

        public const string ConnectionStringValue = nameof(ConnectionString);
        public const string DatabaseValue = nameof(Database);


      
    }
}
