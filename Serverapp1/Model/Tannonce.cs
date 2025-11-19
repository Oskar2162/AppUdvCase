using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BytteApp.Models
{
    public class Tannonce
    {

        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int tannonceid { get; set; }
        public int price { get; set; }
        public string title { get; set; }
        public string description {get; set; }
        public int lid { get; set; }
        public string Status { get; set; }
        
    }
}
