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

        // Constructoren sætter forbindelsen op til databasen og vælger "lokaliteter"-collectionen
        public LokaliteterRepository()
        {
            // Opretter klient til MongoDB
            mongoClient = new MongoClient(connectionString);

            // Vælger databasen "tøj_mongodb"
            database = mongoClient.GetDatabase("tøj_mongodb");

            // Vælger collection'en "lokaliteter", hvor alle lokaliteter gemmes
            collection = database.GetCollection<Lokalitet>("lokaliteter");

        }

        // Sletter alle lokaliteter i collection'en
        public void DeleteAll()
        {
            // DeleteMany(_ => true) = slet alle dokumenter
            collection.DeleteMany(_ => true);
        }

        public void NewLokalitet(Lokalitet lokalitet)
        {
            // Indsætter lokalitet-dokumentet asynkront i collection'en
            // (InsertOneAsync returnerer en Task, men den bliver ikke awaited her)
            collection.InsertOneAsync(lokalitet);
        }
    }
}