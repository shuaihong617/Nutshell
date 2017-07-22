using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using MongoDB.Driver;
using Nutshell.Data.Mongo.Models;
using Nutshell.Data.MongoDB;
using Nutshell.Extensions;

namespace Nutshell.Storagine.MongoDB
{
        public class MongoStorager
        {

                private MongoClient _client;

                private IMongoDatabase _database;

                public void Connect()
                {
                        string connectionStr = "mongodb://127.0.0.1:27017";
                        //连接数据库

                        _client = new MongoClient(connectionStr);
                        _database = _client.GetDatabase("PMU");
                }

		/// <summary>
		/// Environments the verification.
		/// </summary>
		/// <exception cref="System.InvalidOperationException">数据库服务启动失败</exception>
		private void EnvironmentVerification()
		{
			var mongoDbServiceController = new ServiceController("MongoDB");

			if (mongoDbServiceController.Status != ServiceControllerStatus.Running)
			{
				File.Delete(@"D:\MongoDB32\Data\mongod.lock");

				mongoDbServiceController.Start();

				mongoDbServiceController.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(3));

				if (mongoDbServiceController.Status != ServiceControllerStatus.Running)
				{
					throw new InvalidOperationException("数据库服务启动失败");
				}
			}
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
