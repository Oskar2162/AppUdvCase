using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Model
{
    public class User
    {

        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int userid { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string role { get; set; }
        
        public List<Tannonce> tannonces{ get; set; } = new List<Tannonce>();

    }
}
