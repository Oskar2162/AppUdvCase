using BytteApp.Models;
using MongoDB.Driver;
using BytteApp.Models;

namespace ServerApp.Repositories
{
    public class TAnnonceRepository
    {
        private string connectionString = "mongodb://localhost:27017";

        IMongoClient mongoClient;
        IMongoDatabase database;
        IMongoCollection<Tannonce> collection;

        public TAnnonceRepository()
        {
            mongoClient = new MongoClient(connectionString);
            
            database = mongoClient.GetDatabase("tøj_mongodb");
            
            collection = database.GetCollection<Tannonce>("tannonce");
        }

        public void CreateTAnnonce(Tannonce tannonce)
        {
            collection.InsertOne(tannonce);
        }

        public List<Tannonce> GetAll()
        {
            return collection.Find(_ => true).ToList();
        }
        public void DeleteAll()
        {
            collection.DeleteMany(_ => true);
        }

        public Tannonce GetById(int id)
        {
            var filter = Builders<Tannonce>.Filter.Eq(t => t.tannonceid, id);
            return collection.Find(filter).FirstOrDefault();
        }
    }
}