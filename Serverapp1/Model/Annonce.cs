using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serverapp1.Model
{
    public class Annonce
    {
        // [BsonId] = dette felt er dokumentets primære id i MongoDB
        // [BsonRepresentation(BsonType.Int32)] = id'et gemmes som tal (int) i databasen
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int annonceid { get; set; }

        // Pris på annoncen
        public int price { get; set; }

        // Titel på annoncen (f.eks. "Hvid T-shirt str. L")
        public string title { get; set; }

        // Beskrivelse af varen
        public string description { get; set; }

        // Id på den lokalitet (sted), annoncen hører til
        public int lid { get; set; }

        // Status på annoncen (f.eks. "Aktiv", "Solgt")
        public string Status { get; set; }
    }
}