using MongoDB.Driver;
using Serverapp1.Model;

namespace Serverapp1.Repositories
{
    public class HistorikRepository
    {
        private string connectionString = "mongodb://localhost:27017";

        IMongoClient mongoClient;
        IMongoDatabase database;
        IMongoCollection<Historik> collection;

        public HistorikRepository()
        {
            mongoClient = new MongoClient(connectionString);
            database = mongoClient.GetDatabase("tøj_mongodb");
            collection = database.GetCollection<Historik>("indkoebshistorik");
        }

        public void AddHistorik(Historik h)
        {
            collection.InsertOne(h);
        }

        public List<Historik> GetAll()
        {
            return collection.Find(_ => true).ToList();
        }

        public Historik GetById(int koebId)
        {
            var filter = Builders<Historik>.Filter.Eq(x => x.købid, koebId);
            return collection.Find(filter).FirstOrDefault();
        }
    }
}