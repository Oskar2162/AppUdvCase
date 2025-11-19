using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BytteApp.Models
{
    public class Historik
    {

        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int købid { get; set; }
        public int price { get; set; }
        public int købsdato { get; set; }
    }
}
