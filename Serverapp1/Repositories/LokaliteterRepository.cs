using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serverapp1.Model;

namespace Serverapp1.Repositories
{
    public class LokaliteterRepository
    {
        private string connectionString = "mongodb://localhost:27017";

        IMongoClient mongoClient;

        IMongoDatabase database;

        IMongoCollection<Lokalitet> collection;

        public LokaliteterRepository()
        {
            mongoClient = new MongoClient(connectionString);

            database = mongoClient.GetDatabase("tøj_mongodb");

            collection = database.GetCollection<Lokalitet>("lokaliteter");

        }
        
        public void DeleteAll()
        {
            collection.DeleteMany(_ => true);
        }

        public void NewLokalitet(Lokalitet lokalitet)
        {
           collection.InsertOneAsync(lokalitet);
        }

        
       


    }
}
