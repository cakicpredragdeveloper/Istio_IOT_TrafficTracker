using System;
using System.Collections.Generic;
using System.Text;

namespace DataProvider.Config
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string TracksCollectionName { get ; set ; }
        public string ConnectionString { get ; set ; }
        public string DatabaseName { get ; set ; }
    }
}
