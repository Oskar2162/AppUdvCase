using MongoDB.Driver;
using Serverapp1.Model;

namespace Serverapp1.Repositories
{
    // Repository til at arbejde med købs-historik i databasen
    public class HistorikRepository
    {
        // Adresse til MongoDB-serveren
        private string connectionString = "mongodb://localhost:27017";

        IMongoClient mongoClient;
        IMongoDatabase database;
        IMongoCollection<Historik> collection;

        // Constructoren sætter forbindelse til databasen og vælger den rigtige collection
        public HistorikRepository()
        {
            // Opretter MongoDB-klienten ud fra connectionString
            mongoClient = new MongoClient(connectionString);

            // Vælger databasen "tøj_mongodb"
            database = mongoClient.GetDatabase("tøj_mongodb");

            // Vælger collection'en "indkoebshistorik", hvor alle køb gemmes
            collection = database.GetCollection<Historik>("indkoebshistorik");
        }

        // Tilføjer en ny historik-post (et køb) til databasen
        public void AddHistorik(Historik h)
        {
            // Indsætter Historik-objektet som et dokument i collection'en
            collection.InsertOne(h);
        }

        // Henter alle historik-poster (alle køb)
        public List<Historik> GetAll()
        {
            // Find(_ => true) = hent alle dokumenter
            return collection.Find(_ => true).ToList();
        }

        // Henter ét specifikt køb ud fra købs-id
        public Historik GetById(int koebId)
        {
            // Filter: find dokumentet hvor købid matcher koebId
            var filter = Builders<Historik>.Filter.Eq(x => x.købid, koebId);

            // Returnér det første match (eller null hvis intet findes)
            return collection.Find(filter).FirstOrDefault();
        }
    }
}