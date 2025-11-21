using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serverapp1.Model;

namespace Serverapp1.Repositories
{
    // Repository til at håndtere User-data i databasen
    public class UsersRepository
    {
        // Adresse til MongoDB-serveren
        private string connectionString = "mongodb://localhost:27017";

        IMongoClient mongoClient;

        IMongoDatabase database;

        IMongoCollection<User> collection;

        // Constructoren forbinder til databasen og vælger "users"-collection'en
        public UsersRepository()
        {
            // Opretter MongoDB-klient
            mongoClient = new MongoClient(connectionString);

            // Vælger databasen "tøj_mongodb"
            database = mongoClient.GetDatabase("tøj_mongodb");

            // Vælger collection'en "users", hvor alle brugere gemmes
            collection = database.GetCollection<User>("users");
        }

        // Opretter flere brugere på én gang
        public void CreateUsers(List<User> users)
        {
            // Indsætter hele listen af User-objekter i collection'en
            collection.InsertMany(users);
        }

        // Henter alle brugere
        public List<User> GetAll()
        {
            // Find(_ => true) = hent alle dokumenter
            return collection.Find(_ => true).ToList();
        }

        // Sletter alle brugere
        public void DeleteAll()
        {
            // Slet alle dokumenter i "users"-collection'en
            collection.DeleteMany(_ => true);
        }

        // Tilføjer en booking til en bestemt bruger
        public void Addbookings(int userid, Kategorier bl)
        {
            // Filter: find den bruger, hvor feltet "id" matcher userid
            // (bemærk: her bruges string "id" i stedet for lambda – det peger på et felt i dokumentet)
            var filter = Builders<User>.Filter.Eq("id", userid);

            // Update: Push betyder "tilføj element til en liste-felt" (her: Bookings-listen)
            var update = Builders<User>.Update.Push<Kategorier>("Bookings", bl);

            // Udfører opdateringen på det dokument, der matcher filteret
            collection.UpdateOne(filter, update);
        }
    }
}
