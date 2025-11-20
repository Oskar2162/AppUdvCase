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

        // Ny: Create enkel annonce
        public void CreateAnnonce(Annonce annonce)
        {
            collection.InsertOne(annonce);
        }

        public void CreateAnnoncer(List<Annonce> annoncer)
        {
            collection.InsertMany(annoncer);
        }

        public void DeleteAll()
        {
            collection.DeleteMany(_ => true);
        }

        // Ny: Delete by id
        public void DeleteById(int aid)
        {
            collection.DeleteOne(a => a.annonceid == aid);
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

        public void UpdateAnnonce(Annonce annonce)
        {
            var filter = Builders<Annonce>.Filter.Eq(a => a.annonceid, annonce.annonceid);

            collection.ReplaceOne(filter, annonce);
        }

        public List<Annonce> GetByUserId(string userid)

        {
            var filter = Builders<Annonce>.Filter.Eq(a => a.userid, userid);
            return collection.Find(filter).ToList();
        }
    }
}