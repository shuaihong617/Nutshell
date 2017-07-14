using System.Collections.Generic;
using MongoDB.Driver;
using Nutshell.Data.Mongo.Models;

namespace Nutshell.Storagine.MongoDB
{
        public class MongoDataSet<T> where T : MongoModel
        {
                public MongoDataSet(IMongoCollection<T> collection)
                {
                        _collection = collection;
                }

                private readonly IMongoCollection<T> _collection;

                public void Insert(T t)
                {
                        _collection.InsertOne(t);
                }

                public void Delete(T t)
                {
                        var filter = Builders<T>.Filter.Eq(x => x.Id,t.Id);
                        _collection.DeleteOne(filter);
                }

                public void Delete(string id)
                {
                        var filter = Builders<T>.Filter.Eq(x => x.Id, id);
                        _collection.DeleteOne(filter);
                }

                public void Update()
                {

                }

                public List<T> Select()
                {
                        return _collection.Find(FilterDefinition<T>.Empty).ToList();
                }
        }
}
