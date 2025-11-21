using MongoDB.Driver;
using Serverapp1.Model;

namespace Serverapp1.Repositories
{
    // Repository til at arbejde med "Tannonce" (måske en bestemt type annoncer?) i databasen
    public class TAnnonceRepository
    {
        // Adresse til MongoDB-serveren
        private string connectionString = "mongodb://localhost:27017";

        IMongoClient mongoClient;
        IMongoDatabase database;
        IMongoCollection<Tannonce> collection;

        // Constructoren sætter forbindelse til databasen og vælger "tannonce"-collection'en
        public TAnnonceRepository()
        {
            // Opretter klienten, der kan snakke med MongoDB
            mongoClient = new MongoClient(connectionString);

            // Vælger databasen "tøj_mongodb"
            database = mongoClient.GetDatabase("tøj_mongodb");

            // Vælger collection'en "tannonce", hvor Tannonce-dokumenter ligger
            collection = database.GetCollection<Tannonce>("tannonce");
        }

        // Opretter (gemmer) en ny Tannonce i databasen
        public void CreateTAnnonce(Tannonce tannonce)
        {
            collection.InsertOne(tannonce);
        }

        // Henter alle Tannonce-dokumenter
        public List<Tannonce> GetAll()
        {
            return collection.Find(_ => true).ToList();
        }

        // Sletter alle Tannonce-dokumenter
        public void DeleteAll()
        {
            collection.DeleteMany(_ => true);
        }

        // Henter én Tannonce ud fra dens id (tannonceid)
        public Tannonce GetById(int id)
        {
            // Filter: find dokumentet, hvor tannonceid matcher id
            var filter = Builders<Tannonce>.Filter.Eq(t => t.tannonceid, id);

            // Returnér det første match (eller null hvis ingen findes)
            return collection.Find(filter).FirstOrDefault();
        }
    }
}