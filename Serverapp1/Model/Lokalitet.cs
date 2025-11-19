using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serverapp1.Model
{
    public class Lokalitet
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int lokalitetid { get; set; }
        public string LName { get; set; }
        
        public List<Annonce> Annonces { get; set; } = new List<Annonce>();
       
    }
}
