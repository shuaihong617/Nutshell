using System.Diagnostics;
using MongoDB.Driver;
using Nutshell.Data.Mongo.Models;
using Nutshell.Data.MongoDB;
using Nutshell.Extensions;

namespace Nutshell.Storagine.MongoDB
{
        public class MongoStorager
        {
                private MongoStorageConnectContext _connectContext;

                private MongoClient _client;

                private IMongoDatabase _database;

                public void Connect()
                {
                        //_connectContext = context;

                        string connectionStr = "mongodb://127.0.0.1:27017";
                        //连接数据库

                        _client = new MongoClient(connectionStr);
                        _database = _client.GetDatabase("EMP.PMC");
                }

                

                public MongoDataSet<T> GetDataSet<T>(string collectionName = "") where T:MongoModel
                {
                        Debug.Assert(_database != null);

                        if (collectionName.IsEmpty())
                        {
                                collectionName = typeof (T).Name + "s";
                        }
                        var collection = _database.GetCollection<T>(collectionName);
                        return new MongoDataSet<T>(collection);
                }
        }
}
