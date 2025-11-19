using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BytteApp.Models;

namespace ServerApp1.Repositories
{
    public class AnnonceRepository
    {
        private string connectionString = "mongodb://localhost:27017";

        IMongoClient mongoClient;

        IMongoDatabase database;

        IMongoCollection<Annonce> collection;

        public AnnonceRepository()
        {
            mongoClient = new MongoClient(connectionString);

            database = mongoClient.GetDatabase("tøj_mongodb");

            collection = database.GetCollection<Annonce>("annoncer");
        }

        public void CreateAnnoncer(List<Annonce> annoncer)
            {
                collection.InsertMany(annoncer);
            }
        public void DeleteAll()
        {
            collection.DeleteMany(_ => true);
        }
        
        public List<Annonce> GetAll()
        {
            return collection.Find(_ => true).ToList();
        }


        public Annonce GetAnnonceById(int aid)
        {
            var filter = Builders<Annonce>.Filter.Eq(a => a.annonceid, aid);
            return collection.Find(filter).FirstOrDefault();
        }
    }
    }

