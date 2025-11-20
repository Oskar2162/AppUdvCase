using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serverapp1.Model;

namespace Serverapp1.Repositories
{
    public class UsersRepository
    {
        private string connectionString = "mongodb://localhost:27017";

        IMongoClient mongoClient;

        IMongoDatabase database;

        IMongoCollection<User> collection;

        public UsersRepository()
        {
            mongoClient = new MongoClient(connectionString);

            database = mongoClient.GetDatabase("tøj_mongodb");

            collection = database.GetCollection<User>("users");

        }
        public void CreateUsers(List<User> users)
        {
            collection.InsertMany(users);
        }

        public List<User> GetAll()
        {
            return collection.Find(_ => true).ToList();
        }
        
        public void DeleteAll()
        {
            collection.DeleteMany(_ => true);
        }
        public void Addbookings(int userid, Kategorier bl)

        {
            var filter = Builders<User>.Filter.Eq("id", userid);
            var update = Builders<User>.Update.Push<Kategorier>("Bookings", bl);
            
            collection.UpdateOne(filter, update);
        }
        
    }
}
