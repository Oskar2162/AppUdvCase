using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Serverapp1.Repositories
{
    public class AnnonceRepository
    {
        // Adresse til vores MongoDB-server (lokalt på computeren)
        private string connectionString = "mongodb://localhost:27017";

        // Objekt til at forbinde til MongoDB-serveren
        IMongoClient mongoClient;

        // Repræsenterer selve databasen inde på MongoDB-serveren
        IMongoDatabase database;

        // Repræsenterer en bestemt tabel (kaldes også collection) med Annonce-dokumenter
        IMongoCollection<Annonce> collection;

        // Constructoren kører automatisk, når vi laver et nyt AnnonceRepository-objekt
        public AnnonceRepository()
        {
            // Opretter forbindelsen til MongoDB med connectionString
            mongoClient = new MongoClient(connectionString);

            // Vælger databasen med navnet "tøj_mongodb"
            database = mongoClient.GetDatabase("tøj_mongodb");

            // Vælger collection'en "annoncer", hvor alle annoncer ligger
            collection = database.GetCollection<Annonce>("annoncer");
        }

        // Opretter (gemmer) én ny annonce i databasen
        public void CreateAnnonce(Annonce annonce)
        {
            // Indsætter det modtagne annonce-objekt som et dokument i collection'en
            collection.InsertOne(annonce);
        }

        // Opretter (gemmer) flere annoncer på én gang
        public void CreateAnnoncer(List<Annonce> annoncer)
        {
            // Indsætter alle annoncer i listen som dokumenter i collection'en
            collection.InsertMany(annoncer);
        }

        // Sletter alle annoncer i collection'en
        public void DeleteAll()
        {
            // DeleteMany med "_ => true" betyder: slet ALT i collection'en
            collection.DeleteMany(_ => true);
        }

        // Sletter en enkelt annonce ud fra dens annonceid
        public void DeleteById(int aid)
        {
            // DeleteOne finder det dokument, hvor annonceid matcher aid, og sletter det
            collection.DeleteOne(a => a.annonceid == aid);
        }

        // Henter alle annoncer fra databasen
        public List<Annonce> GetAll()
        {
            // Find(_ => true) betyder: find alle dokumenter. ToList() laver det om til en C#-liste
            return collection.Find(_ => true).ToList();
        }

        // Henter én bestemt annonce ud fra annonceid
        public Annonce GetAnnonceById(int aid)
        {
            // Bygger et filter: vi vil kun have det dokument, hvor annonceid == aid
            var filter = Builders<Annonce>.Filter.Eq(a => a.annonceid, aid);

            // Finder det første dokument, der matcher filteret (eller null hvis ingen findes)
            return collection.Find(filter).FirstOrDefault();
        }

        // Henter alle annoncer der tilhører en bestemt bruger (userid)
        public List<Annonce> GetByUserId(string userid)
        {
            // Filter = find alle dokumenter, hvor feltet userid matcher det userid, vi får ind
            var filter = Builders<Annonce>.Filter.Eq(a => a.userid, userid);

            // Returnerer alle matchende annoncer som en liste
            return collection.Find(filter).ToList();
        }
    }
}
