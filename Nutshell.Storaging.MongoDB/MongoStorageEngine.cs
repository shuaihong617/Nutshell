using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Nutshell.Data.MongoDB
{
        public class MongoStorageEngine
        {
                private MongoStorageConnectContext _connectContext;

                private MongoClient _client;

                private IMongoDatabase _database;

                public void Connect(MongoStorageConnectContext context)
                {
                        _connectContext = context;

                        string connectionStr = "mongodb://Will1:Will1@localhost";
                        //连接数据库

                        _client = new MongoClient(connectionStr);
                        _database = _client.GetDatabase("EMP.PMC");
                        var collection = _database.GetCollection<>("student");
                        //获得数据库和collection对象
                        try
                        {
                                Console.WriteLine("db name is: " + db.Name);
                                Console.WriteLine("collections name is: " + collection.Name);
                                Console.WriteLine("{0} items in this collection", collection.Count());
                        }
                }

                public void Disconnect()
                {
                        
                }

                public void Insert()
                {

                }

                public void Delete()
                {

                }


                public void Update()
                {

                }

                public void Select()
                {
                        
                }

                
        }
}
